using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GDev.WebApp.ViewModels
{
    public class AcessoViewModel
    {
        [Key]
        public Guid Id { get; set; }        
                
        [Required(ErrorMessage = "O campo {0} e obrigatorio.")]
        public string Url { get; set; }
        public string Token { get; set; }

        [DisplayName("Data de Cadastro")]
        public DateTime DiaCadastro { get; set; }
        [DisplayName("Data de Alteração")]
        public DateTime? DiaAlteracao { get; set; }
        public ModuloViewModel Modulo { get; set; }
        public ClienteViewModel Cliente { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Modulo")]
        public Guid ModuloId { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Cliente")]
        public Guid ClienteId { get; set; }
        public IEnumerable<ClienteViewModel> Clientes { get; set; }
        public IEnumerable<ModuloViewModel> Modulos { get; set; }

    }
}
