using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Kitaplik_Proje
{
    internal class sqlbaglantisi1
    {
        public SqlConnection baglanti()
        {
            SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-CP28GOV\\SQLEXPRESS;Initial Catalog=kitaplik;Integrated Security=True;Encrypt=False");
            baglan.Open();
            return baglan;
            
        }


    }
}
