using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MercadoEletronico.Teste.Api.ViewModels
{
    public class PedidoViewModel
    {
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 1)]
        public IEnumerable<ItemViewModel> Itens { get; set; }
    }
}
