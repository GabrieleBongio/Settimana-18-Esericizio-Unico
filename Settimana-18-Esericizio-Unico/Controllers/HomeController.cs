using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Settimana_18_Esericizio_Unico.Models;

namespace Settimana_18_Esericizio_Unico.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Amministratore a)
        {
            string connString = ConfigurationManager
                .ConnectionStrings["myConnection"]
                .ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connString);

            try
            {
                conn.Open();
                string query = "SELECT * FROM Amministratori WHERE Username = @Username";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Username", a.Username);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    if (reader.GetString(2) != a.Password)
                    {
                        ViewBag.Error = "Password sbagliata";
                        return View();
                    }
                    else
                    {
                        FormsAuthentication.SetAuthCookie(a.Username, false);
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    ViewBag.Error = "Nessun amministratore con questo Username";
                    return View();
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
                ViewBag.Error = "Errore nella Login";
                return View();
            }
            finally
            {
                conn.Close();
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }

        public ActionResult RicercaSpedizioniCliente()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RicercaSpedizioniCliente(FiltroSpedizioniCliente f)
        {
            string connString = ConfigurationManager
                .ConnectionStrings["myConnection"]
                .ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connString);

            try
            {
                conn.Open();
                string query =
                    "SELECT IdSpedizione FROM Spedizioni INNER JOIN Clienti ON Clienti.IdCliente = Spedizioni.IdCliente WHERE Cod_Fisc = @Cod_Fisc AND Numero_Identificativo = @Numero_Identificativo";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Cod_Fisc", f.Cod_Fisc);
                cmd.Parameters.AddWithValue("@Numero_Identificativo", f.Numero_Identificativo);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    TempData["IdSpedizione"] = reader.GetInt32(0);
                    return RedirectToAction("DettagliSpedizione");
                }
                else
                {
                    ViewBag.Error = "Nessuna spedizione con questi dati, controlla e riprova";
                    return View();
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
                ViewBag.Error = "Errore nel tentativo di recuperare le informazioni, riprova";
                return View();
            }
            finally
            {
                conn.Close();
            }
        }

        public ActionResult RicercaSpedizioniAzienda()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RicercaSpedizioniAzienda(FiltroSpedizioneAzienda f)
        {
            string connString = ConfigurationManager
                .ConnectionStrings["myConnection"]
                .ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connString);

            try
            {
                conn.Open();
                string query =
                    "SELECT IdSpedizione FROM Spedizioni INNER JOIN Clienti ON Clienti.IdCliente = Spedizioni.IdCliente WHERE P_Iva = @P_Iva AND Numero_Identificativo = @Numero_Identificativo";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@P_Iva", f.P_Iva);
                cmd.Parameters.AddWithValue("@Numero_Identificativo", f.Numero_Identificativo);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    TempData["IdSpedizione"] = reader.GetInt32(0);
                    return RedirectToAction("DettagliSpedizione");
                }
                else
                {
                    ViewBag.Error = "Nessuna spedizione con questi dati, controlla e riprova";
                    return View();
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
                ViewBag.Error = "Errore nel tentativo di recuperare le informazioni, riprova";
                return View();
            }
            finally
            {
                conn.Close();
            }
        }

        public ActionResult DettagliSpedizione()
        {
            int IdSpedizione = Convert.ToInt32(TempData["IdSpedizione"]);

            List<Aggiornamento> listaAggiornamenti = new List<Aggiornamento>();

            string connString = ConfigurationManager
                .ConnectionStrings["myConnection"]
                .ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connString);

            try
            {
                conn.Open();
                string query = "SELECT * FROM Aggiornamenti WHERE IdSpedizione = @IdSpedizione";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IdSpedizione", IdSpedizione);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    listaAggiornamenti.Add(
                        new Aggiornamento(
                            reader.GetInt32(0),
                            reader.GetInt32(1),
                            reader.GetString(2),
                            reader.GetString(3),
                            reader.GetString(4),
                            reader.GetDateTime(5)
                        )
                    );
                }
                listaAggiornamenti.Reverse();

                return View(listaAggiornamenti);
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
                ViewBag.Error = "Errore nel tentativo di recuperare le informazioni, riprova";
                return View();
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
