using System;
using System.ComponentModel.DataAnnotations;

namespace MinhaAplicacao_Cliente.Models
{
    public class ModelBase<TId>
        where TId : IEquatable<TId>
    {
        [Key]
        public TId Id { get; set; }
    }
}
