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
    [Authorize]
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
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
    }
}
