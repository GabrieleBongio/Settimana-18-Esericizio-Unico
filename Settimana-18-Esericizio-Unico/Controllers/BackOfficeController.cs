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

        public ActionResult RegistraSpedizione()
        {
            string connString = ConfigurationManager
                .ConnectionStrings["myConnection"]
                .ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connString);

            try
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM Clienti";
                SqlCommand cmd = new SqlCommand(query, conn);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ViewBag.NumberOfClienti = reader.GetInt32(0);
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
                ViewBag.Error = "Errore nel reperimento del numero dei Clienti";
                return View();
            }
            finally
            {
                conn.Close();
            }

            return View();
        }

        [HttpPost]
        public ActionResult RegistraSpedizione(Spedizione s)
        {
            string connString = ConfigurationManager
                .ConnectionStrings["myConnection"]
                .ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connString);

            try
            {
                conn.Open();
                string query =
                    "INSERT INTO Spedizioni (IdCliente, Numero_Identificativo, Data_Spedizione, Peso, Città_Destinataria, Indirizzo, Nominativo, Costo_Spedizione, Data_Consegna) VALUES (@IdCliente, @Numero_Identificativo, @Data_Spedizione, @Peso, @Città_Destinataria, @Indirizzo, @Nominativo, @Costo_Spedizione, @Data_Consegna)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IdCliente", s.IdCliente);
                cmd.Parameters.AddWithValue("@Numero_Identificativo", s.Numero_Identificativo);
                cmd.Parameters.AddWithValue("@Data_Spedizione", s.Data_Spedizione);
                cmd.Parameters.AddWithValue("@Peso", s.Peso);
                cmd.Parameters.AddWithValue("@Città_Destinataria", s.Città_Destinataria);
                cmd.Parameters.AddWithValue("@Indirizzo", s.Indirizzo);
                cmd.Parameters.AddWithValue("@Nominativo", s.Nominativo);
                cmd.Parameters.AddWithValue("@Costo_Spedizione", s.Costo_Spedizione);
                cmd.Parameters.AddWithValue("@Data_Consegna", s.Data_Consegna);

                cmd.ExecuteNonQuery();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
                ViewBag.Error = "Errore nella registrazione della nuova spedizione";
                return View();
            }
            finally
            {
                conn.Close();
            }
        }

        public ActionResult RegistraAggiornamento()
        {
            string connString = ConfigurationManager
                .ConnectionStrings["myConnection"]
                .ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connString);

            try
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM Spedizioni";
                SqlCommand cmd = new SqlCommand(query, conn);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ViewBag.NumberOfSpedizioni = reader.GetInt32(0);
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
                ViewBag.Error = "Errore nel reperimento del numero delle spedizioni";
                return View();
            }
            finally
            {
                conn.Close();
            }

            return View();
        }

        [HttpPost]
        public ActionResult RegistraAggiornamento(Aggiornamento a)
        {
            string connString = ConfigurationManager
                .ConnectionStrings["myConnection"]
                .ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connString);

            try
            {
                conn.Open();
                string query =
                    "INSERT INTO Aggiornamenti (IdSpedizione, Stato, Luogo, Descrizione, Ora_Registrazione) VALUES (@IdSpedizione, @Stato, @Luogo, @Descrizione, @Ora_Registrazione)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IdSpedizione", a.IdSpedizione);
                cmd.Parameters.AddWithValue("@Stato", a.Stato);
                cmd.Parameters.AddWithValue("@Luogo", a.Luogo);
                if (a.Descrizione != null)
                {
                    cmd.Parameters.AddWithValue("@Descrizione", a.Descrizione);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Descrizione", "");
                }
                cmd.Parameters.AddWithValue("@Ora_Registrazione", DateTime.Now);

                cmd.ExecuteNonQuery();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
                ViewBag.Error = "Errore nella registrazione del nuovo aggiornamento";
                return View();
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
