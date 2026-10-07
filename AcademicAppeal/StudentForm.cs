using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AcademicAppeal
{
    // Step 1: the student fills in their details, a summary of the appeal and the
    // resolution they want, then submits. The saved file goes on to Step 2.
    public partial class StudentForm : Form
    {
        public StudentForm()
        {
            InitializeComponent();
        }

        // Shows a saved appeal read-only.
        public StudentForm(AppealRecord record) : this()
        {
            ShowRecord(record);
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            List<string> missing = FindMissingFields();
            if (missing.Count > 0)
            {
                MessageBox.Show(this, "Please complete the following before submitting:\n\n- " + string.Join("\n- ", missing),
                    Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            AppealRecord record = ReadRecord();
            string path = AppealFile.ChooseSavePath(this, record);
            if (path == null || !AppealFile.TrySave(this, record, path))
                return;

            SetReadOnly(true);
            MessageBox.Show(this, "Appeal saved to:\n" + path + "\n\nThe instructor page will open next.",
                Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Pass the saved appeal straight to Step 2, then go back to the admin page.
            using (InstructorForm instructor = new InstructorForm(record, path))
            {
                instructor.ShowDialog(this);
            }
            Close();
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            AppealRecord record;
            string path;
            if (AppealFile.TryOpen(this, out record, out path))
                ShowRecord(record);
        }

        private List<string> FindMissingFields()
        {
            List<string> missing = new List<string>();
            if (IsBlank(stuname)) missing.Add("Student name");
            if (IsBlank(stuId)) missing.Add("Student ID");
            if (IsBlank(stuemail)) missing.Add("Email address");
            if (IsBlank(coursenumber)) missing.Add("Course acronym and number");
            if (IsBlank(Instruname)) missing.Add("Instructor's name");
            if (SelectedTerm() == "") missing.Add("Academic term");
            if (IsBlank(year)) missing.Add("Year");
            if (IsBlank(summary)) missing.Add("Summary of appeal");
            if (IsBlank(resolution)) missing.Add("Resolution being sought");
            if (!(chkTriedToResolve.Checked && chkOutcomeIdentified.Checked && chkTruthful.Checked && chkFeePaid.Checked))
                missing.Add("All four submission checklist items");
            if (IsBlank(Signature)) missing.Add("Signature");
            return missing;
        }

        private static bool IsBlank(Control box)
        {
            return string.IsNullOrWhiteSpace(box.Text);
        }

        private string SelectedTerm()
        {
            if (Fall.Checked) return Fall.Text;
            if (Winter.Checked) return Winter.Text;
            if (Summer.Checked) return Summer.Text;
            return "";
        }

        private AppealRecord ReadRecord()
        {
            return new AppealRecord
            {
                StudentName = stuname.Text.Trim(),
                StudentId = stuId.Text.Trim(),
                Email = stuemail.Text.Trim(),
                PhoneNumber = stuphone.Text.Trim(),
                CourseNumber = coursenumber.Text.Trim(),
                CourseTitle = coursetitle.Text.Trim(),
                InstructorName = Instruname.Text.Trim(),
                Term = SelectedTerm(),
                Year = year.Text.Trim(),
                CourseStartDate = courseStartDate.Value,
                Summary = summary.Text.Trim(),
                ResolutionSought = resolution.Text.Trim(),
                TriedToResolve = chkTriedToResolve.Checked,
                OutcomeIdentified = chkOutcomeIdentified.Checked,
                ConfirmedTruthful = chkTruthful.Checked,
                FeePaid = chkFeePaid.Checked,
                Signature = Signature.Text.Trim(),
                DateSubmitted = dateSubmitted.Value
            };
        }

        // Puts every saved value back in the box it came from.
        private void ShowRecord(AppealRecord record)
        {
            stuname.Text = record.StudentName;
            stuId.Text = record.StudentId;
            stuemail.Text = record.Email;
            stuphone.Text = record.PhoneNumber;
            coursenumber.Text = record.CourseNumber;
            coursetitle.Text = record.CourseTitle;
            Instruname.Text = record.InstructorName;
            Fall.Checked = record.Term == Fall.Text;
            Winter.Checked = record.Term == Winter.Text;
            Summer.Checked = record.Term == Summer.Text;
            year.Text = record.Year;
            SetDate(courseStartDate, record.CourseStartDate);
            summary.Text = record.Summary;
            resolution.Text = record.ResolutionSought;
            chkTriedToResolve.Checked = record.TriedToResolve;
            chkOutcomeIdentified.Checked = record.OutcomeIdentified;
            chkTruthful.Checked = record.ConfirmedTruthful;
            chkFeePaid.Checked = record.FeePaid;
            Signature.Text = record.Signature;
            SetDate(dateSubmitted, record.DateSubmitted);

            Text = "Student Academic Appeal Form - " + record + " - " + record.StepsCompleted() + " of 4 steps complete";
            SetReadOnly(true);
        }

        // DateTimePicker throws if it's given a date outside its range.
        private static void SetDate(DateTimePicker picker, DateTime value)
        {
            if (value >= picker.MinDate && value <= picker.MaxDate)
                picker.Value = value;
        }

        // A submitted appeal can be viewed but not changed.
        private void SetReadOnly(bool readOnly)
        {
            foreach (Control control in Controls)
            {
                TextBoxBase box = control as TextBoxBase;
                if (box != null)
                    box.ReadOnly = readOnly;
                else if (control is RadioButton || control is CheckBox || control is DateTimePicker)
                    control.Enabled = !readOnly;
            }
            submitButton.Enabled = !readOnly;
        }
    }
}
