using RepoPattrenWithUnitOfWork.Core.Const;
using RepoPattrenWithUnitOfWork.Core.Data;
using RepoPattrenWithUnitOfWork.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RepoPattrenWithUnitOfWork.Core.Interface.Service
{
    public interface IAuthorService
    {

     //   Author? GetById(int id);
        Task<DtoAuthor> GetByIdAsync(int id);
        IEnumerable<DtoAuthor> GetAll();
        DtoAuthor Find(int id);//int only
        IEnumerable<DtoAuthor> FindAll(String name);//name

        int Add(DtoAuthor DtoAuthor);  // take dto return  int

        DtoAuthor Update(DtoAuthor entity);

        void Delete(DtoAuthor entity);

        void Attach(DtoAuthor entity);
        int Count();
 

    }
}
