using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Settimana_18_Esericizio_Unico.Models;

namespace Settimana_18_Esericizio_Unico.Controllers
{
    public class AsyncController : Controller
    {
        public ActionResult Statistiche()
        {
            return View();
        }

        // GET: Async
        public JsonResult TutteLeSpedizoniOdierne()
        {
            List<Spedizione> listaSpedizioniOdierne = new List<Spedizione>();

            string connString = ConfigurationManager
                .ConnectionStrings["myConnection"]
                .ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connString);

            try
            {
                conn.Open();
                string query = "SELECT * FROM Spedizioni WHERE Data_Consegna = @Today";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Today", DateTime.Now);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    listaSpedizioniOdierne.Add(
                        new Spedizione(
                            reader.GetInt32(0),
                            reader.GetInt32(1),
                            reader.GetString(2),
                            reader.GetDateTime(3),
                            reader.GetDouble(4),
                            reader.GetString(5),
                            reader.GetString(6),
                            reader.GetString(7),
                            reader.GetSqlMoney(8).ToDouble(),
                            reader.GetDateTime(9)
                        )
                    );
                }

                return Json(listaSpedizioniOdierne, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
                return Json("", JsonRequestBehavior.AllowGet);
            }
            finally
            {
                conn.Close();
            }
        }

        public JsonResult NummeroSpedizioniInAttesa()
        {
            string connString = ConfigurationManager
                .ConnectionStrings["myConnection"]
                .ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connString);

            try
            {
                int number = 0;

                conn.Open();
                string query = "SELECT COUNT(*) FROM Spedizioni WHERE Data_Consegna >= @Today";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Today", DateTime.Now);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    number = reader.GetInt32(0);
                }

                return Json(number, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
                return Json("", JsonRequestBehavior.AllowGet);
            }
            finally
            {
                conn.Close();
            }
        }

        public JsonResult NummeroSpedizioniPerCittà()
        {
            string connString = ConfigurationManager
                .ConnectionStrings["myConnection"]
                .ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connString);

            try
            {
                List<string> listaCittàESpedizioni = new List<string>();

                conn.Open();
                string query = "SELECT COUNT(*), Città_Destinataria FROM Spedizioni";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Today", DateTime.Now);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    listaCittàESpedizioni.Add(reader.GetInt32(1) + ": " + reader.GetString(1));
                }

                return Json(listaCittàESpedizioni, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
                return Json("", JsonRequestBehavior.AllowGet);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
