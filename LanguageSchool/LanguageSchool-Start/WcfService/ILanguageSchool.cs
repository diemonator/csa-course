using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WcfService.Models;

namespace WcfService
{
    [ServiceContract(CallbackContract = typeof(IMyEvent))]
    public interface ILanguageSchool
    {
        [OperationContract]
        int GetNrOfCourses();
        [OperationContract]
        string GetTeacherName(string courseName);
        [OperationContract]
        List<Course> GetCoursesList();
        [OperationContract]
        bool CourseSignIn(string courseName);
        [OperationContract(IsOneWay = true)]
        void Subscribe();
        [OperationContract(IsOneWay = true)]
        void Unsubscribe();
    }

    interface IMyEvent
    {
        [OperationContract(IsOneWay = true)]
        void Notify(string courseName);
    }

}
