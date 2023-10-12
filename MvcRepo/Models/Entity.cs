using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcRepo.Models
{
    public class Entity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }

    }
}