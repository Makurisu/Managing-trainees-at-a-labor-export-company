using System.Data.SqlClient;
namespace DAL
{
    public class DBConnect
    {
        protected SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-PDCM441\HUNG;Initial Catalog=QLHV;Integrated Security=True");
    }
}