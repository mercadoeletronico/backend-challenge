using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BackendChallenge.Api.Model.Request
{
    public class NewOrderRequest
    {
        [Required]
        [MinLength(1)]
        public List<NewItemRequest> Items { get; set; }
    }
}