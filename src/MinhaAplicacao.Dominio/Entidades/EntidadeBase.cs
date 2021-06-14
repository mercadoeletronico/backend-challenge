using System;

namespace MinhaAplicacao.Dominio.Entidades
{
    public abstract class EntidadeBase<TId>
        where TId : IEquatable<TId>
    {
        public TId Id { get; set; }
        public DateTime DataHoraCadastro { get; set; }
        public DateTime? DataHoraModificado { get; set; }
    }
}
