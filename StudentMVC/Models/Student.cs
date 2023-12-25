using Humanizer;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using Microsoft.Data.SqlClient;
using NuGet.Protocol.Plugins;

using static System.Runtime.InteropServices.JavaScript.JSType;

using System.Drawing;

using System.Net;
using System.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace StudentMVC.Models
{
    public class Student
    {
        [Key]
        [DisplayName("StudentId")]
        public int StudentNo { get; set; }
        [Required(ErrorMessage = "Name Required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Section Required")]
        public string Section { get; set; }
        [Required(ErrorMessage = "Branch Required")]
        public string Branch { get; set; }
        [Required(ErrorMessage ="Email Required")]
        public string EmailId { get; set; } 

        public static void saveStudent(Student obj)
        {
            using (SqlConnection cn = new SqlConnection()){
                cn.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=StudentMVCDB;Integrated Security=True";
                try
                {
                    cn.Open();
                    SqlCommand cmd = cn.CreateCommand();
                    cmd.Connection = cn;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Parameters.AddWithValue("@Name", obj.Name);
                    cmd.Parameters.AddWithValue("@Section", obj.Section);
                    cmd.Parameters.AddWithValue("@Branch", obj.Branch);
                    cmd.Parameters.AddWithValue("@EmailId", obj.EmailId);
                    cmd.CommandText = "insert into Students(Name,Section,Branch,EmailId) values (@Name,@Section,@Branch,@EmailId)";
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw;
                }
            }     
        }
        public static List<Student> getAllStudents()
        {
            List<Student> studentList = new List<Student>();
            using (SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=StudentMVCDB;Integrated Security=True";
                try
                {
                    cn.Open();
                    SqlCommand cmd = cn.CreateCommand();
                    cmd.Connection = cn;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "select * from Students";
                    SqlDataReader dr= cmd.ExecuteReader();
                    while(dr.Read())
                    {
                        studentList.Add(new Student
                        {
                            StudentNo = dr.GetInt32("StudentNo"),
                            Name = dr.GetString("Name"),
                            Section = dr.GetString("Section"),
                            Branch = dr.GetString("Branch"),
                            EmailId= dr.GetString("EmailId")
                        });
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return studentList;
        }
        public static Student getStudentDetails(int id)
        {
            Student student = new Student();
            using (SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=StudentMVCDB;Integrated Security=True";
                try
                {
                    cn.Open();
                    SqlCommand cmd = cn.CreateCommand();
                    cmd.Connection = cn;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "select * from Students";
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        student.StudentNo = dr.GetInt32("StudentNo");
                        student.Name = dr.GetString("Name");
                        student.Section = dr.GetString("Section");
                        student.Branch = dr.GetString("Branch");
                        student.EmailId = dr.GetString("EmailId");
                }
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return student;

        }
        public static void deleteStudent(int StudentNo)
        {
            using (SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=StudentMVCDB;Integrated Security=True";
                try
                {
                    cn.Open();
                    SqlCommand cmd = cn.CreateCommand();
                    cmd.Connection = cn;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Parameters.AddWithValue("@StudentNo", StudentNo);
                    cmd.CommandText = "delete Students where StudentNo=@StudentNo";
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }
    }
}

