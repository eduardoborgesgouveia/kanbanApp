using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KanbanApp.Models
{
    public class UserToken
    {
        public string token { get; set; }
        public DateTime expirationDate { get; set; }
    }
}
