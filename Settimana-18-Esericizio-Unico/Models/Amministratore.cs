using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Settimana_18_Esericizio_Unico.Models
{
    public class Amministratore
    {
        [Required(ErrorMessage = "Questo campo è obbligatorio")]
        [MaxLength(40, ErrorMessage = "Lunghezza massima 40 caratteri")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Questo campo è obbligatorio")]
        [DataType(DataType.Password)]
        [MaxLength(40, ErrorMessage = "Lunghezza massima 40 caratteri")]
        public string Password { get; set; }
    }
}
