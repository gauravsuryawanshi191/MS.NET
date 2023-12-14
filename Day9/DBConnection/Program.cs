using Microsoft.Data.SqlClient;
using System.Data;
namespace DBConnection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //connect1();
            //connect2();
            //insert1();
            Employee e0= new Employee();
            e0.EmpNo = 11;
            e0.Name = "Shivani";
            e0.Basic = 53000;
            e0.DeptNo = 30;
            //insert2();
            Employee e1 = new Employee();
            e1.EmpNo = 12;
            e1.Name = "Krupa";
            e1.Basic = 49000;
            e1.DeptNo = 10;
            //insert3(e1);
            //insert4(e1);
            Employee e2 = new Employee { EmpNo=12,Name="Shradha",Basic=49000,DeptNo=10};
            //update1(e2);
            //delete1(e2);
            //select1();
            //select2();
            select3();
        }
        static void connect1()
        {
            SqlConnection cn = new SqlConnection();
            //Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ActsDec2023;Integrated Security=True;
            //Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False
            cn.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ActsDec2023;Integrated Security=True";
            try
            {
                cn.Open();
                Console.WriteLine("Success!");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { cn.Close(); }
        }
        static void connect2()
        {
            using (SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ActsDec2023;Integrated Security=True";
                try
                {
                    cn.Open();
                    Console.WriteLine("Success!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }                       
        }

        static void insert1()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ActsDec2023;Integrated Security=True";
            try
            {
                cn.Open();
                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = cn;
                cmdInsert.CommandType = System.Data.CommandType.Text;
                cmdInsert.CommandText = "insert into Employees values(10,'Yugdeep',47000,20)";
                cmdInsert.ExecuteNonQuery();
                Console.WriteLine("Success!");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { cn.Close() ; }
        }
        static void insert2(Employee emp)//add Employee obj
        {
            
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ActsDec2023;Integrated Security=True";
            try
            {
                cn.Open();
                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = cn;
                cmdInsert.CommandType = System.Data.CommandType.Text;
                cmdInsert.CommandText = $"insert into Employees values({emp.EmpNo},'{emp.Name}',{emp.Basic},{emp.DeptNo})";
                cmdInsert.ExecuteNonQuery();
                Console.WriteLine("Success!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { cn.Close(); }
        }
        static void insert3(Employee emp)//add Employee obj using Params
        {
            
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ActsDec2023;Integrated Security=True";
            try
            {
                cn.Open();
                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = cn;
                cmdInsert.Parameters.AddWithValue("@EmpNo", emp.EmpNo);
                cmdInsert.Parameters.AddWithValue("@Name", emp.Name);
                cmdInsert.Parameters.AddWithValue("@Basic", emp.Basic);
                cmdInsert.Parameters.AddWithValue("@DeptNo", emp.DeptNo);
                cmdInsert.CommandType = System.Data.CommandType.Text;
                cmdInsert.CommandText = "insert into Employees values(@EmpNo,@Name,@Basic,@DeptNo)";
                cmdInsert.ExecuteNonQuery();
                Console.WriteLine("Success!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { cn.Close(); }
        }

        static void insert4(Employee emp)//Stored Procedure
        {
            using (SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ActsDec2023;Integrated Security=True";
                try
                {
                    cn.Open();
                    SqlCommand cmdInsert = new SqlCommand();
                    cmdInsert.Connection = cn;
                    cmdInsert.Parameters.AddWithValue("@EmpNo", emp.EmpNo);
                    cmdInsert.Parameters.AddWithValue("@Name", emp.Name);
                    cmdInsert.Parameters.AddWithValue("@Basic", emp.Basic);
                    cmdInsert.Parameters.AddWithValue("@DeptNo", emp.DeptNo);
                    cmdInsert.CommandType = System.Data.CommandType.StoredProcedure;
                    cmdInsert.CommandText = "InsertEmployee";
                    cmdInsert.ExecuteNonQuery();
                    Console.WriteLine("Success!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        static void update1(Employee emp)
        {
            using (SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ActsDec2023;Integrated Security=True";
                try
                {
                    cn.Open();
                    SqlCommand cmdUpdate = new SqlCommand();
                    cmdUpdate.Connection = cn;
                    cmdUpdate.Parameters.AddWithValue("@EmpNo", emp.EmpNo);
                    cmdUpdate.Parameters.AddWithValue("@Name", emp.Name);
                    cmdUpdate.Parameters.AddWithValue("@Basic", emp.Basic);
                    cmdUpdate.Parameters.AddWithValue("@DeptNo", emp.DeptNo);
                    cmdUpdate.CommandType = System.Data.CommandType.StoredProcedure;
                    cmdUpdate.CommandText = "UpdateEmployee";
                    cmdUpdate.ExecuteNonQuery();
                    Console.WriteLine("Success!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        static void delete1(Employee emp)
        {
            using (SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ActsDec2023;Integrated Security=True";
                try
                {
                    cn.Open();
                    SqlCommand cmdDelete = new SqlCommand();
                    cmdDelete.Connection = cn;
                    cmdDelete.Parameters.AddWithValue("@EmpNo", emp.EmpNo);
                    cmdDelete.CommandType = System.Data.CommandType.StoredProcedure;
                    cmdDelete.CommandText = "DeleteEmployee";
                    cmdDelete.ExecuteNonQuery();
                    Console.WriteLine("Success!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        static void select1()//select ExecuteScalar
        {
        using (SqlConnection cn = new SqlConnection())
        {
            cn.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ActsDec2023;Integrated Security=True";
                try
                {
                    cn.Open();
                    SqlCommand cmdSelect = new SqlCommand();
                    cmdSelect.Connection = cn;
                    cmdSelect.CommandType = System.Data.CommandType.Text;
                    cmdSelect.CommandText = "select Name from Employees where EmpNo=1";
                    object retval= cmdSelect.ExecuteScalar();
                    Console.WriteLine("Success!");
                    Console.WriteLine(retval);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        static void select2() //SQLDataReader
        {
            using (SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ActsDec2023;Integrated Security=True";
                try
                {
                    cn.Open();
                    SqlCommand cmdSelect = new SqlCommand();
                    cmdSelect.Connection = cn;
                    cmdSelect.CommandType = System.Data.CommandType.Text;
                    cmdSelect.CommandText = "select * from Employees";
                    Console.WriteLine("Success!");
                    SqlDataReader dr= cmdSelect.ExecuteReader();
                    while (dr.Read())
                    {
                        Console.WriteLine(dr["Name"]);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        static void select3() //SQLDataReader dr-to-Emp obj 
        {
            Employee obj = new Employee();
            using (SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ActsDec2023;Integrated Security=True";
                try
                {
                    cn.Open();
                    SqlCommand cmdSelect = new SqlCommand();
                    cmdSelect.Connection = cn;
                    cmdSelect.CommandType = System.Data.CommandType.Text;
                    cmdSelect.CommandText = "select * from Employees where EmpNo=1";
                    Console.WriteLine("Success!");
                    SqlDataReader dr = cmdSelect.ExecuteReader();
                    if (dr.HasRows)
                    {
                        obj.EmpNo = dr.GetInt32("EmpNo");
                        obj.Name= dr.GetString("Name");
                        obj.Basic = dr.GetDecimal("Basic");
                        obj.DeptNo = dr.GetInt32("DeptNo");
                    }
                    Console.WriteLine(obj);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

    }
    public class Employee
    {
        public int EmpNo { get; set; }
        public string Name { get; set; }
        public decimal Basic { get; set; }
        public int DeptNo { get; set; }

        public override string? ToString()
        {
            return "EmpNo:"+EmpNo + " Name:" + Name + " Basic:" + Basic + " DeptNo:" + DeptNo;
        }
    }
}