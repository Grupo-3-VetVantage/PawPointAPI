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
    public class ServiceController : ControllerBase
    {
        private IServiceDomain _serviceDomain;
        private IServiceInfraestructure _serviceInfraestructure;
        private IMapper _mapper;
        
        public ServiceController (IServiceDomain serviceDomain, IServiceInfraestructure serviceInfraestructure, IMapper mapper)
        {
            _serviceDomain = serviceDomain;
            _serviceInfraestructure = serviceInfraestructure;
            _mapper = mapper;
        }
        
        // GET: api/Service
        [HttpGet]
        public async Task< IActionResult> Get()
        {
            var result=await _serviceInfraestructure.GetAllServicesAsync();
            var list=_mapper.Map<List<Service>,List<ServiceResponse>>(result);
            return Ok(list);
        }

        // GET: api/Service/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> GetById(int id)
        {
            var serviceFound = await _serviceInfraestructure.GetServiceByIdAsync(id);
            if (serviceFound == null) return NotFound();
            var result = _mapper.Map<Service,ServiceResponse>(serviceFound);
            
            return Ok(result);
            
        }

        // POST: api/Service
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ServiceCreateInput serviceInput)
        {
            if (ModelState.IsValid)
            {
                var service=_mapper.Map<ServiceCreateInput,Service>(serviceInput);
                await _serviceDomain.CreateServiceAsync(service);
                
            }
            else
            {
                return BadRequest();
            }
            return Ok();
        }

        // PUT: api/Service/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ServiceCreateInput serviceInput)
        {
            if (ModelState.IsValid)
            {
                var service=_mapper.Map<ServiceCreateInput,Service>(serviceInput);
                await _serviceDomain.UpdateServiceAsync(id,service);
                
            }
            else
            {
                return BadRequest();
            }
            return Ok();
           
        }

        // DELETE: api/Service/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _serviceDomain.DeleteServiceAsync(id);
            return Ok();
        }
        
        //
        
    }
}
