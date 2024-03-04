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
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LoginAdmin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginAdmin(Amministratore a)
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
                        this.Session["Errore"] = "Password sbagliata";
                        return View();
                    }
                    else
                    {
                        this.Session["Account"] = "admin";
                        return RedirectToAction("Index", "Prodotti");
                    }
                }
                else
                {
                    this.Session["Errore"] = "Nessun amministratore con questo Username";
                    return View();
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
                this.Session["Errore"] = "Errore nella Login";
                return View();
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
