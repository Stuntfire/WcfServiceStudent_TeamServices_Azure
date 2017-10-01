using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfServiceStudent_TeamServices_Azure
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class ServiceService : IServiceStudent
    {
        //Forbindelse til Student Databasen på Azure.
        private const string conn =
            "Server=tcp:hotelserver01.database.windows.net,1433;Initial Catalog=HotelDB;Persist Security Info=False;User ID=sailor;Password=ZAQ12wsx;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        string CreateStudent = "INSERT INTO Student (Id, Name, Klasse) VALUES (@id, @name, @klasse)";




        public IList<Student> GetAllStudents()
        {
            List<Student> localStudentsList = new List<Student>();

            string SelectAllStudent = "SELECT * FROM Student";

            using (SqlConnection databasesConnection = new SqlConnection(conn))
            {
                SqlCommand command = new SqlCommand(SelectAllStudent, databasesConnection);

                databasesConnection.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    localStudentsList.Add(new Student() { Id = reader.GetInt32(0), Name = reader.GetString(1), Klasse = reader.GetString(2) });
                }
                return localStudentsList;
            }
        }

        public Student GetStudentById(int id)
        {
            Student localStudent = new Student();

            string SelectStudentById = "SELECT * FROM Student WHERE Id = @id";

            using (SqlConnection databasesConnection = new SqlConnection(conn))
            {
                SqlCommand command = new SqlCommand(SelectStudentById, databasesConnection);
                command.Parameters.AddWithValue("@id", id);

                databasesConnection.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    localStudent = new Student() { Id = reader.GetInt32(0), Name = reader.GetString(1), Klasse = reader.GetString(2) };
                }
                return localStudent;

            }
        }
    }
}
