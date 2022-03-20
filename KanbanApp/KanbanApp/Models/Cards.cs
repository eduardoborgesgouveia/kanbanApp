using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KanbanApp.Models
{
    public class Cards
    {
        public Guid id { get; set; }
        [Required]
        public string titulo { get; set; }
        [Required]
        public string conteudo { get; set; }
        [Required]
        public string lista { get; set; }
    }
}
