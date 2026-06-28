using ReservaCitas.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ReservaCitas.Controllers
{
    public class CitasController : Controller
    {
        // Obtiene la lista de citas almacenada en Session
        private List<Cita> ObtenerCitas()
        {
            if (Session["Citas"] == null)
            {  
                Session["Citas"] = new List<Cita>(); // Si aún no existe, crea una nueva lista
            }

            return (List<Cita>)Session["Citas"];
        }

        // Muestra la lista de citas registradas
        public ActionResult Index()
        {
            return View(ObtenerCitas());
        }

        // Muestra el formulario para registrar una nueva cita
        public ActionResult Create()
        {
            return View();
        }

        // Recibe la información del formulario y registra una nueva cita
        [HttpPost]
        public ActionResult Create(Cita cita)
        {
            // Verifica que los datos del formulario sean validos
            if (ModelState.IsValid)
            {
                List<Cita> citas = ObtenerCitas();
                cita.Id = citas.Count + 1; // Asigna un identificador consecutivo
                citas.Add(cita); // Guarda la cita en la lista almacenada en Session
                TempData["Mensaje"] = "La cita fue registrada correctamente."; // Guarda un mensaje temporal para mostrar al usuario

                return RedirectToAction("Index");
            }

            return View(cita);
        }

        // Muestra el detalle de una cita especifica
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            Cita cita = ObtenerCitas().FirstOrDefault(c => c.Id == id);

            return View(cita);
        }

        // Muestra el detalle de una cita especifica
        public ActionResult FiltrarPorEstado(string estado)
        {
            List<Cita> citas = ObtenerCitas();
            if (!string.IsNullOrEmpty(estado))
            {
                citas = citas.Where(c => c.Estado == estado).ToList();
            }

            return PartialView("_TablaCitas", citas);
        }
    }
}