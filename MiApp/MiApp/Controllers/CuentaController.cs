using MiApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;


public class CuentaController : Controller
{
    private ApplicationDbContext db = new ApplicationDbContext();

    // GET: Cuenta/Login
    public ActionResult Login()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Login(string nombreUsuario, string contraseña)
    {
        var usuario = db.Usuarios.FirstOrDefault(u => u.NombreUsuario == nombreUsuario && u.Contraseña == contraseña);

        if (usuario != null)
        {
            FormsAuthentication.SetAuthCookie(nombreUsuario, false);
            return RedirectToAction("Index", "Inicio"); // Cambia "Inicio" al controlador y vista principal de tu aplicación
        }
        else
        {
            ModelState.AddModelError("", "Nombre de usuario o contraseña incorrectos.");
            return View();
        }
    }

    public ActionResult Logout()
    {
        FormsAuthentication.SignOut();
        return RedirectToAction("Login");
    }
}
