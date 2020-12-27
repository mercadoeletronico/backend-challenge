using Infra.Data;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTests
{
    public abstract class RepositoryTest
    {
        protected RepositoryTest()
        {
            InMemoryDatabase.CreateTable();

            this.Context = Substitute.For<IDatabaseContext>();
            this.Context.Connection.Returns(InMemoryDatabase.Connection);
        }

        protected IDatabaseContext Context { get; }
    }
}
