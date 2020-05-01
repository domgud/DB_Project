using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using Lab2.Models;

namespace Lab2.Repos
{
    public class TreniruojaRepository
    {
        public List<Treniruoja> getKuria(int kurejo_id)
        {
            List<Treniruoja> kuriamos = new List<Treniruoja>();
            string databaseInfo = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(databaseInfo);
            string query = @"SELECT *
                            FROM treniruoja
                              WHERE fk_KOMANDAid_KOMANDA  =" + kurejo_id;


            MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();


            foreach (DataRow item in dt.Rows)
            {
                kuriamos.Add(new Treniruoja
                {
                    fk_TRENERISid_TRENERIS = Convert.ToInt32(item["fk_TRENERISid_TRENERIS"]),
                    fk_KOMANDAid_KOMANDA = Convert.ToInt32(item["fk_KOMANDAid_KOMANDA"])
                });
            }

            return kuriamos;
        }

        public bool addKuriamas(Treniruoja kurimas)
        {
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);

            string query = @"INSERT INTO `treniruoja`(`fk_KOMANDAid_KOMANDA`, `fk_TRENERISid_TRENERIS`) 
                            VALUES (?fk_KOMANDAid_KOMANDA, ?fk_TRENERISid_TRENERIS)";

            MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection);
            mySqlCommand.Parameters.Add("?fk_KOMANDAid_KOMANDA", MySqlDbType.Int32).Value = kurimas.fk_KOMANDAid_KOMANDA;
            mySqlCommand.Parameters.Add("?fk_TRENERISid_TRENERIS", MySqlDbType.Int32).Value = kurimas.fk_TRENERISid_TRENERIS;



            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();

            return true;
        }

        public void deleteKuria(int Kurejo_id)
        {
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"DELETE FROM treniruoja WHERE fk_KOMANDAid_KOMANDA=?fk_KOMANDAid_KOMANDA";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?fk_KOMANDAid_KOMANDA", MySqlDbType.Int32).Value = Kurejo_id;
            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
        }
    }
}