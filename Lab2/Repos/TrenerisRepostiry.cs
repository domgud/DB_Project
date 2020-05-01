using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using Lab2.ViewModels;

namespace Lab2.Repos
{
    public class TrenerisRepostiry
    {
        public List<TrenerisViewModel> getTreneriai()
        {
            List<TrenerisViewModel> treneriai = new List<TrenerisViewModel>();
            string databaseInfo = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(databaseInfo);
            string query = "SELECT * FROM `treneris`";


            MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();


            foreach (DataRow item in dt.Rows)
            {
                treneriai.Add(new TrenerisViewModel
                {
                    id_TRENERIS = Convert.ToInt32(item["id_TRENERIS"]),
                    vardas = Convert.ToString(item["vardas"]),
                    pavarde = Convert.ToString(item["pavarde"]),
                    slapyvadis = Convert.ToString(item["slapyvardis"]),
                    amzius = Convert.ToInt32(item["amzius"]),
                });
            }

            return treneriai;
        }

        public TrenerisEditViewModel getTreneris(int id)
        {
            TrenerisEditViewModel modelis = new TrenerisEditViewModel();

            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);

            string query = @"SELECT `vardas`, `pavarde`, `amzius`, `slapyvardis`, `id_TRENERIS`
                            FROM treneris a
                            WHERE ad_TRENERIS =" + id;

            MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {
                modelis.id_TRENERIS = Convert.ToInt32(item["id_TRENERIS"]);
                modelis.vardas = Convert.ToString(item["vardas"]);
                modelis.pavarde = Convert.ToString(item["pavarde"]);
                modelis.slapyvadis = Convert.ToString(item["slapyvardis"]);
                modelis.amzius = Convert.ToInt32(item["amzius"]);
            }

            return modelis;
        }

        public int addShow(TrenerisEditViewModel treneris)
        {
            int insertedId = -1;
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);

            string query = @"INSERT INTO `treneris`(`vardas`, `pavarde`, `amzius`, `slapyvardis`, `id_TRENERIS`) VALUES(?vardas, ?pavarde, ?amzius, ?slapyvardis, NULL)";


            MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection);
            mySqlCommand.Parameters.Add("?vardas", MySqlDbType.VarChar).Value = treneris.vardas;
            mySqlCommand.Parameters.Add("?amzius", MySqlDbType.Int32).Value = treneris.amzius;
            mySqlCommand.Parameters.Add("?pavarde", MySqlDbType.VarChar).Value = treneris.pavarde;
            mySqlCommand.Parameters.Add("?slapyvardis", MySqlDbType.VarChar).Value = treneris.slapyvadis;
            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();

            insertedId = Convert.ToInt32(mySqlCommand.LastInsertedId);
            return insertedId;
        }

    }
}