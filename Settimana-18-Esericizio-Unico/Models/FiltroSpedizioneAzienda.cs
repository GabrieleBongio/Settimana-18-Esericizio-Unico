using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Settimana_18_Esericizio_Unico.Models
{
    public class FiltroSpedizioneAzienda
    {
        [Required(ErrorMessage = "Questo campo è obbligatorio")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Lunghezza esatta di 11 caratteri")]
        [Display(Name = "Partita Iva")]
        public string P_Iva { get; set; }

        [Required(ErrorMessage = "Questo campo è obbligatorio")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Lunghezza esatta di 10 caratteri")]
        [RegularExpression(
            @"^[0-9]+$",
            ErrorMessage = "questo campo deve essere compilato con una serie di soli numeri"
        )]
        public string Numero_Identificativo { get; set; }
    }
}
