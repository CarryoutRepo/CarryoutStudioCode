using System.Data;
using System.Data.OleDb;

namespace CBCAccessDB
{
    public static class Util
    {
        private static bool OpenDatabase()
        {
            OleDbConnection o = new();

            string sqlQuerstring sqlQuery = "INSERT INTO Items ('ItemID, SKU, Description, ShortDescription, Size, CBCCode, Note) " +
                                            "VALUESA (?,?,?,?,?,?,?)";

            using (OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\DB.accdb"))
            using (OleDbCommand cmd = new OleDbCommand(sqlQuery, conn))
            {

                conn.Open();
                cmd.Parameters.AddWithValue("@Name", this.textBox1.Text);
                cmd.Parameters.AddWithValue("@Date", this.monthCalendar1.Text);
                cmd.ExecuteNonQuery();
            }
            y = "INSERT INTO register (`Name`,`Date`) values (?,?)";
            using (OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\DB.accdb"))
            using (OleDbCommand cmd = new OleDbCommand(sqlQuery, conn))
            {

                conn.Open();
                cmd.Parameters.AddWithValue("@Name", this.textBox1.Text);
                cmd.Parameters.AddWithValue("@Date", this.monthCalendar1.Text);
                cmd.ExecuteNonQuery();
            }
            return 0;
        }
    }
    e
    }
}