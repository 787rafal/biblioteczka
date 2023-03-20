using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace app
{
    public class database
    {

        public static string conn = "server=127.0.0.1; user=root; database=biblio_app; password=;CharSet=utf8;";
        public MySqlConnection sql = new MySqlConnection(conn);

        public bool connect_db()
        {
            try
            {
                sql.Open();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool close_db()
        {
            try
            {
                sql.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
