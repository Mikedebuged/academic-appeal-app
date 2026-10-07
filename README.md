# Student Academic Appeal App

A Windows Forms desktop app that turns Thompson Rivers University's Student Academic Appeal form into a four-step digital workflow. I built it in C# on .NET Framework 4.8 as an individual course project.

## How it works

An appeal moves through the same steps as the paper form:

1. Student: enters their details, the course, a summary of the appeal and the resolution they want, then completes the submission checklist and signs. Submitting saves the appeal to a file and opens step 2.
2. Instructor or Open Learning faculty member: records the outcome of the student's discussion at this level.
3. Department chair or associate director of OL program delivery: records who the student spoke with and the outcome.
4. Dean or designate: the same as step 3, at the dean's level.

The admin page is the starting point. New appeal opens a blank student form, and Open appeal shows a saved appeal read-only. The instructor, chair and dean buttons ask for an appeal file and open that step. A step won't open until the one before it has been saved.

## Appeal files

Each appeal is a single XML file written with .NET's `XmlSerializer`. Every step reads and updates the same file, so one file holds the whole appeal from submission to the dean's response. `AppealRecord.cs` defines what gets saved.

## Running it

Windows Forms on .NET Framework only runs on Windows.

1. Install Visual Studio Community with the ".NET desktop development" workload.
2. Open `AcademicAppeal.sln`.
3. Press F5 to build and run.

## Project layout

| File | Purpose |
| --- | --- |
| `AdminForm.cs` | Starting page and navigation between steps |
| `StudentForm.cs` | Step 1, with required-field checks and read-only viewing |
| `InstructorForm.cs`, `ChairForm.cs`, `DeanForm.cs` | Steps 2 to 4 |
| `AppealRecord.cs` | The data saved for each appeal |
| `AppealFile.cs` | Saving, loading and the file dialogs |

This is a student project and not an official TRU system.
