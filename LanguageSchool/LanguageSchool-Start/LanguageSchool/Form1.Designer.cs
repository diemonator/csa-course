namespace LanguageSchool
{
    partial class Form1
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
            this.btnNrCourses = new System.Windows.Forms.Button();
            this.lbCapacity = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.lbName = new System.Windows.Forms.ListBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tbCourseName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnTeacher = new System.Windows.Forms.Button();
            this.btnCoursesList = new System.Windows.Forms.Button();
            this.btnSignIn = new System.Windows.Forms.Button();
            this.lbNotifications = new System.Windows.Forms.ListBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnNrCourses
            // 
            this.btnNrCourses.Location = new System.Drawing.Point(12, 22);
            this.btnNrCourses.Name = "btnNrCourses";
            this.btnNrCourses.Size = new System.Drawing.Size(149, 23);
            this.btnNrCourses.TabIndex = 0;
            this.btnNrCourses.Text = "Get Number of Courses";
            this.btnNrCourses.UseVisualStyleBackColor = true;
            // 
            // lbCapacity
            // 
            this.lbCapacity.FormattingEnabled = true;
            this.lbCapacity.Location = new System.Drawing.Point(208, 23);
            this.lbCapacity.Name = "lbCapacity";
            this.lbCapacity.ScrollAlwaysVisible = true;
            this.lbCapacity.Size = new System.Drawing.Size(115, 82);
            this.lbCapacity.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(205, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "course capacity";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lbName);
            this.panel1.Controls.Add(this.lbCapacity);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(174, 188);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(345, 114);
            this.panel1.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "course name";
            // 
            // lbName
            // 
            this.lbName.FormattingEnabled = true;
            this.lbName.Location = new System.Drawing.Point(3, 23);
            this.lbName.Name = "lbName";
            this.lbName.ScrollAlwaysVisible = true;
            this.lbName.Size = new System.Drawing.Size(199, 82);
            this.lbName.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.tbCourseName);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.btnTeacher);
            this.panel2.Location = new System.Drawing.Point(12, 61);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(203, 65);
            this.panel2.TabIndex = 6;
            // 
            // tbCourseName
            // 
            this.tbCourseName.Location = new System.Drawing.Point(105, 6);
            this.tbCourseName.Name = "tbCourseName";
            this.tbCourseName.Size = new System.Drawing.Size(82, 20);
            this.tbCourseName.TabIndex = 2;
            this.tbCourseName.Text = "tbCourseName";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "enter course code:";
            // 
            // btnTeacher
            // 
            this.btnTeacher.Location = new System.Drawing.Point(6, 32);
            this.btnTeacher.Name = "btnTeacher";
            this.btnTeacher.Size = new System.Drawing.Size(142, 23);
            this.btnTeacher.TabIndex = 0;
            this.btnTeacher.Text = "Get Teacher Name";
            this.btnTeacher.UseVisualStyleBackColor = true;
            // 
            // btnCoursesList
            // 
            this.btnCoursesList.Location = new System.Drawing.Point(12, 186);
            this.btnCoursesList.Name = "btnCoursesList";
            this.btnCoursesList.Size = new System.Drawing.Size(149, 23);
            this.btnCoursesList.TabIndex = 7;
            this.btnCoursesList.Text = "Get Courses List";
            this.btnCoursesList.UseVisualStyleBackColor = true;
            // 
            // btnSignIn
            // 
            this.btnSignIn.Location = new System.Drawing.Point(12, 215);
            this.btnSignIn.Name = "btnSignIn";
            this.btnSignIn.Size = new System.Drawing.Size(149, 23);
            this.btnSignIn.TabIndex = 8;
            this.btnSignIn.Text = "Sign in for selected Course";
            this.btnSignIn.UseVisualStyleBackColor = true;
            // 
            // lbNotifications
            // 
            this.lbNotifications.FormattingEnabled = true;
            this.lbNotifications.Location = new System.Drawing.Point(230, 9);
            this.lbNotifications.Name = "lbNotifications";
            this.lbNotifications.ScrollAlwaysVisible = true;
            this.lbNotifications.Size = new System.Drawing.Size(289, 173);
            this.lbNotifications.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 314);
            this.Controls.Add(this.lbNotifications);
            this.Controls.Add(this.btnSignIn);
            this.Controls.Add(this.btnCoursesList);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnNrCourses);
            this.Name = "Form1";
            this.Text = "School Client";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnNrCourses;
        private System.Windows.Forms.ListBox lbCapacity;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lbName;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnTeacher;
        private System.Windows.Forms.TextBox tbCourseName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnCoursesList;
        private System.Windows.Forms.Button btnSignIn;
        private System.Windows.Forms.ListBox lbNotifications;
    }
}

