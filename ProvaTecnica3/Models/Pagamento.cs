using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProvaTecnica3.Models
{
    public class Pagamento
    {
        public int PagamentoId { get; set; }

        [ForeignKey("EmprestimoId")]
        [Display(Name = "Emprestimo")]
        public Emprestimo? Emprestimos { get; set; }
        public int? EmprestimoId { get; set; }

        [Display(Name = "Cliente")]
        public Cliente? Clientes { get; set; }
        public int ClienteId { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data Pagamento")]
        public DateTime DtPagamento { get; set; }

        [Display(Name = "Valor das Parcelas")]
        public double ValorParcela { get; set; }

        [Display(Name = "Pago")]
        public bool IsPago { get; set; }
    }
}
