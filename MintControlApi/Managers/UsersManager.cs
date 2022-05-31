using MintControlAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MintControlAPI.Managers
{
    public class UsersManager
    {
        private MintContext context;

        public UsersManager(MintContext context)
        {
            this.context = context;
        }

        public IEnumerable<UserModel> GetAll()
        {
            return context.Users.ToList();
        }

        public UserModel Add(UserModel value)
        {
            context.Users.Add(value);
            context.SaveChanges();
            return value;
        }

        public UserModel Update(long id, UserModel value)
        {
            UserModel userToUpdate = context.Users.Find(id);
            if (userToUpdate == null) return null;
            userToUpdate.Username = value.Username;
            context.SaveChanges();
            return userToUpdate;
        }

        public UserModel Delete(long id)
        {

            UserModel UserToDelete = context.Users.Find(id);
            if (UserToDelete == null) return null;
            context.Users.Remove(UserToDelete);
            context.SaveChanges();
            return UserToDelete;

        }
    }
}
