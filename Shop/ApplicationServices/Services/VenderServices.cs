using Shop.ApplicationServices.IServices;
using Shop.DTOs.Tags;
using Shop.DTOs.Vander;
using Shop.Inferastructure.IRepository;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.ApplicationServices.Services
{
    public class VenderServices : IVanderService
    {
        private readonly IVenderRepository _repository;
        public VenderServices(IVenderRepository repository)
        {
            _repository = repository;
        }
        public VanderListDTO GetById(int Id)
        {
            var vender = _repository.GetByIdVender(Id);
            var result = new VanderListDTO
            {
                Id = vender.Id,
                Name = vender.Name,
                Title = vender.Title,
                Date = vender.Date,
                Tags = vender.Tags.Select(m => m.Name).ToList()
            };
            return result;
        }
        public bool Insert(VanderInsertDTO DTO)
        {
            bool result = false;
            var List = new List<Tags>();
            if (DTO.Tags != null && DTO.Tags.Count > 0)
            {
                foreach (var item in DTO.Tags)
                {
                    Tags tags = new Tags();
                    tags.Name = item.Name;
                    tags.Family = item.Family;
                    tags.Address = item.Address;
                    tags.PhoneNumber = item.PhoneNumber;
                    tags.PhoneMobile = item.PhoneMobile;
                    List.Add(tags);

                }
            }
            var vender = new Vender()
            {
                Name = DTO.Name,
                Title = DTO.Title,
                Date = DTO.Date,
                Tags = List
            };

            int inserted = _repository.Insert(vender);
            if (inserted > 0)
            {
                result = true;
            }
            return result;
        }
        public bool Update(UpdateVenderDTO venderDTO, int ID)
        {
            bool result = false;
            var List = new List<Tags>();

            //ToDO Remove Tags
            foreach (var item in venderDTO.Tags)
            {
                Tags tags = new Tags();
                tags.Name = item.Name;
                tags.Family = item.Family;
                tags.Address = item.Address;
                tags.PhoneNumber = item.PhoneNumber;
                tags.PhoneMobile = item.PhoneMobile;
                List.Add(tags);
            }
            var venid = _repository.GetById(ID);

            venid.Name = venderDTO.Name;
            venid.Title = venderDTO.Title;
            venid.Date = venderDTO.Date;
            venid.Tags = List;

            int instred = _repository.Update(venid);
            if (instred > 0)
            {
                result = true;
            }
            return result;
        }
        public bool Delete(int ID)
        {
            bool result = false;
            var Id = _repository.GetById(ID);
            var instred = _repository.Delete(Id);
            if (instred > 0)
            {
                result = true;
            }
            return result;
        }
    }
}
