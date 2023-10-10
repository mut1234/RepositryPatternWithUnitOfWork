﻿using RepoPattrenWithUnitOfWork.Core.Interface;
using RepoPattrenWithUnitOfWork.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoPattrenWithUnitOfWork.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepository<Author> Authors { get; }
        //IBaseRepository<book> Books { get; }
        IBooksRepository Books { get; }

        int Complete();

    }
}
