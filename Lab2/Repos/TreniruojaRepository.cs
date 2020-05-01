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
        public List<Treniruoja> getTreniruoja(int id)
        {
            List<Treniruoja> treniruojamos = new List<Treniruoja>();
            string databaseInfo = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(databaseInfo);
            string query = @"SELECT *
                            FROM treniruoja
                              WHERE fk_KOMANDAid_KOMANDA  =" + id;


            MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();


            foreach (DataRow item in dt.Rows)
            {
                treniruojamos.Add(new Treniruoja
                {
                    fk_TRENERISid_TRENERIS = Convert.ToInt32(item["fk_TRENERISid_TRENERIS"]),
                    fk_KOMANDAid_KOMANDA = Convert.ToInt32(item["fk_KOMANDAid_KOMANDA"])
                });
            }

            return treniruojamos;
        }

        public bool addTreniruojamas(Treniruoja treniravimas)
        {
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);

            string query = @"INSERT INTO `treniruoja`(`fk_KOMANDAid_KOMANDA`, `fk_TRENERISid_TRENERIS`) 
                            VALUES (?fk_KOMANDAid_KOMANDA, ?fk_TRENERISid_TRENERIS)";

            MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection);
            mySqlCommand.Parameters.Add("?fk_KOMANDAid_KOMANDA", MySqlDbType.Int32).Value = treniravimas.fk_KOMANDAid_KOMANDA;
            mySqlCommand.Parameters.Add("?fk_TRENERISid_TRENERIS", MySqlDbType.Int32).Value = treniravimas.fk_TRENERISid_TRENERIS;



            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();

            return true;
        }

        public void deleteKuria(int id)
        {
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"DELETE FROM treniruoja WHERE fk_KOMANDAid_KOMANDA=?fk_KOMANDAid_KOMANDA";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?fk_KOMANDAid_KOMANDA", MySqlDbType.Int32).Value = id;
            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
        }
    }
}