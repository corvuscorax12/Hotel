using MySql.Data.MySqlClient;
using System.Data;


namespace Hotel
{
    internal class Accounts
    {
        string firstName;
        string lastName;
        string address;
        string phoneNumber;
        string email;
        MySqlConnection connection;
        public Accounts(MySqlConnection Connection)
        {
            connection = Connection;
            connection.Open();
        }
        public void AddUser()
        {

            Console.Write("Enter First Name:");
            firstName = Console.ReadLine();

            Console.Write("Enter Last Name:");
            lastName = Console.ReadLine();

            Console.Write("Enter Address Name:");
            address = Console.ReadLine();

            Console.Write("Enter Phone Number:");
            phoneNumber = Console.ReadLine();

            Console.Write("Enter Email Address");
            email = Console.ReadLine();
        }

        public void ApplyInfo()
        {
            string insertString = string.Empty;



            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "insert into clients (FirstName,LastName,Phone,Address,email)" +
                $"values('{firstName}','{lastName}','{phoneNumber}','{address}','{email}');";
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
            cmd.CommandText = $"select * from clients where LastName  like '{searchTerm}%';";
            MySqlDataReader reader = cmd.ExecuteReader();
            cmd.Connection = connection;

            while (reader.Read())
            {
                str += reader.GetString("FirstName");
                str += "\t";
                str += reader.GetString("LastName");
                str += "\t";
                str += reader.GetString("Phone");
                str += "\t";
                str += reader.GetString("Address");
                str += "\t";
                str += reader.GetString("Email");
                str += "\n";

            }
            reader.Close();
            Console.WriteLine(str);
        }



    }
}
