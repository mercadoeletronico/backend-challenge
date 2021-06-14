using System;
using System.ComponentModel.DataAnnotations;

namespace MinhaAplicacao_API.V1.Models
{
    public class ModelBase<TId>
        where TId : IEquatable<TId>
    {
        [Key]
        public TId Id { get; set; }
    }
}
