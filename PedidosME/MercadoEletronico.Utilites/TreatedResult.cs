using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MercadoEletronico.Utilities
{
    public struct TreatedResult
    {
        private static readonly string[] emptyFailures = new string[0];
        public bool Success { get; private set; }
        public IReadOnlyCollection<string> Failures { get; private set; }

        public static TreatedResult OK() => new TreatedResult { Success = true, Failures = emptyFailures };

        public static TreatedResult NotOK(IEnumerable<string> failures) => 
            new TreatedResult { Success = false, Failures = failures?.ToArray() ?? emptyFailures };

        public static implicit operator bool(TreatedResult treatedResult) => treatedResult.Success;

    }

    public struct TreatedResult<TObj> 
    {
        private static readonly string[] emptyFailures = new string[0];
        public bool Success { get; private set; }
        public TObj Value { get; private set; }
        public IReadOnlyCollection<string> Failures { get; private set; }

        public static TreatedResult<TObj> OK(TObj value) => 
            new TreatedResult<TObj>() { Success = true, Value = value, Failures = emptyFailures };

        public static TreatedResult<TObj> NotOK(IEnumerable<string> failures) =>
            new TreatedResult<TObj> { Success = false, Failures = failures?.ToArray() ?? emptyFailures };

        public static TreatedResult<TObj> NotOK(TObj value, IEnumerable<string> failures) =>
            new TreatedResult<TObj>() { Success = false, Value = value, Failures = failures?.ToArray() ?? emptyFailures };



    }
}
