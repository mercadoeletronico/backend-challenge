﻿using FluentValidation.Results;
using MediatR;
using System;

namespace ME.PurchaseOrder.Domain.Commands.Base
{
    public class Command : IRequest<ValidationResult>
    {
        public DateTime Timestamp { get; private set; }
        public ValidationResult ValidationResult { get; set; }

        protected Command()
        {
            Timestamp = DateTime.Now;
            ValidationResult = new ValidationResult();
        }

        public virtual bool IsValid()
        {
            return ValidationResult.IsValid;
        }
    }
}