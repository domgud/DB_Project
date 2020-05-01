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
    public class KomandaRepository
    {
            public List<KomandaViewModel> getKomandos()
            {
                List<KomandaViewModel> komandos = new List<KomandaViewModel>();
                string databaseInfo = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
                MySqlConnection mySqlConnection = new MySqlConnection(databaseInfo);
                string query = @"SELECT 
                                k.pavadinimas,
                                k.ikurimo_metai,
                                k.valstybe,
                                k.id_KOMANDA,
                                l.pavarde AS savininkas
                            FROM komanda k LEFT JOIN savininkas l
                              on k.fk_SAVININKASid_SAVININKAS  = l.id_SAVININKAS";


                MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection);
                mySqlConnection.Open();
                MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
                DataTable dt = new DataTable();
                mda.Fill(dt);
                mySqlConnection.Close();


                foreach (DataRow item in dt.Rows)
                {
                    komandos.Add(new KomandaViewModel
                    {
                        id_KOMANDA = Convert.ToInt32(item["id_KOMANDA"]),
                        pavadinimas = Convert.ToString(item["pavadinimas"]),
                        valstybe = Convert.ToString(item["valstybe"]),
                        ikurimo_metai = Convert.ToInt32(item["ikurimo_metai"]),
                        savininkas = Convert.ToString(item["savininkas"])
                    });
                }

                return komandos;
            }

            public KomandaEditViewModel getKomanda(int id)
            {
            KomandaEditViewModel kurejas = new KomandaEditViewModel();

                string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
                MySqlConnection mySqlConnection = new MySqlConnection(conn);

                string query = @"SELECT 
                                k.pavadinimas,
                                k.ikurimo_metai,
                                k.valstybe,
                                k.id_KOMANDA,
                                k.fk_SAVININKASid_SAVININKAS
                            FROM komanda k
                            WHERE k.id_KOMANDA =" + id;

                MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection);
                mySqlConnection.Open();
                MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
                DataTable dt = new DataTable();
                mda.Fill(dt);
                mySqlConnection.Close();

                foreach (DataRow item in dt.Rows)
                {
                    kurejas.id_KOMANDA = Convert.ToInt32(item["id_KOMANDA"]);
                    kurejas.pavadinimas = Convert.ToString(item["pavadinimas"]);
                    kurejas.valstybe = Convert.ToString(item["valstybe"]);
                    kurejas.ikurimo_metai= Convert.ToInt32(item["ikurimo_metai"]);
                    kurejas.savininkas = Convert.ToInt32(item["fk_SAVININKASid_SAVININKAS"]);
                }

                return kurejas;
            }

            public int addKomanda(KomandaEditViewModel komanda)
            {
                int insertedId = -1;
                string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
                MySqlConnection mySqlConnection = new MySqlConnection(conn);

                string query = @"INSERT INTO `komanda`(`pavadinimas`, `ikurimo_metai`, `valstybe`, `fk_SAVININKASid_SAVININKAS`) VALUES(?pavadinimas, ?ikurimo_metai, ?valstybe, ?savininkas)";

                MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection);
            mySqlCommand.Parameters.Add("?pavadinimas", MySqlDbType.VarChar).Value = komanda.pavadinimas;
            mySqlCommand.Parameters.Add("?valstybe", MySqlDbType.VarChar).Value = komanda.valstybe;
            mySqlCommand.Parameters.Add("?ikurimo_metai", MySqlDbType.Int32).Value = komanda.ikurimo_metai;
            mySqlCommand.Parameters.Add("?savininkas", MySqlDbType.Int32).Value = komanda.savininkas;


                mySqlConnection.Open();
                mySqlCommand.ExecuteNonQuery();
                mySqlConnection.Close();
                insertedId = Convert.ToInt32(mySqlCommand.LastInsertedId);

                return insertedId;
            }

            public bool updateKomanda(KomandaEditViewModel komanda)
            {
                string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
                MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"UPDATE `komanda` SET 
                                        `pavadinimas`= ?pavadinimas,
                                        `valstybe`= ?valstybe,
                                        `ikurimo_metai`= ?ikurimo_metai,
                                        `fk_SAVININKASid_SAVININKAS` = ?savininkas
                                        WHERE id_KOMANDA =" + komanda.id_KOMANDA;


                MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?pavadinimas", MySqlDbType.VarChar).Value = komanda.pavadinimas;
            mySqlCommand.Parameters.Add("?valstybe", MySqlDbType.VarChar).Value = komanda.valstybe;
            mySqlCommand.Parameters.Add("?ikurimo_metai", MySqlDbType.Int32).Value = komanda.ikurimo_metai;
            mySqlCommand.Parameters.Add("?savininkas", MySqlDbType.Int32).Value = komanda.savininkas;
            mySqlConnection.Open();
                mySqlCommand.ExecuteNonQuery();
                mySqlConnection.Close();

                return true;
            }

            public void deleteKomanda(int id)
            {
                string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
                MySqlConnection mySqlConnection = new MySqlConnection(conn);
                string sqlquery = @"DELETE FROM komanda WHERE id_KOMANDA=?id_KOMANDA";
                MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
                mySqlCommand.Parameters.Add("?id_KOMANDA", MySqlDbType.Int32).Value = id;
                mySqlConnection.Open();
                mySqlCommand.ExecuteNonQuery();
                mySqlConnection.Close();
            }
        }
}