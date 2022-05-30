using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProvaTecnica3.Models
{
    public class Emprestimo
    {
        public int EmprestimoId { get; set; }

        [Display(Name = "Cliente")]
        public Cliente? Clientes { get; set; }
        public int ClienteId { get; set; }

        [Display(Name = "Valor do Emprestimo")]
        public double ValorEmprestimo { get; set; }

        [Display(Name = "Juros (%)")]
        public double Juros { get; set; }

        [Display(Name = "Quantidade de Parcelas")]
        public int QtdParcelas { get; set; }

        [Display(Name = "Valor das Parcelas")]
        public double ValorParcela { get; set; }

        [Display(Name = "Valor Total Atual")]
        public double JurosPago { get; set; }

        [Display(Name = "Pago")]
        public bool IsPago { get; set; }

        public ICollection<Pagamento>? Pagamentos { get; set; }
    }
}
