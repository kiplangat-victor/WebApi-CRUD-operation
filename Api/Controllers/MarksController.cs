using Api.Data;
using Api.Dtos.Marks;
using Api.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class MarksController:ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMarkRepository _markRepository;
        public MarksController(AppDbContext context, IMarkRepository markRepository)
        {
            _context = context;
            _markRepository = markRepository;
        }
        [HttpGet("{id:int}")]
        // [Route("GettingMark")]
        public async Task<IActionResult> GetById(int id)
        {
            var students = await _markRepository.GetByIdAsync(id);
            if(students==null)
            {
                return NotFound();
            }
            return Ok(students.MarksToDto());
        }

        [HttpPost("addmark")]
        public async Task<IActionResult> CreateMark(CreateDto marksDto,int id)
        {
            var data=marksDto.DtoToMarks(id);
            await _markRepository.CreateAsycn(data);
            return CreatedAtAction(nameof(GetById),new {id=data},data.MarksToDto());
            // return Ok(data);
        }
        [HttpGet("GetAllMarks")]
        public async Task<IActionResult> GetAllMarks()
        {
            var students=await _markRepository.GetAllAsycn();
            var data=students.Select(x=>x.MarksToDto()).ToList();
            return Ok(data);
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateMarks(int id, UpdateDto update)
        {
            var updatess=await _markRepository.UpdateAsync(id,update);
            if(updatess==null)
            {
                return NotFound("Hakuna kitu");

            }
            return Ok(updatess.MarksToDto());
        }
    }
}