using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Shop.ApplicationServices.IServices;
using Shop.ApplicationServices.Services;
using Shop.DTOs.Vander;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VenderController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IVanderService VanderService;
        public VenderController(IVanderService vanderService,IMapper mapper)
        {
            VanderService = vanderService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetById(int Id)
        {
            var result = VanderService.GetById(Id);
            return Ok(result);
        }
        [HttpPost]
        [Route("Insert")]
        public IActionResult Insert([FromBody] VanderInsertDTO DTO)
        {
            var result = VanderService.Insert(DTO);
            if (result == true)
            {
                return Ok();
            }
            else
            {
                throw new Exception();
            }
        }
        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, UpdateVenderDTO DTO)
        {
            var result = VanderService.Update(DTO, id);
            if (result == true)
            {
                return Ok();
            }
            else
            {
                throw new Exception();
            }
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var result = VanderService.Delete(id);
            if (result == true)
            {
                return Ok();
            }
            else
            {
                throw new Exception();
            }
        }
        [HttpPatch("id")]
        public IActionResult PatchUpdate(int id, JsonPatchDocument<UpdateVenderDTO> DTO)
        {
            var result = VanderService.GetById(id);
            if (result == null)
            {
                return NotFound();
            }

            var Patch = _mapper.Map<UpdateVenderDTO>(result);

            DTO.ApplyTo(Patch, ModelState);

            _mapper.Map(Patch, result);

            return Ok(_mapper.Map<UpdateVenderDTO>(result));
        }
    }
}
