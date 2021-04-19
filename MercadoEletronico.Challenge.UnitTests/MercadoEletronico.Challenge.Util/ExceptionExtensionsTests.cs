using MercadoEletronico.Challenge.Util;
using MercadoEletronico.Challenge.Util.Extensions;
using System;
using System.Collections.Generic;
using Xunit;

namespace MercadoEletronico.Challenge.UnitTests.MercadoEletronico.Challenge.Util
{
    public class ExceptionExtensionsTests
    {
        [Theory]
        [InlineData(typeof(ArgumentException))]
        [InlineData(typeof(ArgumentNullException))]
        [InlineData(typeof(ArgumentOutOfRangeException))]
        public void GetResultStatus_MustReturnBadRequestWhenArgumentExceptions(Type exceptionType)
        {
            // Arrange
            var exception = (Exception)Activator.CreateInstance(exceptionType);

            // Act
            var resultStatus = exception.GetResultStatus();

            // Assert
            Assert.Equal(ResultStatus.BadRequest, resultStatus);
        }

        [Theory]
        [InlineData(typeof(KeyNotFoundException))]
        public void GetResultStatus_MustReturnNotFoundWhenKeyNotFoundException(Type exceptionType)
        {
            // Arrange
            var exception = (Exception)Activator.CreateInstance(exceptionType);

            // Act
            var resultStatus = exception.GetResultStatus();

            // Assert
            Assert.Equal(ResultStatus.NotFound, resultStatus);
        }

        [Theory]
        [InlineData(typeof(ApplicationException))]
        [InlineData(typeof(AggregateException))]
        [InlineData(typeof(ContextMarshalException))]
        [InlineData(typeof(DivideByZeroException))]
        [InlineData(typeof(StackOverflowException))]
        [InlineData(typeof(InsufficientMemoryException))]
        [InlineData(typeof(InvalidCastException))]
        public void GetResultStatus_MustReturnInternalErrorWhenGenericException(Type exceptionType)
        {
            // Arrange
            var exception = (Exception)Activator.CreateInstance(exceptionType);

            // Act
            var resultStatus = exception.GetResultStatus();

            // Assert
            Assert.Equal(ResultStatus.InternalError, resultStatus);
        }
    }
}
