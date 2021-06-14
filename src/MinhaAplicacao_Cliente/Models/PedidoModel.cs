using System.ComponentModel.DataAnnotations;

namespace MinhaAplicacao_Cliente.Models
{
    public class PedidoModel : ModelBase<int>
    {
        [Display(Name = "Número")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Numero { get; set; }
    }
}
