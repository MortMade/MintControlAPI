using System;
using System.Collections.Generic;
using System.Linq;
using MintControlAPI.Models;

namespace MintControlAPI.Managers
{
    public class FunctionsManager
    {
        private MintContext context;
        
        public FunctionsManager(MintContext context)
        {
            this.context = context;
        }

        public List<FunctionModel> GetAll()
        {

            return context.Functions.ToList();
        }

        public List<FunctionModel> GetByUserName(string userName)
        {
            /*
             * Det her ville tage for lang tid ...
            List < FunctionModel> alllist = GetAll();
            List < UserModel> allusers = context.Users.ToList();
            List<FunctionModel> sortlist = new List<FunctionModel>();
            UserModel current = new UserModel();
            foreach (var item in allusers)
            {
                if (item.Username == userName)
                {
                    current = item;
                }
            }

            foreach (var item in alllist)
            {
                if (current.UserId == item.UserId)
                {
                    sortlist.Add(item);
                }
            }
            return sortlist;
            */
            long userId = 0;
            try
            {
                userId = context.Users.Where(e => e.Username == userName).Select(s => s.UserId).Single();
            }
            catch (Exception)
            {
                UserModel newUser = new UserModel();
                newUser.Username = userName;
                context.Users.Add(newUser);
                context.SaveChanges();
            }
            
            return context.Functions.Where(e => e.UserId == userId || e.UserId == 1).Select(s => s).ToList();
        }

        public FunctionModel GetById(long id)
        {
            return context.Functions.Find(id);
        }

        public FunctionModel Add(FunctionModel value)
        {
            context.Functions.Add(value);
            context.SaveChanges();
            return value;
        }
        public FunctionModel AddToUser(FunctionModel value, string userName)
        {
            long userId = 0;
            try
            {
                userId = context.Users.Where(e => e.Username == userName).Select(s => s.UserId).Single();
            }
            catch (Exception)
            {
                //TODO what to do if user doesnt exist, throw exception
                throw;
            }
            value.UserId = userId;
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
