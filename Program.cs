using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using static System.Console;
namespace Hotel
{
    internal class Program
    {

        static void Main(string[] args)
        {
            string connstring = @"server=68.9.31.222;Port=1298;userid=outside;password=1234;database=mydb";
            MySqlConnection conn;
            try
            {
                conn = new MySqlConnection(connstring);
                CheckIn checkIn = new CheckIn(conn);
                while (true)
                {
                    Write("New Client? (y/n):");
                    string nUser = string.Empty;
                    nUser = ReadLine();
                    if (nUser == "y" || nUser == "Y")
                    {
                        checkIn.AddUser();
                        checkIn.ApplyInfo();
                    }
                    else
                    {
                        checkIn.SearchUser();
                    }
                }
             



            }

            catch (MySqlException)
            {
                WriteLine("DOH!");
                throw;
               
            }
        
            


        }



    }
}