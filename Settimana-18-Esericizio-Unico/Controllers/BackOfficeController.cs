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
    [Authorize]
    public class BackOfficeController : Controller
    {
        // GET: BackOffice
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RegistraClientiPrivato()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegistraClientiPrivato(ClientePrivato c)
        {
            string connString = ConfigurationManager
                .ConnectionStrings["myConnection"]
                .ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connString);

            try
            {
                conn.Open();
                string query =
                    "INSERT INTO Clienti (Nome, Cod_Fisc, C) VALUES (@Nome, @Cod_FIsc, 'C')";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Nome", c.Nome);
                cmd.Parameters.AddWithValue("@Cod_Fisc", c.Cod_Fisc);

                cmd.ExecuteNonQuery();
                ViewBag.Message = "Inserimento Cliente completato con successo";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
                ViewBag.Error = "Errore nella registrazione del nuovo cliente";
                return View();
            }
            finally
            {
                conn.Close();
            }
        }

        public ActionResult RegistraClientiAzienda()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegistraClientiAzienda(ClienteAzienda c)
        {
            string connString = ConfigurationManager
                .ConnectionStrings["myConnection"]
                .ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connString);

            try
            {
                conn.Open();
                string query = "INSERT INTO Clienti (Nome, P_Iva) VALUES (@Nome, @P_Iva)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Nome", c.Nome);
                cmd.Parameters.AddWithValue("@P_Iva", c.P_Iva);

                cmd.ExecuteNonQuery();
                ViewBag.Message = "Inserimento Cliente completato con successo";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
                ViewBag.Error = "Errore nella registrazione del nuovo cliente";
                return View();
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
