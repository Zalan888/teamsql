using MySql.Data.MySqlClient;
using System.Runtime.InteropServices;

namespace ConsoleApp2
{
    public class Connect
    {
        public MySqlConnection Connection;
        public string Host;
        public string Database;
        public string User;
        public string Password;
        public string ConnectionString;


        public Connect()
        {
            Host = "localhost";
            Database = "team";
            User = "root";
            Password = "";
            ConnectionString = "SERVER=" + Host + ";DATABASE=" + Database + ";UID=" + User + ";PASSWORD=" + Password + ";SslMode=None";
            Connection = new MySqlConnection(ConnectionString);

        }
    }
}
