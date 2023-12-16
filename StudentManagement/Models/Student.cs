using Microsoft.Data.SqlClient;
using System.Data;
namespace StudentManagement.Models
{
    public class Student
    {
        public int RollId { get; set; }
        public string Name { get; set; }
        public decimal Marks { get; set; }
        public string Branch { get; set; }

        public static List<Student> getAll()
        {
            List<Student> list = new List<Student>();
            SqlConnection cn = new SqlConnection();
            //Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ActsDec2023;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ActsDec2023;Integrated Security=True";
            try
            {
                cn.Open();
                SqlCommand cmdselect = new SqlCommand();
                cmdselect.Connection = cn;
                cmdselect.CommandType = System.Data.CommandType.Text;
                cmdselect.CommandText = "select * from Students";
                SqlDataReader dr = cmdselect.ExecuteReader();
                while (dr.Read())
                {
                    list.Add(new Student
                    {
                        RollId = dr.GetInt32("RollId"),
                        Name = dr.GetString("Name"),
                        Marks = dr.GetDecimal("Marks"),
                        Branch = dr.GetString("BranchABV")
                    });
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally { cn.Close(); }
            return list;
        }
        public static Student getStudent(int rollId)
        {
            Student obj = new Student();
            using (SqlConnection cn = new SqlConnection())
            {
                //Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ActsDec2023;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False
                cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ActsDec2023;Integrated Security=True";
                try
                {
                    cn.Open();
                    SqlCommand cmdselect = new SqlCommand();
                    cmdselect.Connection = cn;
                    cmdselect.Parameters.AddWithValue("@RollId", rollId);
                    cmdselect.CommandType = System.Data.CommandType.StoredProcedure;
                    cmdselect.CommandText = "SelectStudent";
                    SqlDataReader dr = cmdselect.ExecuteReader();
                    if (dr.Read())
                    {
                        obj.RollId = dr.GetInt32("RollId");
                        obj.Name = dr.GetString("Name");
                        obj.Marks = dr.GetDecimal("Marks");
                        obj.Branch = dr.GetString("BranchABV");
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                return obj;
            }
        }
        public static void updateStudent(Student obj)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ActsDec2023;Integrated Security=True";
            try
            {
                cn.Open();
                SqlCommand cmdUpdate = new SqlCommand();
                cmdUpdate.Connection = cn;
                cmdUpdate.Parameters.AddWithValue("@RollId", obj.RollId);
                cmdUpdate.Parameters.AddWithValue("@Name", obj.Name);
                cmdUpdate.Parameters.AddWithValue("@Marks", obj.Marks);
                cmdUpdate.Parameters.AddWithValue("@BranchABV", obj.Branch);
                cmdUpdate.CommandType = System.Data.CommandType.StoredProcedure;
                cmdUpdate.CommandText = "UpdateStudent";
                cmdUpdate.ExecuteNonQuery();                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { cn.Close(); }
            {

            }
        }
        public static void deleteStudent(int rollId)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ActsDec2023;Integrated Security=True";
            try
            {
                cn.Open();
                SqlCommand cmdDelete = new SqlCommand();
                cmdDelete.Connection = cn;
                cmdDelete.Parameters.AddWithValue("@RollId", rollId);
                cmdDelete.CommandType = System.Data.CommandType.StoredProcedure;
                cmdDelete.CommandText = "DeleteStudent";
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { cn.Close(); }
        }
        public static void addStudent(Student obj)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ActsDec2023;Integrated Security=True";
            try
            {
                cn.Open();
                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = cn;
                cmdInsert.Parameters.AddWithValue("@RollId", obj.RollId);
                cmdInsert.Parameters.AddWithValue("@Name", obj.Name);
                cmdInsert.Parameters.AddWithValue("@Marks", obj.Marks);
                cmdInsert.Parameters.AddWithValue("@BranchABV", obj.Branch);
                cmdInsert.CommandType = System.Data.CommandType.StoredProcedure;
                cmdInsert.CommandText = "InsertStudent";
                cmdInsert.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { cn.Close(); }
        }
    } 

}
