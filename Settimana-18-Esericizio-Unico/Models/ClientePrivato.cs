using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;

namespace Settimana_18_Esericizio_Unico.Models
{
    public class ClientePrivato
    {
        [ScaffoldColumn(false)]
        public int IdCliente { get; set; }

        [Required(ErrorMessage = "Questo campo è obbligatorio")]
        [MaxLength(40, ErrorMessage = "Lunghezza massima 40 caratteri")]
        public string Nome { get; set; }

        [Display(Name = "Codice Fiscale")]
        [Required(ErrorMessage = "Questo campo è obbligatorio")]
        [StringLength(16, MinimumLength = 16, ErrorMessage = "Lunghezza esatta di 16 caratteri")]
        public string Cod_Fisc { get; set; }

        public ClientePrivato() { }

        public ClientePrivato(int idCliente, string nome, string cod_Fisc)
        {
            IdCliente = idCliente;
            Nome = nome;
            Cod_Fisc = cod_Fisc;
        }
    }
}
