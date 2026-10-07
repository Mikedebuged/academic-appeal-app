using System;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace AcademicAppeal
{
    // Reads and writes appeal files and shows the Open and Save dialogs,
    // so every page handles files the same way.
    public static class AppealFile
    {
        private const string Filter = "Appeal files (*.xml)|*.xml|All files (*.*)|*.*";
        private static readonly XmlSerializer Serializer = new XmlSerializer(typeof(AppealRecord));

        public static void Save(AppealRecord record, string path)
        {
            using (StreamWriter writer = new StreamWriter(path, false))
            {
                Serializer.Serialize(writer, record);
            }
        }

        public static AppealRecord Load(string path)
        {
            using (StreamReader reader = new StreamReader(path))
            {
                return (AppealRecord)Serializer.Deserialize(reader);
            }
        }

        // Asks where to save a new appeal. Returns null if the user cancels.
        public static string ChooseSavePath(IWin32Window owner, AppealRecord record)
        {
            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.Title = "Save appeal";
                dialog.Filter = Filter;
                dialog.FileName = SuggestFileName(record);
                return dialog.ShowDialog(owner) == DialogResult.OK ? dialog.FileName : null;
            }
        }

        // Lets the user pick an appeal file and loads it.
        // Returns false if they cancel or the file isn't a valid appeal.
        public static bool TryOpen(IWin32Window owner, out AppealRecord record, out string path)
        {
            record = null;
            path = null;
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Title = "Open appeal";
                dialog.Filter = Filter;
                if (dialog.ShowDialog(owner) != DialogResult.OK)
                    return false;
                path = dialog.FileName;
            }

            try
            {
                record = Load(path);
                return true;
            }
            catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException || ex is InvalidOperationException)
            {
                // XmlSerializer throws InvalidOperationException for files that aren't appeals.
                MessageBox.Show(owner, "That file couldn't be opened as an appeal.\n\n" + ex.Message,
                    "Open appeal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Saves the appeal and tells the user if it fails. Returns true if the file was written.
        public static bool TrySave(IWin32Window owner, AppealRecord record, string path)
        {
            try
            {
                Save(record, path);
                return true;
            }
            catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException)
            {
                MessageBox.Show(owner, "The appeal couldn't be saved.\n\n" + ex.Message,
                    "Save appeal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Used by the step pages when they close with unsaved changes.
        // Returns true if the page is allowed to close.
        public static bool ConfirmClose(IWin32Window owner, string title, Func<bool> save)
        {
            DialogResult answer = MessageBox.Show(owner, "Save your changes before closing?", title,
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (answer == DialogResult.Cancel)
                return false;
            if (answer == DialogResult.Yes)
                return save();
            return true;
        }

        private static string SuggestFileName(AppealRecord record)
        {
            string name = "appeal " + record.StudentId + " " + record.CourseNumber;
            foreach (char c in Path.GetInvalidFileNameChars())
                name = name.Replace(c, '-');
            return name.Trim() + ".xml";
        }
    }
}
