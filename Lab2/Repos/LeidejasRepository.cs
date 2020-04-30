using Lab2.Models;
using Lab2.ViewModels;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace Lab2.Repos
{
    public class LeidejasRepository
    {
        public List<Leidejas> getLeidejai()
        {
            List<Leidejas> leidejai = new List<Leidejas>();
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
                leidejai.Add(new Leidejas
                {
                   pavadinimas = Convert.ToString(item["pavadinimas"]),
                    ikurimo_metai = Convert.ToInt32(item["ikurimo_metai"]),
                    tipas = Convert.ToString(item["tipas"]),
                    bustine = Convert.ToString(item["bustine"]),
                    valstybe = Convert.ToString(item["valstybe"]),
                    id_LEIDEJAS = Convert.ToInt32(item["id_LEIDEJAS"])
                });
            }

            return leidejai;
        }
        public Leidejas getLeidejas(int id)
        {
            Leidejas leidejas = new Leidejas();

            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"SELECT m.id_LEIDEJAS, m.pavadinimas, m.ikurimo_metai, m.tipas, m.bustine, m.valstybe
                                FROM " + "leidejas m WHERE m.id_LEIDEJAS=" + id;
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {

                leidejas.pavadinimas = Convert.ToString(item["pavadinimas"]);
                leidejas.ikurimo_metai = Convert.ToInt32(item["ikurimo_metai"]);
                leidejas.tipas = Convert.ToString(item["tipas"]);
                leidejas.bustine = Convert.ToString(item["bustine"]);
                leidejas.valstybe = Convert.ToString(item["valstybe"]);
                leidejas.id_LEIDEJAS = Convert.ToInt32(item["id_LEIDEJAS"]);
            }

            return leidejas;
        }
        public LeidejasEditViewModel getLeidejasViewModel(int id)
        {
            LeidejasEditViewModel leidejas = new LeidejasEditViewModel();

            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"SELECT m.id_LEIDEJAS, m.pavadinimas, m.ikurimo_metai, m.tipas, m.bustine, m.valstybe
                                FROM " + "leidejas m WHERE m.id_LEIDEJAS=" + id;
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {

                leidejas.pavadinimas = Convert.ToString(item["pavadinimas"]);
                leidejas.ikurimo_metai = Convert.ToInt32(item["ikurimo_metai"]);
                leidejas.tipas = Convert.ToString(item["tipas"]);
                leidejas.bustine = Convert.ToString(item["bustine"]);
                leidejas.valstybe = Convert.ToString(item["valstybe"]);
                leidejas.id_LEIDEJAS = Convert.ToInt32(item["id_LEIDEJAS"]);
            }

            return leidejas;
        }
        public bool updateLeidejas(LeidejasEditViewModel leidejas)
        {
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"UPDATE "  + "leidejas a SET a.pavadinimas=?pavadinimas, a.ikurimo_metai=?ikurimo_metai, a.tipas=?tipas, a.bustine=?bustine, a.valstybe=?valstybe WHERE a.id_LEIDEJAS=?id_LEIDEJAS";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?id_LEIDEJAS", MySqlDbType.Int32).Value = leidejas.id_LEIDEJAS;
            mySqlCommand.Parameters.Add("?pavadinimas", MySqlDbType.VarChar).Value = leidejas.pavadinimas;
            mySqlCommand.Parameters.Add("?ikurimo_metai", MySqlDbType.Int32).Value = leidejas.ikurimo_metai;
            mySqlCommand.Parameters.Add("?tipas", MySqlDbType.VarChar).Value = leidejas.tipas;
            mySqlCommand.Parameters.Add("?bustine", MySqlDbType.VarChar).Value = leidejas.bustine;
            mySqlCommand.Parameters.Add("?valstybe", MySqlDbType.VarChar).Value = leidejas.valstybe;
            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
            return true;
        }
        public bool addLeidejas(LeidejasEditViewModel leidejas)
        {
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"INSERT INTO " + "leidejas(pavadinimas, ikurimo_metai, tipas, bustine, valstybe)VALUES(?pavadinimas, ?ikurimo_metai, ?tipas, ?bustine, ?valstybe)";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?pavadinimas", MySqlDbType.VarChar).Value = leidejas.pavadinimas;
            mySqlCommand.Parameters.Add("?ikurimo_metai", MySqlDbType.Int32).Value = leidejas.ikurimo_metai;
            mySqlCommand.Parameters.Add("?tipas", MySqlDbType.VarChar).Value = leidejas.tipas;
            mySqlCommand.Parameters.Add("?bustine", MySqlDbType.VarChar).Value = leidejas.bustine;
            mySqlCommand.Parameters.Add("?valstybe", MySqlDbType.VarChar).Value = leidejas.valstybe;
            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
            return true;
        }
        public void deleteLeidejas(int id)
        {
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"DELETE FROM "  + "leidejas where id_LEIDEJAS=?id_LEIDEJAS";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?id_LEIDEJAS", MySqlDbType.Int32).Value = id;
            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
        }
        public int insertPaslauga(LeidejasEditViewModel paslauga)
        {
            int insertedId = -1;
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"INSERT INTO " + "leidejas(pavadinimas, ikurimo_metai, tipas, bustine, valstybe)VALUES(?pavadinimas, ?ikurimo_metai, ?tipas, ?bustine, ?valstybe)";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?pavadinimas", MySqlDbType.VarChar).Value = paslauga.pavadinimas;
            mySqlCommand.Parameters.Add("?ikurimo_metai", MySqlDbType.Int32).Value = paslauga.ikurimo_metai;
            mySqlCommand.Parameters.Add("?tipas", MySqlDbType.VarChar).Value = paslauga.tipas;
            mySqlCommand.Parameters.Add("?bustine", MySqlDbType.VarChar).Value = paslauga.bustine;
            mySqlCommand.Parameters.Add("?valstybe", MySqlDbType.VarChar).Value = paslauga.valstybe;
            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
            insertedId = Convert.ToInt32(mySqlCommand.LastInsertedId);
            return insertedId;
        }

    }
}