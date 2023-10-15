﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoPattrenWithUnitOfWork.Core.Data
{
    public class DtoAuthor
    {
        public int Id { get; set; }
        [Required, MaxLength(150)]
        public string Name { get; set; }

    }
}