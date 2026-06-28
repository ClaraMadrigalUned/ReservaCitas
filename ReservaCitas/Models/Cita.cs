using System;
using System.ComponentModel.DataAnnotations;

namespace ReservaCitas.Models
{
    // Modelo que representa la información de una cita o reserva.
    public class Cita
    {
        // Identificador único de la cita.
        public int Id { get; set; }


        // Datos del cliente.
        [Required(ErrorMessage = "Por favor, ingrese el nombre del cliente.")]
        [Display(Name = "Nombre del cliente")]
        public string NombreCliente { get; set; }

        [Required(ErrorMessage = "Por favor, ingrese el servicio.")]
        public string Servicio { get; set; }

        [Required(ErrorMessage = "Por favor, ingrese la fecha.")]
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "Por favor, ingrese la hora.")]
        [DataType(DataType.Time)]
        public DateTime Hora { get; set; }

        public string Observaciones { get; set; }

        [Required(ErrorMessage = "Por favor, ingrese seleccione un estado.")]
        public string Estado { get; set; }
    }
}