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
    public class ZaidimasRepository
    {
        //public List<Zaidimas> getZaidimai()
        //{
        //    List<Zaidimas> zaidimai = new List<Zaidimas>();
        //    string databaseInfo = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
        //    MySqlConnection mySqlConnection = new MySqlConnection(databaseInfo);
        //    string query = @"SELECT *
        //                    FROM leidejas";


        //    MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection);
        //    mySqlConnection.Open();
        //    MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
        //    DataTable dt = new DataTable();
        //    mda.Fill(dt);
        //    mySqlConnection.Close();

        //    foreach (DataRow item in dt.Rows)
        //    {
        //        zaidimai.Add(new Zaidimas
        //        {
        //            pavadinimas = Convert.ToString(item["pavadinimas"]),
        //            leidimo_metai = Convert.ToInt32(item["leidimo_metai"]),
        //            zanras = Convert.ToString(item["zanras"]),
        //            reitingas = Convert.ToString(item["reitingas"]),
        //            fk_LEIDEJAS = Convert.ToInt32(item["fk_LEIDEJASid_LEIDEJAS"]),
        //            id_ZAIDIMAS = Convert.ToInt32(item["id_ZAIDIMAS"])
        //        });
        //    }

        //    return zaidimai;
        //}
        public List<Zaidimas> getZaidimas(int id)
        {
            List<Zaidimas> zaidimai = new List<Zaidimas>();
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"SELECT * from "  + "zaidimas WHERE fk_LEIDEJASid_LEIDEJAS=" + id;
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {
                zaidimai.Add(new Zaidimas
                {
                    pavadinimas = Convert.ToString(item["pavadinimas"]),
                    leidimo_metai = Convert.ToInt32(item["leidimo_metai"]),
                    zanras = Convert.ToString(item["zanras"]),
                    reitingas = Convert.ToString(item["reitingas"]),
                    fk_LEIDEJAS = Convert.ToInt32(item["fk_LEIDEJASid_LEIDEJAS"]),
                    id_ZAIDIMAS = Convert.ToInt32(item["id_ZAIDIMAS"])

                });
            }

            return zaidimai;
        }
        public bool deleteZaidimas(int id)
        {
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"DELETE FROM a USING " + @"zaidimas as a
                                where a.fk_LEIDEJASid_LEIDEJAS=?fkid ";
                                    //and not exists (select 1 from " +  @"uzsakytos_paslaugos psl where psl.fk_paslauga=a.fk_paslauga and psl.fk_kaina_galioja_nuo=a.galioja_nuo)";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?fkid", MySqlDbType.Int32).Value = id;
            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();


            return true;
        }
        public bool insertZaidimas(ZaidimasViewModel zaidimasViewModel)
        {
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"INSERT INTO "  + @"zaidimas(
                                        pavadinimas,
                                        leidimo_metai,
                                        zanras,
                                        reitingas,
                                        fk_LEIDEJASid_LEIDEJAS)VALUES(
                                        ?pavadinimas,
                                        ?ledimo_metai,
                                        ?zanras,
                                        ?reitingas,
                                        ?fk_LEIDEJASid_LEIDEJAS
                                        )";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?pavadinimas", MySqlDbType.String).Value = zaidimasViewModel.pavadinimas;
            mySqlCommand.Parameters.Add("?ledimoi_metai", MySqlDbType.Int32).Value = zaidimasViewModel.leidimo_metai;
            mySqlCommand.Parameters.Add("?zanras", MySqlDbType.String).Value = zaidimasViewModel.zanras;
            mySqlCommand.Parameters.Add("?reitingas", MySqlDbType.String).Value = zaidimasViewModel.reitingas;
            mySqlCommand.Parameters.Add("?fk_LEIDEJASid_LEIDEJAS", MySqlDbType.Int32).Value = zaidimasViewModel.fk_LEIDEJASid_LEIDEJAS;
            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
            return true;
        }
    }
}