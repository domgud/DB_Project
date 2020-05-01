using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using Lab2.Models;

namespace Lab2.Repos
{
    public class SavininkasRepository
    {
        public List<Savininkas> getSavininkas()
        {
            List<Savininkas> savininkas = new List<Savininkas>();
            string databaseInfo = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(databaseInfo);
            string query = @"SELECT *
                            FROM savininkas";


            MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {
                savininkas.Add(new Savininkas
                {
                    id_SAVININKAS = Convert.ToInt32(item["id_SAVININKAS"]),
                    vardas = Convert.ToString(item["vardas"]),
                    pavarde = Convert.ToString(item["pavarde"]),
                    amzius = Convert.ToInt32(item["amzius"]),
                    slapyvadis = Convert.ToString(item["slapyvardis"])
                });
            }

            return savininkas;
        }
    }
}