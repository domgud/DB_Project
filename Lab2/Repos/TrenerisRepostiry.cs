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
        public List<TrenerisViewModel> getShows()
        {
            List<TrenerisViewModel> laidos = new List<TrenerisViewModel>();
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
                laidos.Add(new TrenerisViewModel
                {
                    id_TRENERIS = Convert.ToInt32(item["id_TRENERIS"]),
                    vardas = Convert.ToString(item["vardas"]),
                    pavarde = Convert.ToString(item["pavarde"]),
                    slapyvadis = Convert.ToString(item["slapyvardis"]),
                    amzius = Convert.ToInt32(item["amzius"]),
                });
            }

            return laidos;
        }

        public TrenerisEditViewModel getShow(int id)
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

        public int addShow(TrenerisEditViewModel laida)
        {
            int insertedId = -1;
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);

            string query = @"INSERT INTO `treneris`(`vardas`, `pavarde`, `amzius`, `slapyvardis`, `id_TRENERIS`) VALUES(?vardas, ?pavarde, ?amzius, ?slapyvardis, NULL)";


            MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection);
            mySqlCommand.Parameters.Add("?vardas", MySqlDbType.VarChar).Value = laida.vardas;
            mySqlCommand.Parameters.Add("?amzius", MySqlDbType.Int32).Value = laida.amzius;
            mySqlCommand.Parameters.Add("?pavarde", MySqlDbType.VarChar).Value = laida.pavarde;
            mySqlCommand.Parameters.Add("?slapyvardis", MySqlDbType.VarChar).Value = laida.slapyvadis;
            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();

            insertedId = Convert.ToInt32(mySqlCommand.LastInsertedId);
            return insertedId;
        }

        //public bool updateShow(TrenerisEditViewModel laida)
        //{
        //    string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
        //    MySqlConnection mySqlConnection = new MySqlConnection(conn);
        //    string sqlquery = @"UPDATE `tv_laida` SET
        //                            `pavadinimas` = ?pavadinimas,
        //                            `trukme` = ?trukme,
        //                            `isleidimo_metai` = ?isleidimo_metai,
        //                            `reitingai` = ?reitingai,
        //                            `ziurovu_vidutinis_ivertinimas` = ?ziurovu_vidutinis_ivertinimas,
        //                            `aprasymas` = ?aprasymas,
        //                            `busena` = ?busena,
        //                            `zanras` = ?zanras,
        //                            `amziaus_reikalavimas` = ?amziaus_reikalavimas
        //                            WHERE id_TV_LAIDA =" + laida.id_TV_LAIDA;
        //    MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
        //    mySqlCommand.Parameters.Add("?pavadinimas", MySqlDbType.VarChar).Value = laida.pavadinimas;
        //    mySqlCommand.Parameters.Add("?trukme", MySqlDbType.Int32).Value = laida.trukme;
        //    mySqlCommand.Parameters.Add("?isleidimo_metai", MySqlDbType.Int32).Value = laida.isleidimo_metai;
        //    mySqlCommand.Parameters.Add("?reitingai", MySqlDbType.Float).Value = laida.reitingai;
        //    mySqlCommand.Parameters.Add("?ziurovu_vidutinis_ivertinimas", MySqlDbType.Float).Value = laida.ziurovu_vidutinis_ivertinimas;
        //    mySqlCommand.Parameters.Add("?aprasymas", MySqlDbType.VarChar).Value = laida.aprasymas;
        //    mySqlCommand.Parameters.Add("?busena", MySqlDbType.Int32).Value = laida.busena;
        //    mySqlCommand.Parameters.Add("?zanras", MySqlDbType.Int32).Value = laida.zanras;
        //    mySqlCommand.Parameters.Add("?amziaus_reikalavimas", MySqlDbType.Int32).Value = laida.amziaus_reikalavimas;
        //    mySqlConnection.Open();
        //    mySqlCommand.ExecuteNonQuery();
        //    mySqlConnection.Close();

        //    return true;
        //}

        //public void deleteShow(int id)
        //{
        //    string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
        //    MySqlConnection mySqlConnection = new MySqlConnection(conn);
        //    string sqlquery = @"DELETE FROM tv_laida where id_TV_LAIDA=?id_TV_LAIDA";
        //    MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
        //    mySqlCommand.Parameters.Add("?id_TV_LAIDA", MySqlDbType.Int32).Value = id;
        //    mySqlConnection.Open();
        //    mySqlCommand.ExecuteNonQuery();
        //    mySqlConnection.Close();
        //}

    }
}