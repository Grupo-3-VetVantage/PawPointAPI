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
    public class ReviewController : ControllerBase
    {
        private IReviewDomain _reviewDomain;
        private IReviewInfraestructure _reviewInfraestructure;
        private IMapper _mapper;
        
        public ReviewController (IReviewDomain reviewDomain, IReviewInfraestructure reviewInfraestructure, IMapper mapper)
        {
            _reviewDomain = reviewDomain;
            _reviewInfraestructure = reviewInfraestructure;
            _mapper = mapper;
        }
        
        // GET: api/Review
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result=await _reviewInfraestructure.GetReviews();
            var list=_mapper.Map<List<Review>,List<ReviewResponse>>(result);
            return Ok(list);
        }

        // GET: api/Review/5
        [HttpGet("{id}", Name = "GetReview")]
        public async Task<IActionResult> GetById(int id)
        {
            var reviewFound = await _reviewInfraestructure.GetReviewById(id);
            if (reviewFound == null) return NotFound();
            var result = _mapper.Map<Review,ReviewResponse>(reviewFound);
            
            return Ok(result);
            
        }

        // POST: api/Review
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ReviewCreateInput reviewInput)
        {
            if (ModelState.IsValid)
            {
                var review=_mapper.Map<ReviewCreateInput,Review>(reviewInput);
                await _reviewDomain.CreateReview(review);
                
            }
            else
            {
                return BadRequest();
            }
            return Ok();
        }
        

        // PUT: api/Review/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ReviewCreateInput reviewInput)
        {
            if (ModelState.IsValid)
            {
                var review=_mapper.Map<ReviewCreateInput,Review>(reviewInput);
                await _reviewDomain.UpdateReview(id,review);
            }
            else
            {
                return StatusCode(400);
            }
            return Ok();

            
        }
        // DELETE: api/Review/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _reviewDomain.DeleteReview(id);
            return Ok();
        }
    }
}
