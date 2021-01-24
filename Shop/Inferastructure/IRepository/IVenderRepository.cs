using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Inferastructure.IRepository
{
    public interface IVenderRepository
    {
        Vender GetByIdVender(int id);
        Vender GetById(int Id);
        int Insert(Vender vender);
        int Update(Vender vender);
        int Delete(Vender vender);
    }
}
