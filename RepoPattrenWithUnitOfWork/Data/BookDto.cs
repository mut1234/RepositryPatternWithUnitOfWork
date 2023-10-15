using RepoPattrenWithUnitOfWork.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoPattrenWithUnitOfWork.Core.Data
{
    public class BookDto
    {
        public int Id { get; set; }
        [Required, MaxLength(250)]
        public string Title { get; set; }

        public Author Author { get; set; }

        public int AuthorId { get; set; }
    }
}
