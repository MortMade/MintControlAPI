using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MintControlAPI.Models
{
    public class UserModel
    {
        public UserModel()
        {

        }
        [Key]
        public long UserId { get; set; }
        public string Username { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
