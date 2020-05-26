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
    public class AtaskaitaRepo
    {
        public List<STurnyrasViewModel> getAtaskaitaSutartciu(DateTime? nuo, int? nuoLeidejoMetai, float? nuoPrizuFondas)
        {
            List<STurnyrasViewModel> sutartys = new List<STurnyrasViewModel>();
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"SELECT a.pavadinimas as leidejas, a.ikurimo_metai, b.pavadinimas as zaidimas, t.bendra_suma,t.kiekis, t.minimum, t.maximum, c.pavadinimas as turnyras, c.prizu_fondo_dydis as pinigai, c.data as data, d.pavadinimas as organizatorius FROM leidejas a
                              INNER JOIN zaidimas b ON a.id_LEIDEJAS = b.fk_LEIDEJASid_LEIDEJAS
                              INNER JOIN turnyras c ON b.id_ZAIDIMAS = c.fk_ZAIDIMASid_ZAIDIMAS
                              LEFT JOIN(select x.id_ZAIDIMAS, sum(z.prizu_fondo_dydis) as bendra_suma, 
                              COUNT(z.id_TURNYRAS) as kiekis, 
                              MIN(z.prizu_fondo_dydis) as minimum, 
                              MAX(z.prizu_fondo_dydis) as maximum from turnyras z, zaidimas x WHERE x.id_ZAIDIMAS = z.fk_ZAIDIMASid_ZAIDIMAS
                              GROUP BY x.id_ZAIDIMAS) as t on t.id_ZAIDIMAS = b.id_ZAIDIMAS
                              INNER JOIN organizatorius d ON d.id_ORGANIZATORIUS = c.fk_ORGANIZATORIUSid_ORGANIZATORIUS
                              WHERE data>= IFNULL(?nuo, data) AND a.ikurimo_metai >= IFNULL(?nuoLeidejoMetai, a.ikurimo_metai) AND c.prizu_fondo_dydis >= IFNULL(?nuoPrizuFondas, c.prizu_fondo_dydis)
                              ORDER BY a.pavadinimas, b.pavadinimas";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?nuo", MySqlDbType.DateTime).Value = nuo;
            mySqlCommand.Parameters.Add("?nuoLeidejoMetai", MySqlDbType.Int32).Value = nuoLeidejoMetai;
            mySqlCommand.Parameters.Add("?nuoPrizuFondas", MySqlDbType.Int32).Value = nuoPrizuFondas;
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {
                sutartys.Add(new STurnyrasViewModel
                {
                    Leidejas = Convert.ToString(item["leidejas"]),
                    LeidejoMetai = Convert.ToInt32(item["ikurimo_metai"]),
                    Zaidimas = Convert.ToString(item["zaidimas"]),
                    BendraSuma = (float)Convert.ToDouble(item["bendra_suma"]),
                    BendrasKiekis = Convert.ToInt32(item["kiekis"]),
                    Minimum=(float) Convert.ToDouble(item["minimum"]),
                    Maximum = (float)Convert.ToDouble(item["maximum"]),
                    Turnyras = Convert.ToString(item["turnyras"]),
                    Pinigai = (float)Convert.ToDouble(item["pinigai"]),
                    Data = Convert.ToDateTime(item["data"]),
                    Organizatorius = Convert.ToString(item["organizatorius"]),
                });
            }
            return sutartys;
        }
    }
}