using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Settimana_18_Esericizio_Unico.Models
{
    public class ClienteAzienda
    {
        [ScaffoldColumn(false)]
        public int IdCliente { get; set; }

        [Required(ErrorMessage = "Questo campo è obbligatorio")]
        [MaxLength(40, ErrorMessage = "Lunghezza massima 40 caratteri")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Questo campo è obbligatorio")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Lunghezza esatta di 11 caratteri")]
        public string P_Iva { get; set; }

        public ClienteAzienda() { }

        public ClienteAzienda(int idCliente, string nome, string p_Iva)
        {
            IdCliente = idCliente;
            Nome = nome;
            P_Iva = p_Iva;
        }
    }
}
