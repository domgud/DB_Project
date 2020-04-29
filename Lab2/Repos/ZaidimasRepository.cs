using Lab2.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
namespace Lab2.Repos
{
    public class ZaidimasRepository
    {
        public List<Zaidimas> getZAIDEJAI()
        {
            List<Zaidimas> leidejai = new List<Zaidimas>();
            string databaseInfo = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(databaseInfo);
            string query = @"SELECT *
                            FROM leidejas";


            MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {
                leidejai.Add(new Zaidimas
                {
                    pavadinimas = Convert.ToString(item["pavadinimas"]),
                    leidimo_metai = Convert.ToInt32(item["leidimo_metai"]),
                    zanras = Convert.ToString(item["zanras"]),
                    reitingas = Convert.ToString(item["bustine"]),
                    fk_LEIDEJAS = Convert.ToInt32(item["fk_LEIDEJASid_LEIDEJAS"]),
                    id_ZAIDIMAS = Convert.ToInt32(item["id_ZAIDIMAS"])
                });
            }

            return leidejai;
        }
    }
}