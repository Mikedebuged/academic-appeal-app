namespace AcademicAppeal
{
    partial class InstructorForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.outcomeBox = new System.Windows.Forms.RichTextBox();
            this.doneButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(64, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(248, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Step 2: Instructor or Open Learning Faculty Member";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(64, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(551, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Describe the outcome of your communication with this individual and/or attached c" +
    "opies of related communications.";
            // 
            // outcomeBox
            // 
            this.outcomeBox.Location = new System.Drawing.Point(67, 53);
            this.outcomeBox.Name = "outcomeBox";
            this.outcomeBox.Size = new System.Drawing.Size(504, 204);
            this.outcomeBox.TabIndex = 1;
            this.outcomeBox.Text = "";
            // 
            // doneButton
            // 
            this.doneButton.Location = new System.Drawing.Point(542, 294);
            this.doneButton.Name = "doneButton";
            this.doneButton.Size = new System.Drawing.Size(124, 25);
            this.doneButton.TabIndex = 4;
            this.doneButton.Text = "Done";
            this.doneButton.UseVisualStyleBackColor = true;
            this.doneButton.Click += new System.EventHandler(this.doneButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(335, 294);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(124, 25);
            this.saveButton.TabIndex = 2;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // InstructorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 351);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.doneButton);
            this.Controls.Add(this.outcomeBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "InstructorForm";
            this.Text = "Step 2: Instructor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox outcomeBox;
        private System.Windows.Forms.Button doneButton;
        private System.Windows.Forms.Button saveButton;
    }
}