using Shop.DTOs.Vander;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.ApplicationServices.IServices
{
    public interface IVanderService
    {
        VanderListDTO GetById(int Id);
        bool Insert(VanderInsertDTO DTO);
        bool Update(UpdateVenderDTO vender, int ID);
        bool Delete(int ID);
    }
}
