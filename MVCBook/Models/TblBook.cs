using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace MVCBook.Models;

public partial class TblBook
{
    public int BookId { get; set; }

    public string BookName { get; set; } = null!;

    public string BookAuthor { get; set; } = null!;

    public decimal BookPrice { get; set; }

    //public void addBook(TblBook obj)
    //{
    //    SqlConnection sqlConnection = new SqlConnection();
    //    sqlConnection.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BookDB;Integrated Security=True";
    //    sqlConnection.Open();
    //    SqlCommand cmd = sqlConnection.CreateCommand();
    //    cmd.Connection=sqlConnection;
    //    cmd.CommandType=System.Data.CommandType.Text;
    //    cmd.CommandText="insert into Books values(@obj.BookName)"
    //}
}
