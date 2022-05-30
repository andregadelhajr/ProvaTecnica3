using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProvaTecnica3.Models
{
    public class Cliente
    {
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "Campo Obrigatorio")]
        [Display(Name = "Nome")]
        [StringLength(150, ErrorMessage = "Nome da pessoa deve conter no maximo 150 caracteres")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "Campo Obrigatorio")]
        [RegularExpression(@"^[0-9]{3}\.?[0-9]{3}\.?[0-9]{3}\-?[0-9]{2}$", ErrorMessage = "CPF Inválido")]
        public string? CPF { get; set; }
        public string? CEP { get; set; }

        [Display(Name = "Endereço")]
        public string? Endereco { get; set; }

        [Required(ErrorMessage = "Campo Obrigatorio")]
        [Display(Name = "Telefone")]
        public string? Telefone { get; set; }

        [Required(ErrorMessage = "Campo Obrigatorio")]
        [Display(Name = "E-Mail")]
        [EmailAddress(ErrorMessage = "E-Mail Inválido")]
        public string? Email { get; set; }

        public ICollection<Emprestimo>? Emprestimos { get; set; }
        public ICollection<Pagamento>? Pagamentos { get; set; }
    }
}


