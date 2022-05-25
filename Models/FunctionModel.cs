using System;
using System.ComponentModel.DataAnnotations;

namespace MintControlAPI.Models
{
    public class FunctionModel
    {
        public FunctionModel()
        {
        }
        [Key]
        public long FuncId { get; set; }
        public string Title { get; set; }
        public string Command { get; set; }
        public long UserId { get; set; }
        public long FuncRights { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
