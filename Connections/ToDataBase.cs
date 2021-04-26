using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace FurnitureStore.Connections
{
   public class ToDataBase
    {
        public MySqlConnection cn;
        public MySqlCommand cm;
        public MySqlDataReader dr;
        
        public void Connection()
        {
            cn = new MySqlConnection();
            cn.ConnectionString = "server=localhost;user id=mysql;password=mysql;database=shopfurniture";
            
        }

    }
}
