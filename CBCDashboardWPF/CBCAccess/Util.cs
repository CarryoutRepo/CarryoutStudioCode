using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ClassLibrary.CBCDataObjects;
using System.Data.OleDb;
using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Access;

namespace CBCDashboardWPF.CBCAccess
{
    public static class Util
    {
        public static bool AddItems(Items items)
        {
            string sqlQuery = "INSERT INTO Items ('ItemID, SKU, Description, ShortDescription, Size, CBCCode, Note) " +
                                            "VALUESA (?,?,?,?,?,?,?)";
            //using (OleDbConnection conn = new OleDbConnection@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\JohnMewesAccount\OneDrive\JM Documents\StudioCode\Database\CarryoutByChrislyn.accdb"))
            //OleDbConnectionStringBuilder s = new();   //@"Provider=;Data Source=""";Persist Security Info=True;Cache Authentication=True")) );
            //s.FileName = "C:\\Users\\JohnMewesAccount\\OneDrive\\JM Documents\\StudioCode\\Database\\CarryoutByChrislyn.accdb";
            //s.Provider = "Microsoft.ACE.OLEDB.12.0";
            //s.PersistSecurityInfo = true;

            using (OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;
                Data Source=C:\\Users\\JohnMewesAccount\\OneDrive\\JM Documents\\StudioCode\\Database\\CarryoutByChrislyn.accdb;
                Persist Security Info=True;Cache Authentication=True; UserID=Admin")) 
            {
                using (OleDbCommand cmd = new OleDbCommand(sqlQuery, conn))
                {

                    conn.Open();
                    cmd.Parameters.AddWithValue("@Name", "");
                    cmd.ExecuteNonQuery();
                }
            }
            return false;
        }
    }
}
