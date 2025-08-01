using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Winf_XO
{
    class sqliranyitas
    {

        public static MySqlConnection GetConnection()
        {
            string sql = "datasource=localhost;port=3306;username=root;password=;database=tictactoe";

            MySqlConnection con = new MySqlConnection(sql);
            try
            {
                con.Open();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            return con;

        }



        public static void AddData(Adat std)
        {
            string sql = "INSERT INTO tictactoetable (NevX, NevO, Nyertes, Ido) VALUES (@AdatNevX, @AdatNevO, @AdatNyertes, @AdatIdo)";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);


            cmd.Parameters.Add("@AdatNevX", MySqlDbType.Text).Value = std.NevX;
            cmd.Parameters.Add("@AdatNevO", MySqlDbType.Text).Value = std.NevO;
            cmd.Parameters.Add("@AdatNyertes", MySqlDbType.Text).Value = std.Nyertes;
            cmd.Parameters.Add("@AdatIdo", MySqlDbType.DateTime).Value = std.Ido;
            try
            {
                cmd.ExecuteNonQuery();
                
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            con.Close();


        }


        public static void MutatAdatTablaban(string query, DataGridView dgv)
        {
            string sql = query;
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable tbl = new DataTable();
            adp.Fill(tbl);
            dgv.DataSource = tbl;
            con.Close();
        }


    }
}
