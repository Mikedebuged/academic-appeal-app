namespace AcademicAppeal
{
    partial class AdminForm
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
            this.studentPageButton = new System.Windows.Forms.Button();
            this.instructorPageButton = new System.Windows.Forms.Button();
            this.chairPageButton = new System.Windows.Forms.Button();
            this.deanPageButton = new System.Windows.Forms.Button();
            this.newFormButton = new System.Windows.Forms.Button();
            this.titleLabel = new System.Windows.Forms.Label();
            this.openButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // studentPageButton
            // 
            this.studentPageButton.Location = new System.Drawing.Point(313, 135);
            this.studentPageButton.Name = "studentPageButton";
            this.studentPageButton.Size = new System.Drawing.Size(150, 23);
            this.studentPageButton.TabIndex = 0;
            this.studentPageButton.Text = "Student page";
            this.studentPageButton.UseVisualStyleBackColor = true;
            this.studentPageButton.Click += new System.EventHandler(this.studentPageButton_Click);
            // 
            // instructorPageButton
            // 
            this.instructorPageButton.Location = new System.Drawing.Point(313, 163);
            this.instructorPageButton.Name = "instructorPageButton";
            this.instructorPageButton.Size = new System.Drawing.Size(150, 24);
            this.instructorPageButton.TabIndex = 1;
            this.instructorPageButton.Text = "Instructor page";
            this.instructorPageButton.UseVisualStyleBackColor = true;
            this.instructorPageButton.Click += new System.EventHandler(this.instructorPageButton_Click);
            // 
            // chairPageButton
            // 
            this.chairPageButton.Location = new System.Drawing.Point(313, 193);
            this.chairPageButton.Name = "chairPageButton";
            this.chairPageButton.Size = new System.Drawing.Size(150, 24);
            this.chairPageButton.TabIndex = 3;
            this.chairPageButton.Text = "Chair\'s page";
            this.chairPageButton.UseVisualStyleBackColor = true;
            this.chairPageButton.Click += new System.EventHandler(this.chairPageButton_Click);
            // 
            // deanPageButton
            // 
            this.deanPageButton.Location = new System.Drawing.Point(313, 223);
            this.deanPageButton.Name = "deanPageButton";
            this.deanPageButton.Size = new System.Drawing.Size(150, 23);
            this.deanPageButton.TabIndex = 4;
            this.deanPageButton.Text = "Dean\'s page";
            this.deanPageButton.UseVisualStyleBackColor = true;
            this.deanPageButton.Click += new System.EventHandler(this.deanPageButton_Click);
            // 
            // newFormButton
            // 
            this.newFormButton.Location = new System.Drawing.Point(178, 83);
            this.newFormButton.Name = "newFormButton";
            this.newFormButton.Size = new System.Drawing.Size(150, 22);
            this.newFormButton.TabIndex = 10;
            this.newFormButton.Text = "New appeal";
            this.newFormButton.UseVisualStyleBackColor = true;
            this.newFormButton.Click += new System.EventHandler(this.newFormButton_Click);
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(322, 25);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(141, 26);
            this.titleLabel.TabIndex = 11;
            this.titleLabel.Text = "ADMIN PAGE";
            // 
            // openButton
            // 
            this.openButton.Location = new System.Drawing.Point(456, 83);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(150, 22);
            this.openButton.TabIndex = 12;
            this.openButton.Text = "Open appeal";
            this.openButton.UseVisualStyleBackColor = true;
            this.openButton.Click += new System.EventHandler(this.openButton_Click);
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 337);
            this.Controls.Add(this.openButton);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.newFormButton);
            this.Controls.Add(this.deanPageButton);
            this.Controls.Add(this.chairPageButton);
            this.Controls.Add(this.instructorPageButton);
            this.Controls.Add(this.studentPageButton);
            this.Name = "AdminForm";
            this.Text = "Student Academic Appeal";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button studentPageButton;
        private System.Windows.Forms.Button instructorPageButton;
        private System.Windows.Forms.Button chairPageButton;
        private System.Windows.Forms.Button deanPageButton;
        private System.Windows.Forms.Button newFormButton;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Button openButton;
    }
}