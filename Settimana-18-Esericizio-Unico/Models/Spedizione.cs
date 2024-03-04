using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static Settimana_18_Esericizio_Unico.CustomValidations.CustomCheckIfOnlyNumbers;
using static Settimana_18_Esericizio_Unico.CustomValidations.CustomNotBeforeToday;

namespace Settimana_18_Esericizio_Unico.Models
{
    public class Spedizione
    {
        [ScaffoldColumn(false)]
        public int IdSpedizione { get; set; }

        [Required(ErrorMessage = "Questo campo è obbligatorio")]
        public int IdCliente { get; set; }

        [Required(ErrorMessage = "Questo campo è obbligatorio")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Lunghezza esatta di 10 caratteri")]
        /*[CustomCheckIfOnlyNumbers(
            ErrorMessage = "Questo campo deve contenere una serie di soli numeri"
        )]*/
        public string Numero_Identificativo { get; set; }

        [Required(ErrorMessage = "Questo campo è obbligatorio")]
        /*[CustomNotBeforeToday(ErrorMessage = "La data deve essere antecedente a quella odierna")]*/
        public DateTime Data_Spedizione { get; set; }

        [Required(ErrorMessage = "Questo campo è obbligatorio")]
        [Range(0, 100000000000, ErrorMessage = "Il peso deve essere maggiore di 0")]
        public double Peso { get; set; }

        [Required(ErrorMessage = "Questo campo è obbligatorio")]
        [MaxLength(50, ErrorMessage = "Lunghezza massima 50 caratteri")]
        public string Città_Destinataria { get; set; }

        [Required(ErrorMessage = "Questo campo è obbligatorio")]
        [MaxLength(50, ErrorMessage = "Lunghezza massima 50 caratteri")]
        public string Indirizzo { get; set; }

        [Required(ErrorMessage = "Questo campo è obbligatorio")]
        [MaxLength(50, ErrorMessage = "Lunghezza massima 50 caratteri")]
        public string Nominativo { get; set; }

        [Required(ErrorMessage = "Questo campo è obbligatorio")]
        [Range(0, 100000000000, ErrorMessage = "Il costo deve essere maggiore di 0")]
        public double Costo_Spedizione { get; set; }

        [Required(ErrorMessage = "Questo campo è obbligatorio")]
        /*[CustomNotBeforeToday(ErrorMessage = "La data deve essere antecedente a quella odierna")]*/
        public DateTime Data_Consegna { get; set; }

        public Spedizione() { }

        public Spedizione(
            int idSpedizione,
            int idCliente,
            string numero_Identificativo,
            DateTime data_Spedizione,
            double peso,
            string città_Destinataria,
            string indirizzo,
            string nominativo,
            double costo_Spedizione,
            DateTime data_Consegna
        )
        {
            IdSpedizione = idSpedizione;
            IdCliente = idCliente;
            Numero_Identificativo = numero_Identificativo;
            Data_Spedizione = data_Spedizione;
            Peso = peso;
            Città_Destinataria = città_Destinataria;
            Indirizzo = indirizzo;
            Nominativo = nominativo;
            Costo_Spedizione = costo_Spedizione;
            Data_Consegna = data_Consegna;
        }
    }
}
