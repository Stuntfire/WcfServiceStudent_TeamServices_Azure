using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfServiceStudent_TeamServices_Azure
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IServiceStudent
    {
        [OperationContract]
        IList<Student> GetAllStudents();

        [OperationContract]
        Student GetStudentById(int id);
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class Student
    {
        public Student()
        {

        }
        private int id;
        [DataMember]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string name;
        [DataMember]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string klasse;
        [DataMember]
        public string Klasse
        {
            get { return klasse; }
            set { klasse = value; }
        }


    }
}
