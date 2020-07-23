 using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyTodoList.Models
{
    public class Todo
    {
        public int Id { get; set; }
        [DisplayName("Title")]
        [Required]
        [StringLength(100)]
        public string Title { get; set; }
        public DateTime DateStart { get; set; }
    }
}
