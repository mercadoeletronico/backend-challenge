using DomainValidation.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pedido.Domain.Models
{
	public abstract class Entidade
	{
		public ValidationResult ValidationResult { get; private set; }

	}
}
