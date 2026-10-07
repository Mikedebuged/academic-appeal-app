using System;
using System.Windows.Forms;

namespace AcademicAppeal
{
    // Starting page. Starts a new appeal or opens a saved one at the right step.
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
        }

        private void newFormButton_Click(object sender, EventArgs e)
        {
            ShowPage(new StudentForm());
        }

        private void studentPageButton_Click(object sender, EventArgs e)
        {
            ShowPage(new StudentForm());
        }

        // Shows a saved appeal on the student page, read-only.
        private void openButton_Click(object sender, EventArgs e)
        {
            AppealRecord record;
            string path;
            if (AppealFile.TryOpen(this, out record, out path))
                ShowPage(new StudentForm(record));
        }

        private void instructorPageButton_Click(object sender, EventArgs e)
        {
            OpenStep(2);
        }

        private void chairPageButton_Click(object sender, EventArgs e)
        {
            OpenStep(3);
        }

        private void deanPageButton_Click(object sender, EventArgs e)
        {
            OpenStep(4);
        }

        // Steps 2 to 4 work on a saved appeal, so ask for the file first.
        // A step only opens once the step before it has been filled in.
        private void OpenStep(int step)
        {
            AppealRecord record;
            string path;
            if (!AppealFile.TryOpen(this, out record, out path))
                return;

            if (record.StepsCompleted() < step - 1)
            {
                MessageBox.Show(this, "Step " + (step - 1) + " hasn't been completed for this appeal yet.",
                    Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Form page;
            if (step == 2)
                page = new InstructorForm(record, path);
            else if (step == 3)
                page = new ChairForm(record, path);
            else
                page = new DeanForm(record, path);
            ShowPage(page);
        }

        // Hides this page while another one is open and comes back when it closes,
        // so closing any page returns here instead of leaving the app running hidden.
        private void ShowPage(Form page)
        {
            Hide();
            using (page)
            {
                page.ShowDialog();
            }
            Show();
        }
    }
}
