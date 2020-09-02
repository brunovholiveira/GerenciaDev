using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GDev.WebApp.ViewModels
{
    public class ModuloViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} e obrigatorio. ")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1}.", MinimumLength = 2)]
        [DisplayName("Descrição")]
        public string Descricao { get; set; }

        [DisplayName("Data de Cadastro")]
        public DateTime DiaCadastro { get; set; }
        [DisplayName("Data de Alteração")]
        public DateTime? DiaAlteracao { get; set; }
        public IEnumerable<AcessoViewModel> Acessos { get; set; }
    }
}
