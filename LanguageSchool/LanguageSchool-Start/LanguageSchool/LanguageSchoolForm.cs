using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LanguageSchool.ServiceReference;



namespace LanguageSchool
{
    public partial class LanguageSchoolForm : Form, ILanguageSchoolCallback
    {
        private LanguageSchoolClient proxy;

        public LanguageSchoolForm()
        {
            InitializeComponent();
            proxy = new LanguageSchoolClient(new InstanceContext(this));
            if (proxy != null) proxy.Subscribe();
        }

        private void ShowNotification(string notification)
        {
            lbNotifications.Items.Add(notification);
        }

        private void BtnNrCourses_Click(object sender, EventArgs e)
        {
            ShowNotification("The number of courses is: " + proxy.GetNrOfCourses().ToString());
        }

        private void BtnCoursesList_Click(object sender, EventArgs e)
        {
            List<Course> courses = proxy.GetCoursesList();
            foreach (Course course in courses)
            {
                lbName.Items.Add(course.CourseName);
                lbCapacity.Items.Add(course.ClassCapacity);
            }
        }

        private void BtnTeacher_Click(object sender, EventArgs e)
        {
            string teacherName = proxy.GetTeacherName(tbCourseName.Text);
            string result;
            if (teacherName != null) result = "Teacher of the course " + tbCourseName.Text + " is " + teacherName;
            else result = "No such course!";
            ShowNotification(result);
        }

        private void BtnSignIn_Click(object sender, EventArgs e)
        {
            string courseName = (string)lbName.SelectedItem;
            string result;
            if (proxy.CourseSignIn(courseName)) result = "You successfully signed in for ";
            else result = "You cannot sign in for ";
            result += courseName;
            ShowNotification(result);
        }

        private void LanguageSchoolForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            proxy.Unsubscribe();
        }

        public void Notify(string courseName)
        {
            ShowNotification(courseName);
        }
    }
}
