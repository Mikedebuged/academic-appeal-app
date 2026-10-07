using System;
using System.Windows.Forms;

namespace AcademicAppeal
{
    // Step 3: records who the student dealt with at this level (the department chair or associate director of OL program delivery)
    // and the outcome, then saves it back into the appeal file.
    public partial class ChairForm : Form
    {
        private readonly AppealRecord record;
        private readonly string path;

        public ChairForm(AppealRecord record, string path)
        {
            InitializeComponent();
            this.record = record;
            this.path = path;
            Text = "Step 3: Department Chair - " + record;
            nameBox.Text = record.ChairName ?? "";
            outcomeBox.Text = record.ChairOutcome ?? "";
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
            return nameBox.Text.Trim() != (record.ChairName ?? "")
                || outcomeBox.Text.Trim() != (record.ChairOutcome ?? "");
        }

        private bool TrySave()
        {
            if (string.IsNullOrWhiteSpace(nameBox.Text) || string.IsNullOrWhiteSpace(outcomeBox.Text))
            {
                MessageBox.Show(this, "Enter a name and describe the outcome before saving.", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            string previousName = record.ChairName;
            string previousOutcome = record.ChairOutcome;
            record.ChairName = nameBox.Text.Trim();
            record.ChairOutcome = outcomeBox.Text.Trim();
            if (!AppealFile.TrySave(this, record, path))
            {
                record.ChairName = previousName;
                record.ChairOutcome = previousOutcome;
                return false;
            }
            MessageBox.Show(this, "Step 3 saved.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
