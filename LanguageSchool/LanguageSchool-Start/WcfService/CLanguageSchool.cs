using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WcfService.Models;

namespace WcfService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Reentrant)]
    public class CLanguageSchool : ILanguageSchool
    {
        private List<IMyEvent> callbacks;
        private List<Course> courses;
        private Action<string> myEvent;

        public CLanguageSchool()
        {
            callbacks = new List<IMyEvent>();
            courses = new List<Course>()
            {
                new Course("English", 5, 2, "Erik"),
                new Course("Dutch", 6, 3, "Stan"),
                new Course("Spanish", 8, 4, "Hose")
            };
            myEvent = delegate { };
        }

        public bool CourseSignIn(string courseName)
        {
            Course selectedCourse = GetCourse(courseName);
            if (selectedCourse.NrOfPariticipants < selectedCourse.ClassCapacity)
            {
                selectedCourse.NrOfPariticipants++;
                if (selectedCourse.NrOfPariticipants == selectedCourse.ClassCapacity)
                {
                    IMyEvent myEvent = OperationContext.Current.GetCallbackChannel<IMyEvent>();
                    foreach (IMyEvent callback in callbacks)
                    {
                        if (callback != myEvent) callback.Notify("The course " + selectedCourse.CourseName + " is full!");
                    }
                }
                return true;
            }
            return false;
        }

        public List<Course> GetCoursesList()
        {
            return courses;
        }

        public int GetNrOfCourses()
        {
            return courses.Count;
        }

        public string GetTeacherName(string courseName)
        {
            return GetCourse(courseName).TeacherName;
        }

        public void Subscribe()
        {
            IMyEvent myEvent = OperationContext.Current.GetCallbackChannel<IMyEvent>();
            if (!callbacks.Contains(myEvent))
            { 
                callbacks.Add(myEvent);
                this.myEvent += myEvent.Notify;
            }
        }

        public void Unsubscribe()
        {
            IMyEvent myEvent = OperationContext.Current.GetCallbackChannel<IMyEvent>();
            callbacks.Remove(myEvent);
            this.myEvent -= myEvent.Notify;
        }

        private Course GetCourse(string courseName)
        {
            return courses.Find(x => x.CourseName == courseName);
        }
    }
}
