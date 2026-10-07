using System;
using System.Windows.Forms;

namespace AcademicAppeal
{
    // Step 2: records the outcome with the instructor or Open Learning faculty member
    // and saves it back into the appeal file.
    public partial class InstructorForm : Form
    {
        private readonly AppealRecord record;
        private readonly string path;

        public InstructorForm(AppealRecord record, string path)
        {
            InitializeComponent();
            this.record = record;
            this.path = path;
            Text = "Step 2: Instructor (" + record.InstructorName + ") - " + record;
            outcomeBox.Text = record.InstructorOutcome ?? "";
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            TrySave();
        }

        private void doneButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private bool HasUnsavedChanges()
        {
            return outcomeBox.Text.Trim() != (record.InstructorOutcome ?? "");
        }

        private bool TrySave()
        {
            if (string.IsNullOrWhiteSpace(outcomeBox.Text))
            {
                MessageBox.Show(this, "Describe the outcome before saving.", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            string previous = record.InstructorOutcome;
            record.InstructorOutcome = outcomeBox.Text.Trim();
            if (!AppealFile.TrySave(this, record, path))
            {
                record.InstructorOutcome = previous;
                return false;
            }
            MessageBox.Show(this, "Step 2 saved.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            return true;
        }

        // Covers both the Done button and the window's close button.
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (!e.Cancel && HasUnsavedChanges())
                e.Cancel = !AppealFile.ConfirmClose(this, Text, TrySave);
        }
    }
}
