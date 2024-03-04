using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Settimana_18_Esericizio_Unico.Models
{
    public class Aggiornamento
    {
        [ScaffoldColumn(false)]
        public int IdAggiornamento { get; set; }

        [Required(ErrorMessage = "Questo campo è obbligatorio")]
        public int IdSpedizione { get; set; }

        [Required(ErrorMessage = "Questo campo è obbligatorio")]
        public string Stato { get; set; }

        [Required(ErrorMessage = "Questo campo è obbligatorio")]
        [MaxLength(50, ErrorMessage = "Lunghezza massima 50 caratteri")]
        public string Luogo { get; set; }

        public string Descrizione { get; set; }

        [ScaffoldColumn(false)]
        public DateTime Ora_Registrazione { get; set; }

        public Aggiornamento() { }

        public Aggiornamento(
            int idAggiornamento,
            int idSpedizione,
            string stato,
            string luogo,
            string descrizione,
            DateTime ora_Registrazione
        )
        {
            IdAggiornamento = idAggiornamento;
            IdSpedizione = idSpedizione;
            Stato = stato;
            Luogo = luogo;
            Descrizione = descrizione;
            Ora_Registrazione = ora_Registrazione;
        }
    }
}
