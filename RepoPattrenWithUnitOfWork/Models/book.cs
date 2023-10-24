using RepoPattrenWithUnitOfWork.EF.Triggers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoPattrenWithUnitOfWork.Core.Models

{
    public class Book : ISoftDeletable
    {
        public int Id { get; set; }
        [Required,MaxLength(250)]
        public string Title { get; set; }
        public Author Author { get; set; }
        public int AuthorId { get; set; }
        public bool IsDeleted { get; set; } = false;
        public DateTime? DeletedAt { get; set; }

    }
}
