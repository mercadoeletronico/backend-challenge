using System;
using System.ComponentModel.DataAnnotations;

namespace BackendChallenge.Api.Model.Response
{
    public class ItemResponse
    {
        [Required]
        public string Descricao { get; set; }
        public Int32 PrecoUnitario { get; set; }
        public Int32 Qtd { get; set; }
    }
}