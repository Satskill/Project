using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace AcikArttirmaProje
{
    class Baglanti
    {
        public SqlConnection bagla()
        {
            SqlConnection baglan = new SqlConnection(@"Data Source=AHMET\SQLEXPRESS;Initial Catalog=AcikArttirma;Integrated Security=True");
            //SqlConnection baglan = new SqlConnection(@"Data Source=DESKTOP-E7MSLR2\SQLEXPRESS;Initial Catalog=AcikArttirma;Integrated Security=True");
            baglan.Open();
            return baglan;
        }
    }
}
