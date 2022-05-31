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

        [Display(Name = "Valor Emprestimo")]
        public double ValorEmprestimo { get; set; }

        [Display(Name = "Juros(%)")]
        public double Juros { get; set; }

        [Display(Name = "Quantidade Parcelas")]
        public int QtdParcelas { get; set; }

        [Display(Name = "Valor Parcelas")]
        public double ValorParcela { get; set; }

        [Display(Name = "Qtd Parcelas pagas")]
        public double QtdParcelaspagas { get; set; }

        [Display(Name = "Valor Atual")]
        public double JurosPago { get; set; }

        [Display(Name = "Pago")]
        public bool IsPago { get; set; }

        public ICollection<Pagamento>? Pagamentos { get; set; }
    }
}
