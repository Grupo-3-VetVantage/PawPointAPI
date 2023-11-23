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
    public class MeetingController : ControllerBase
    {
        private IMeetingDomain _meetingDomain;
        private IMeetingInfraestructure _meetingInfraestructure;
        private IMapper _mapper;
        
        public MeetingController (IMeetingDomain meetingDomain, IMeetingInfraestructure meetingInfraestructure, IMapper mapper)
        {
            _meetingDomain = meetingDomain;
            _meetingInfraestructure = meetingInfraestructure;
            _mapper = mapper;
        }
        
        // GET: api/Meeting
        [HttpGet]
        public async Task< IActionResult> Get()
        {
            var result=await _meetingInfraestructure.GetMeetingsAsync();
            var list=_mapper.Map<List<Meeting>,List<MeetingResponse>>(result);
            return Ok(list);
        }

        // GET: api/Meeting/5
        [HttpGet("{id}", Name = "GetMeeting")]
        public async Task<IActionResult> GetById(int id)
        {
            var meetingFound = await _meetingInfraestructure.GetMeetingAsyncById(id);
            if (meetingFound == null) return NotFound();
            var result = _mapper.Map<Meeting,MeetingResponse>(meetingFound);
            
            return Ok(result);
            
        }

        // POST: api/Meeting
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] MeetingCreateInput meetingInput)
        {
            if (ModelState.IsValid)
            {
                var meeting=_mapper.Map<MeetingCreateInput,Meeting>(meetingInput);
                await _meetingDomain.CreateMeetingAsync(meeting);
                
                return Ok(meeting);
            }
            return BadRequest(ModelState);
        }

        // PUT: api/Meeting/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] MeetingCreateInput meetingInput)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var meeting=_mapper.Map<MeetingCreateInput,Meeting>(meetingInput);
            await _meetingDomain.UpdateMeetingAsync(id,meeting);
                
            return Ok(meeting);
        }

        // DELETE: api/Meeting/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _meetingDomain.DeleteMeetingAsync(id);
            return Ok();
        }
        
        // Get: api/Meeting/GetAllMeetingByUserId/5
        [HttpGet("MeetingUser/{id}")]
        public async Task<IActionResult> GetAllMeetingByUserId(int id)
        {
            var meetingFound = await _meetingDomain.GetAllMeetingByUserIdAsync(id);
            var result = _mapper.Map<IEnumerable<Meeting>,List<MeetingResponse>>(meetingFound);
            
            return Ok(result);
            
        }
        
        // Get: api/Meeting/GetAllMeetingByVetId/5
        [HttpGet("MeetingVet/{id}")]
        public async Task<IActionResult> GetAllMeetingByVetId(int id)
        {
            var meetingFound = await _meetingDomain.GetAllMeetingByVeterinaryIdAsync(id);
            var result = _mapper.Map<IEnumerable<Meeting>, List<MeetingResponse>>(meetingFound);

            return Ok(result);
        }
        // Get: api/Meeting/GetAllMeetingByPetId/5
        [HttpGet("MeetingPet/{id}")]
        public async Task<IActionResult> GetAllMeetingByPetId(int id)
        {
            var meetingFound = await _meetingDomain.GetAllMeetingByPetIdAsync(id);
            var result = _mapper.Map<IEnumerable<Meeting>, List<MeetingResponse>>(meetingFound);

            return Ok(result);
        }
    }
}
