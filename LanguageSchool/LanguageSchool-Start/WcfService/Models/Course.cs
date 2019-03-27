using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WcfService.Models
{
    [DataContract]
    public class Course
    {
        [DataMember]
        public string CourseName { get; set; }
        [DataMember]
        public int ClassCapacity { get; set; }

        public int NrOfPariticipants { get; set; }

        public string TeacherName { get; set; }

        public Course(string courseName, int classCapacity, int nrOfPariticipants, string teacherName)
        {
            CourseName = courseName;
            ClassCapacity = classCapacity;
            NrOfPariticipants = nrOfPariticipants;
            TeacherName = teacherName;
        }
    }
}
