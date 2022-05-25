using System;
using System.Collections.Generic;
using System.Linq;
using MintControlAPI.Models;

namespace MintControlAPI.Managers
{
    public class FunctionsManager
    {

        private static int _nextId = 1;
        private MintContext context;
        private static readonly List<FunctionModel> Data = new List<FunctionModel>
        {
            new FunctionModel {FuncId = _nextId++, Title = "C# is nice", Command = "HEJ", UserId = 1, FuncRights = 0},
            new FunctionModel {FuncId=_nextId++, Title = "Python is even nicer", Command = "Abe", UserId = 2, FuncRights = 0}
            // https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/object-and-collection-initializers
        };

        public FunctionsManager(MintContext context)
        {
            this.context = context;
        }

        public IEnumerable<FunctionModel> GetAll()
        {

            return context.Functions.ToList();
        }

        public FunctionModel Add(FunctionModel value)
        {
            value.FuncId = _nextId++;
            Data.Add(value);
            return value;
        }

        public FunctionModel Update(int id, FunctionModel value)
        {
            throw new NotImplementedException();
        }

        public FunctionModel Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
