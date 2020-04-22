using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projek
{
    class DBConnection
    {
        private static DBConnection instance;
        public MySqlConnection conn;

        private DBConnection()
        {
            string conStr = "server=localhost;port=3306;username=root;password='';database=rental";
            conn = new MySqlConnection(conStr);
        }

        public static DBConnection GetInstance()
        {
            if (instance == null)
            {
                instance = new DBConnection();
            }

            return instance;
        }


    }
}
