using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebAppWood.Models
{
    public class ModelUser
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int Role { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastLogin { get; set; }
        SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

        public void CreateUser(ModelUser user)
        {
            SqlCommand ins = new SqlCommand();
            ins.CommandText = "insert into Users(Username,Password,Email,Role,Created,LastLogin)" +
                "values(@Username,@Password,@Email,@Role,@Created,@LastLogin)";
            ins.Parameters.AddWithValue("@Username", user.Username);
            ins.Parameters.AddWithValue("@Password", user.Password);
            ins.Parameters.AddWithValue("@Role", user.Role);
            ins.Parameters.AddWithValue("@Email", user.Email);
            ins.Parameters.AddWithValue("@Created", DateTime.Now);
            ins.Parameters.AddWithValue("@LastLogin", DateTime.Now);
            ins.Connection = connection;
            connection.Open();
            ins.ExecuteNonQuery();
            connection.Close();
        }
        public bool ValidateAdmin(string Username)
        {
            SqlCommand sel = new SqlCommand("Select Role from Users where Username=@Username and Role='Admin'");
            sel.Parameters.AddWithValue("@Username", Username);
            sel.Connection = connection;
            connection.Open();
            SqlDataReader read = sel.ExecuteReader();
            if (read.HasRows)
            {
                while (read.Read())
                {
                    return true;
                }            
            }
            connection.Close();
            return false;
        }
        public void ModifyUser(ModelUser user)
        {
            SqlCommand ins = new SqlCommand();
            ins.CommandText = "update Users set Email=@Email,Name=@Name,Password=@Password,Role=@Role where Username=@Username";
            ins.Parameters.AddWithValue("@Username", user.Username);
            ins.Parameters.AddWithValue("@Email", user.Email);
            ins.Parameters.AddWithValue("@Password", user.Password);
            ins.Parameters.AddWithValue("@Role", user.Role);
            ins.Connection = connection;
            connection.Open();
            ins.ExecuteNonQuery();
            connection.Close();
        }
        public ModelUser GetUser(ModelUser user)
        {
            SqlCommand sel = new SqlCommand("select * from Users where Username=@Username");
            sel.Parameters.AddWithValue("@Username", user.Username);
            sel.Connection = connection;
            connection.Open();
            SqlDataReader read = sel.ExecuteReader();
            if (read.HasRows)
            {
                while (read.Read())
                {
                    user.ID = Convert.ToInt32(read["Username"]);
                    user.Username = (read["Username"]).ToString();
                    user.Name = (read["Name"]).ToString();
                    user.Email = (read["Email"]).ToString();
                    user.Role = Convert.ToInt32(read["Role"]);
                    user.Created = Convert.ToDateTime(read["Created"]);
                    user.LastLogin = Convert.ToDateTime(read["LastLogin"]);
                }
            }
            connection.Close();
            return user;
        }
        public bool ValidatePassword(string Username, string Password) {
            string Compare = "";
            SqlCommand sel = new SqlCommand("Select Pass From Users where Username=@Username");
            sel.Parameters.AddWithValue("@Username",Username);
            sel.Connection = connection;
            connection.Open();
            SqlDataReader read = sel.ExecuteReader();
            if (read.HasRows)
                while (read.Read()) {
                    Compare = read["Pass"].ToString();
                    if (Password.Equals(Compare))
                    {
                        return true;
                    }
                }
            connection.Close();
            return false;
        }
    }
}