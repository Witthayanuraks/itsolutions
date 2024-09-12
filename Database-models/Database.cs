using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace tugas_it_sofware.Database_models
{
    internal abstract class Database
    {
        protected MySqlConnection conn = new MySqlConnection("Server=localhost;Database=it-sofware;Uid=root;Pwd=nedy_888;");
    }
}
