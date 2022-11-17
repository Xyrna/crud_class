using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace crud_class
{
    internal class DAL
    {
        private static SqlConnection connection = new SqlConnection("Server=DESKTOP-2QKN505\\SQLEXPRESS; Database=Northwind; Integrated Security=true;");

        static public bool CreateUser(string name)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                SqlCommand insert = new SqlCommand("INSERT INTO Users(Name) VALUES(@name);", connection);
                insert.Parameters.AddWithValue("@name", name);
                insert.ExecuteNonQuery();
                connection.Close();
                return true;

            }
            catch
            {
                return false;
            }
        }

        static public bool UpdateUser(string id, string name)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                SqlCommand update = new SqlCommand("UPDATE Users SET Name=@name WHERE ID=@ID", connection);
                update.Parameters.AddWithValue("@ID", id);
                update.Parameters.AddWithValue("@name", name);
                update.ExecuteNonQuery();

                connection.Close();
                return true;


            }
            catch
            {
                return false;
            }

        }

        static public bool DeleteUser(string id)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                SqlCommand delete = new SqlCommand("DELETE FROM Users WHERE ID=@ID", connection);
                delete.Parameters.AddWithValue("@ID", id);
                delete.ExecuteNonQuery();

                connection.Close();
                return true;

            }
            catch
            {
                return false;
            }
        }
        static public DataView SelectUser()
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                SqlCommand select = new SqlCommand("SELECT * FROM Users;", connection);
                SqlDataAdapter adapter = new SqlDataAdapter(select);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                connection.Close();
                return dt.DefaultView;

            }
            catch
            {
                return null;
            }
        }
    }
}
