using System;
using System.ComponentModel.DataAnnotations;

namespace BackendChallenge.Api.Model.Request
{
    public class NewItemRequest
    {
        [Required]
        public string Descricao { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public Int32 PrecoUnitario { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public Int32 Qtd { get; set; }
    }
}