using RepoPattrenWithUnitOfWork.EF.Triggers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoPattrenWithUnitOfWork.Core.Models
{
    public class Author :ISoftDeletable
    {
        public int Id { get; set; }
        [Required,MaxLength(150)]
        public string Name { get; set; }

        public bool IsDeleted { get; set; } = false;
        public DateTime? DeletedAt { get; set; }
    }
}
