using NSubstitute;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Infra.Data
{
    public class ContextdatabaseInMemory : IDatabaseContext 
    {
        #region properties
        public IDatabaseContext Context { get; }
        #endregion

        #region constructors
        public ContextdatabaseInMemory()
        {  
            this.Context = Substitute.For<IDatabaseContext>();
            this.Context.Connection.Returns(InMemoryDatabase.Connection);
        }
        #endregion

        #region actions
        public IDbConnection Connection => this.Context.Connection;
        #endregion


    }
}
