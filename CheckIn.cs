using Microsoft.VisualBasic.FileIO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel
{
    internal class CheckIn
    {
        string firstName;
        string lastName;
        string address;
        string phoneNumber;
        MySqlConnection connection;
        public CheckIn(MySqlConnection Connection)
        {
            connection = Connection;
            connection.Open();
        }
        public void AddUser()
        {

            Console.Write("Enter First Name:");
            firstName = Console.ReadLine();
            Console.Clear();

            Console.Write("Enter Last Name:");
            lastName = Console.ReadLine();
            Console.Clear();

            Console.Write("Enter Address Name:");
            address = Console.ReadLine();
            Console.Clear();

            Console.Write("Enter Phone Number:");
            phoneNumber = Console.ReadLine();
            Console.Clear();
            string roomNum;           
        }

        public void ApplyInfo( )
        {
            string insertString = string.Empty; 

        

                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "insert into clients (FirstName,LastName,Phone,Address)" +
                    $"values('{firstName}','{lastName}','{phoneNumber}','{address}');";
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
       

        }

        public void SearchUser()
        {
            string str = string.Empty;
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            string searchTerm;
            Console.Write("Enter Last Name:");
            searchTerm = Console.ReadLine();
            cmd.CommandText = $"select * from clients where LastName ='{searchTerm}';";
            MySqlDataReader reader = cmd.ExecuteReader();
            cmd.Connection = connection;
           
            while(reader.Read() ) 
            {
                str += reader.GetString("FirstName");
                str += "\t";
                str += reader.GetString("LastName");
                str += "\t";
                str += reader.GetString("Phone");
                str += "\t";
                str += reader.GetString("Address");
                str += "\n";
            }
            reader.Close();
            Console.WriteLine(str);
        }
    }
}
