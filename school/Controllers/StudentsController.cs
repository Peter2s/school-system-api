using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using school.Core.Interfaces;
using school.Core.Models;
using school.Dtos.StudentDtos;
using school.Helpers;
using school.Services;

namespace school.Controllers
{
    [Route("api/v1/students")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IBaseRepo<Student> _studentRepo;
        private readonly IMapper _mapper;


        public StudentsController(IBaseRepo<Student> studentRepo, IMapper mapper)
        {
            _studentRepo = studentRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            return Ok(await _studentRepo.getList());
        }

        [HttpPost]
        public async Task<ActionResult> CreateSutdents([FromForm] IEnumerable<List<AddStudentDto>> studentDtos)
        {
            var x = studentDtos;
            return Ok(studentDtos);
            /*
            if (studentDtos == null  ) return BadRequest("no students was sent");
            if (!ModelState.IsValid) return BadRequest("error");
            
            var students = _mapper.Map<List<Student>>(studentDtos);
            foreach (var studentDto in studentDtos)
            {
                var student = _mapper.Map<AddStudentDto, Student>(studentDto);

                var image = UploadImageHelper.SaveImage(studentDto.ImageFile,"Storage");
                if (image == null) return BadRequest();
                student.StudentPhoto = image;
                students.Add(student);
            }
           

            await _studentRepo.AddMany(students);
            return Ok(students);
            */

        }
            
    }
}
