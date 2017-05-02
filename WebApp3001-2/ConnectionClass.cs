using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Configuration;
using System.Data.SqlClient;

namespace WebApp3001_2
{
    public class ConnectionClass
    {
        private static SqlConnection conn;
        private static SqlCommand command;

        static ConnectionClass()
        {
            string connectionString =
                ConfigurationManager.ConnectionStrings["MetalsConnection"].ToString();
            conn = new SqlConnection(connectionString);
            command = new SqlCommand("", conn);
        }

        public static ArrayList GetMetalsByType(string metalsType)
        {
            ArrayList list = new ArrayList();
            string query = string.Format("SELECT * FROM Metali WHERE type LIKE '{0}'", metalsType);

            try
            {
                conn.Open();
                command.CommandText = query;
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string type = reader.GetString(1);
                    double price = reader.GetDouble(2);
                    string weight = reader.GetString(3);
                    string image = reader.GetString(4);

                    Metals metals = new Metals(id, type, price, weight, image);
                    list.Add(metals);
                }
            }
            finally
            {
                conn.Close();
            }

            return list;
        }

        public static void AddMetal(Metals metals)
        {
            string query = string.Format("INSERT INTO metali VALUES ('{0}',@price,'{1}','{2}')", metals.Type, metals.Weight, metals.Image);
            command.CommandText = query;

            command.Parameters.Add(new SqlParameter("price", metals.Price));
            try
            {
                conn.Open();
                command.ExecuteNonQuery();
            }
            finally 
            {
                conn.Close();
                command.Parameters.Clear();
            }
            
        }

        public static User LoginUser(string name, string password)
        { 
            //Check if user exists
        string query = string.Format("SELECT COUNT(*) FROM Metali.dbo.users WHERE name = '{0}'", name);
        command.CommandText = query;

        try
        {
            conn.Open();
            int amountOfUsers = (int)command.ExecuteScalar();

            if (amountOfUsers == 1)
            {
                //User exists, check if the passwords match
                query = string.Format("SELECT password FROM users WHERE name = '{0}'", name);
                command.CommandText = query;
                string dbPassword = command.ExecuteScalar().ToString();

                if (dbPassword == password)
                {
                    //Passwords match. Login and password data are known to us.
                    //Retrieve further user data from the database
                    query = string.Format("SELECT email, user_type FROM users WHERE name = '{0}'", name);
                    command.CommandText = query;

                    SqlDataReader reader = command.ExecuteReader();
                    User user = null;

                    while (reader.Read())
                    {
                        string email = reader.GetString(0);
                        string type = reader.GetString(1);

                        user = new User(name, password, email, type);
                    }
                    return user;
                }
                else
                {
                    //Passwords do not match
                    return null;
                }
            }
            else
            {
                //User does not exist
                return null;
            }
        }
        finally
        {

            conn.Close();
        }
    }

        public static string RegisterUser(User user)
        {
            //Check if user exists
            string query = string.Format("SELECT COUNT(*) FROM users WHERE name = '{0}'", user.Name);
            command.CommandText = query;

            try
            {
                conn.Open();
                int amountOfUsers = (int)command.ExecuteScalar();

                if (amountOfUsers < 1)
                {
                    //User does not exist, create a new user
                    query = string.Format("INSERT INTO users VALUES ('{0}', '{1}', '{2}', '{3}')", user.Name, user.Password,
                                          user.Email, user.Type);
                    command.CommandText = query;
                    command.ExecuteNonQuery();
                    return "User registered!";
                }
                else
                {
                    //User exists
                    return "A user with this name already exists";
                }
            }
            finally
            {
                conn.Close();
            }
        }

        }
    }
