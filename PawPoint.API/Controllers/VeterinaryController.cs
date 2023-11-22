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
    public class VeterinaryController : ControllerBase
    {
        
        private IVeterinaryDomain _veterinaryDomain;
        private IVeterinaryInfraestructure _veterinaryInfraestructure;
        private IMapper _mapper;
        
        public VeterinaryController (IVeterinaryDomain veterinaryDomain, IVeterinaryInfraestructure veterinaryInfraestructure, IMapper mapper)
        {
            _veterinaryDomain = veterinaryDomain;
            _veterinaryInfraestructure = veterinaryInfraestructure;
            _mapper = mapper;
        }
        
        
        // GET: api/Veterinary
        [HttpGet]
        public async Task< IActionResult> Get()
        {
            var result=await _veterinaryInfraestructure.GetAll();
            var list=_mapper.Map<List<Veterinary>,List<VeterinaryResponse>>(result);
            return Ok(list);
        }
        

        // GET: api/Veterinary/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var veterinaryFound = await _veterinaryInfraestructure.GetById(id);
            if (veterinaryFound == null) return NotFound();
            var result = _mapper.Map<Veterinary,VeterinaryResponse>(veterinaryFound);
            
            return Ok(result);
            
        }
        

        // POST: api/Veterinary
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] VeterinaryCreateInput veterinaryInput)
        {
            if (ModelState.IsValid)
            {
                
                var veterinary=_mapper.Map<VeterinaryCreateInput,Veterinary>(veterinaryInput);
                await _veterinaryDomain.CreateVeterinary(veterinary);
                
            }
            else
            {
                return BadRequest();
            }
            return Ok();
        }

        // PUT: api/Veterinary/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] VeterinaryCreateInput veterinaryInput)
        {
            if (ModelState.IsValid)
            {
                var veterinary=_mapper.Map<VeterinaryCreateInput,Veterinary>(veterinaryInput);
                await _veterinaryDomain.UpdateVeterinary(id,veterinary);
                
            }
            else
            {
                return BadRequest();
            }
            return Ok();
        }
        
        //PATCH: api/Veterinary/5
        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(int id, [FromBody] VeterinaryCreateInput veterinaryInput)
        {
            if (ModelState.IsValid)
            {
                var veterinary=_mapper.Map<VeterinaryCreateInput,Veterinary>(veterinaryInput);
                await _veterinaryDomain.UpdateVeterinary(id,veterinary);
                
            }
            else
            {
                return BadRequest();
            }
            return Ok();
        }

        // DELETE: api/Veterinary/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _veterinaryDomain.DeleteVeterinary(id);
            return Ok();
        }
        
        // Get: api/Login
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginVetInput veterinaryInput)
        {
            var veterinary = await _veterinaryDomain.GetVeterinaryLogin(veterinaryInput.Email, veterinaryInput.Password);
            if (veterinary == null) return NotFound();
            var result = _mapper.Map<Veterinary, VeterinaryResponse>(veterinary);

            return Ok(result);
        }
        
        // Post: api/Veterinary/SingUp
        [HttpPost]
        [Route("SignUp")]
        public async Task<IActionResult> SignUp(SignupVetInput veterinaryInput)
        {
            if (ModelState.IsValid)
            {
                var veterinary=_mapper.Map<SignupVetInput,Veterinary>(veterinaryInput);
                await _veterinaryDomain.Signup(veterinary);
                
            }
            else
            {
                return BadRequest();
            }
            return Ok();
        }
        
        // Get: api/Veterinary/GetServicesByVeterinaryId
        [HttpGet]
        [Route("Services/{id}")]
        public async Task<IActionResult> GetServicesByVeterinaryId(int id)
        {
            var services = await _veterinaryInfraestructure.GetServicesByVeterinaryId(id);
            var result = _mapper.Map<List<Service>, List<ServiceResponse>>(services);

            return Ok(result);
        }
        
        // Get: api/Veterinary/GetMeetingsByVeterinaryId
        [HttpGet]
        [Route("Meetings/{id}")]
        public async Task<IActionResult> GetMeetingsByVeterinaryId(int id)
        {
            var meetings = await _veterinaryInfraestructure.GetMeetingsByVeterinaryId(id);
            var result = _mapper.Map<List<Meeting>, List<MeetingResponse>>(meetings);

            return Ok(result);
        }
        
        // Get: api/Veterinary/GetProductsByVeterinaryId
        [HttpGet]
        [Route("Products/{id}")]
        public async Task<IActionResult> GetProductsByVeterinaryId(int id)
        {
            var products = await _veterinaryInfraestructure.GetProductsByVeterinaryId(id);
            var result = _mapper.Map<List<Product>, List<ProductResponse>>(products);

            return Ok(result);
        }
        
        // Get: api/Veterinary/GetReviewsByVeterinaryId
        [HttpGet]
        [Route("Reviews/{id}")]
        public async Task<IActionResult> GetReviewsByVeterinaryId(int id)
        {
            var reviews = await _veterinaryInfraestructure.GetReviewsByVeterinaryId(id);
            var result = _mapper.Map<List<Review>, List<ReviewResponse>>(reviews);

            return Ok(result);
        }

    }
}
