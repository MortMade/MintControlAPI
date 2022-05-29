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

        public IEnumerable<FunctionModel> GetByUserName(string userName)
        {
            long userId = 0;
            try
            {
                userId = context.Users.Where(e => e.Username == userName).Select(s => s.UserId).Single();
            }
            catch (Exception)
            {
                //TODO if none exist create a new user...
            }
            
            return context.Functions.Where(e => e.UserId == userId || e.UserId == 1).Select(s => s).ToList();
        }

        public FunctionModel Add(FunctionModel value)
        {
            context.Functions.Add(value);
            context.SaveChanges();
            return value;
        }


        public FunctionModel Update(long id, FunctionModel value)
        {
            FunctionModel FunctionToUpdate = context.Functions.Find(id);
            if (FunctionToUpdate == null) return null;
            FunctionToUpdate.Title = value.Title;
            FunctionToUpdate.Command = value.Command;
            FunctionToUpdate.UserId = value.UserId;
            FunctionToUpdate.FuncRights = value.FuncRights;
            context.SaveChanges();
            return FunctionToUpdate;
        }

        public FunctionModel Delete(long id)
        {
            FunctionModel FunctionToDelete = context.Functions.Find(id);
            if (FunctionToDelete == null) return null;
            context.Functions.Remove(FunctionToDelete);
            context.SaveChanges();
            return FunctionToDelete;
        }
    }
}
