using System;

namespace AcademicAppeal
{
    // One student academic appeal. The whole object is saved to an XML file,
    // and each step of the process fills in its own section.
    public class AppealRecord
    {
        // Step 1: student and course information, filled in by the student
        public string StudentName { get; set; }
        public string StudentId { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string CourseNumber { get; set; }
        public string CourseTitle { get; set; }
        public string InstructorName { get; set; }
        public string Term { get; set; }
        public string Year { get; set; }
        public DateTime CourseStartDate { get; set; }
        public string Summary { get; set; }
        public string ResolutionSought { get; set; }
        public bool TriedToResolve { get; set; }
        public bool OutcomeIdentified { get; set; }
        public bool ConfirmedTruthful { get; set; }
        public bool FeePaid { get; set; }
        public string Signature { get; set; }
        public DateTime DateSubmitted { get; set; }

        // Step 2: instructor or Open Learning faculty member
        public string InstructorOutcome { get; set; }

        // Step 3: department chair or associate director of OL program delivery
        public string ChairName { get; set; }
        public string ChairOutcome { get; set; }

        // Step 4: dean or designate
        public string DeanName { get; set; }
        public string DeanOutcome { get; set; }

        // How many of the four steps have been filled in so far.
        public int StepsCompleted()
        {
            if (string.IsNullOrWhiteSpace(InstructorOutcome)) return 1;
            if (string.IsNullOrWhiteSpace(ChairOutcome)) return 2;
            if (string.IsNullOrWhiteSpace(DeanOutcome)) return 3;
            return 4;
        }

        public override string ToString()
        {
            return StudentName + " (" + StudentId + "), " + CourseNumber;
        }
    }
}
