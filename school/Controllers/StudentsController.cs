using AutoMapper;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.AspNetCore.Mvc;
using school.Core.Interfaces;
using school.Core.Models;
using school.Dtos.StudentDtos;
using school.Helpers;

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

        [HttpGet()]
        public async Task<IActionResult> getAll(int page = 1, int limit = 5)
        {
            var records = await _studentRepo.getList(page, limit);
            var totalCount = _studentRepo.getCount();
            var response = new
            {
                TotalCount =totalCount,
                TotalPages = (int)Math.Ceiling(totalCount / (double)limit),
                CurrentPage = page,
                PageSize = limit,
                Records = records
            };

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult> CreateSutdents([FromForm] IEnumerable<AddStudentDto> studentDtos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }          
            if (studentDtos == null  ) return BadRequest("no students was sent");
            //if (!ModelState.IsValid) return BadRequest("error");
            
            var students = new List<Student>();
            foreach (var studentDto in studentDtos)
            {
                var student = _mapper.Map<AddStudentDto, Student>(studentDto);
                try
                {
                    var image = UploadImageHelper.SaveImage(studentDto.ImageFile, "Storage");
                    if (image == null) return BadRequest();
                    student.StudentPhoto = image;

                }
                catch(ArgumentException ex)
                {
                    return BadRequest(ex.Message);
                }
               
                students.Add(student);
            }
           

            await _studentRepo.AddMany(students);
            return Ok(students);
           
        }
        [HttpGet("generateExcel")]
        public async Task<IActionResult> generateExcelAsync()
        {
            List<Student> students = (List<Student>)await _studentRepo.getList();
                var workbook = ExcelFileHelper.CreateExcelFile(students);
          
                using (MemoryStream stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    stream.Position = 0;

                    // Create a FileContentResult for downloading
                    FileContentResult fileContentResult = new FileContentResult(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
                    {
                        FileDownloadName = "students.xlsx"
                    };
                workbook.Dispose();
                return fileContentResult;
                }
                
            }
        }

    }

