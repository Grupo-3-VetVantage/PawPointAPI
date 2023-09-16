using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PawPoint.API.Input;
using PawPoint.API.Response;
using PawPoint.Domain.Interfaces;
using PawPoint.Infraestructure.Interfaces;
using PawPoint.Infraestructure.Models;

namespace PawPoint.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        private IPetDomain _petDomain;
        private IPetInfraestructure _petInfraestructure;
        private IMapper _mapper;
        
        public PetController (IPetDomain petDomain, IPetInfraestructure petInfraestructure, IMapper mapper)
        {
            _petDomain = petDomain;
            _petInfraestructure = petInfraestructure;
            _mapper = mapper;
        }

        
        // GET: api/Pet
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result=await _petInfraestructure.GetPetsAsync();
            var list=_mapper.Map<List<Pet>,List<PetResponse>>(result);
            return Ok(list);
        }

        // GET: api/Pet/5
        [HttpGet("{id}", Name = "GetPet")]
        public async Task<IActionResult> GetById(int id)
        {
            var petFound = await _petInfraestructure.GetPetByIdAsync(id);
            if (petFound == null) return NotFound();
            var result = _mapper.Map<Pet,PetResponse>(petFound);
            
            return Ok(result);
            
        }

        // POST: api/Pet
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PetCreateInput petInput)
        {
            if (ModelState.IsValid)
            {
                var pet=_mapper.Map<PetCreateInput,Pet>(petInput);
                await _petDomain.CreatePetAsync(pet);
                
            }
            else
            {
                return BadRequest();
            }
            return Ok();
        }

        // PUT: api/Pet/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] PetCreateInput petInput)
        {
            if (ModelState.IsValid)
            {
                var pet=_mapper.Map<PetCreateInput,Pet>(petInput);
                await _petDomain.UpdatePetAsync(id,pet);
                
            }
            else
            {
                return BadRequest();
            }
            return Ok();
        }

        // DELETE: api/Pet/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _petDomain.DeletePetAsync(id);
            return Ok();
        }
    }
}
