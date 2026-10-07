using System;
using System.Windows.Forms;

namespace AcademicAppeal
{
    // Step 4: records who the student dealt with at this level (the dean or designate)
    // and the outcome, then saves it back into the appeal file.
    public partial class DeanForm : Form
    {
        private readonly AppealRecord record;
        private readonly string path;

        public DeanForm(AppealRecord record, string path)
        {
            InitializeComponent();
            this.record = record;
            this.path = path;
            Text = "Step 4: Dean or Designate - " + record;
            nameBox.Text = record.DeanName ?? "";
            outcomeBox.Text = record.DeanOutcome ?? "";
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
            return nameBox.Text.Trim() != (record.DeanName ?? "")
                || outcomeBox.Text.Trim() != (record.DeanOutcome ?? "");
        }

        private bool TrySave()
        {
            if (string.IsNullOrWhiteSpace(nameBox.Text) || string.IsNullOrWhiteSpace(outcomeBox.Text))
            {
                MessageBox.Show(this, "Enter a name and describe the outcome before saving.", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            string previousName = record.DeanName;
            string previousOutcome = record.DeanOutcome;
            record.DeanName = nameBox.Text.Trim();
            record.DeanOutcome = outcomeBox.Text.Trim();
            if (!AppealFile.TrySave(this, record, path))
            {
                record.DeanName = previousName;
                record.DeanOutcome = previousOutcome;
                return false;
            }
            MessageBox.Show(this, "Step 4 saved.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
