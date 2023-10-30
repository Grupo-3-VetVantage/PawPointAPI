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
    public class UserController : ControllerBase
    {
        private IUserDomain _userDomain;
        private IUserInfraestructure _userInfraestructure;
        private IMapper _mapper;
        
        public UserController (IUserDomain userDomain, IUserInfraestructure userInfraestructure, IMapper mapper)
        {
            _userDomain = userDomain;
            _userInfraestructure = userInfraestructure;
            _mapper = mapper;
        }
        
        
        // GET: api/User
        [HttpGet]
        public async Task<IActionResult>Get()
        {
            var result=await _userInfraestructure.GetAll();
            var list=_mapper.Map<List<User>,List<UserResponse>>(result);
            return Ok(list);
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public async Task<IActionResult>GetById(int id)
        {
            var userFound = await _userInfraestructure.GetById(id);
            if (userFound == null) return NotFound();
            var result = _mapper.Map<User,UserResponse>(userFound);
            
            return Ok(result);
            
        }

        // POST: api/User
        [HttpPost]
        public async Task<IActionResult>Post([FromBody] UserCreateInput userInput)
        {
            if (ModelState.IsValid)
            {
                var user=_mapper.Map<UserCreateInput,User>(userInput);
                await _userDomain.CreateUserAsync(user);
                
            }
            else
            {
                StatusCode(400);
            }
            return Ok();
           
        }
        

        // PUT: api/User/5
        [HttpPut("{id}")]
        public async Task<IActionResult>Put(int id, [FromBody] UserUpdateInput userInput)
        {
            if (ModelState.IsValid)
            {
                var user=_mapper.Map<UserUpdateInput,User>(userInput);
                await _userDomain.UpdateUser(id,user);
                return NoContent();
            }
            else
            {
                return StatusCode(400);
            }
            
        }
       

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _userDomain.DeleteUser(id);
            return NoContent();
        }
        
        // POST: api/User/Login
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginInput input)
        {
            try
            {
                var user = _mapper.Map<LoginInput, User>(input);

                var result= await _userDomain.GetUserLogin(user.Email, user.Password);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al procesar");
            }
        }
        
        // POST: api/User/SingUp
        [HttpPost]
        [Route("SignUp")]
        public async Task<IActionResult> SignUp(SignupUserInput userSignup)
        {
            try
            {
                var user = _mapper.Map<SignupUserInput, User>(userSignup);

                var result= await _userDomain.Signup(user);

                return Ok(result.ToString());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al procesar");
            }
        }
        
        // GET: api/User/GetByUsername
        [HttpGet]
        [Route("Username/{username}")]
        public async Task<IActionResult> GetByUsername(string username)
        {
            try
            {
                
                var userFound = await _userInfraestructure.GetByUsername(username);
                var result = _mapper.Map<User,UserResponse>(userFound);
            
                return Ok(result);

                
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al procesar");
            }
            
        }
        
        //GET: api/User/GetPetsByUserId
        [HttpGet ]
        [Route("GetPets/{id}")]
        public async Task<IActionResult> GetPetsByUserId(int id)
        {
            try
            {
                
                var petsFound = await _userInfraestructure.GetPetsByUserId(id);
                if (petsFound == null) return NotFound();
                var result = _mapper.Map<List<Pet>,List<PetResponse>>(petsFound);
            
                return Ok(result);

                
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al procesar");
            }
            
        }
        
        //GET: api/User/GetMeetingsByUserId
        [HttpGet]
        [Route("GetMeetings/{id}")]
        public async Task<IActionResult> GetMeetingsByUserId(int id)
        {
            try
            {
                
                var meetingsFound = await _userInfraestructure.GetMeetingsByUserId(id);
                if (meetingsFound == null) return NotFound();
                var result = _mapper.Map<List<Meeting>,List<MeetingResponse>>(meetingsFound);
            
                return Ok(result);

                
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al procesar");
            }
            
        }
        
        //GET: api/User/GetReviewsByUserId
        [HttpGet]
        [Route("GetReviews/{id}")]
        public async Task<IActionResult> GetReviewsByUserId(int id)
        {
            try
            {
                
                var reviewsFound = await _userInfraestructure.GetReviewsByUserId(id);
                if (reviewsFound == null) return NotFound();
                var result = _mapper.Map<List<Review>,List<ReviewResponse>>(reviewsFound);
            
                return Ok(result);

                
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al procesar");
            }
            
        }


    }
}
