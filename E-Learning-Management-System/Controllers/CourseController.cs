using AutoMapper;
using E_Learning_Management_System.DTO;
using E_Learning_Management_System.Models;
using E_Learning_Management_System.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace E_Learning_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseRepository courseRepository;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IMapper mapper;

        //seravia controller

        public CourseController(ICourseRepository courseRepository, UserManager<ApplicationUser> userManager, IMapper mapper)

        {
            this.courseRepository = courseRepository;
            this.userManager = userManager;
            this.mapper = mapper;
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddCoure(CourseDTO courseDTO)
        {
            if (ModelState.IsValid)
            {
                var currenUser = await userManager.GetUserAsync(User);
                int insId = (int)currenUser.InstructorId;
                Course course = mapper.Map<Course>(courseDTO);
                course.InstructorId = insId;
                courseRepository.insert(course);
                courseRepository.save();
                return Ok(new
                {
                    Message = "Added successfully"
                });
            }
            return BadRequest(new
            {
                Error = "Unable to add course"
            });
        }
        [HttpGet]
        [Authorize]
        public IActionResult GetAll()
        {
            List<Course> courses = courseRepository.GetAllIncludeInstructor();
            if (courses != null)
            {
                List<CourseIncludeInstructorDTO> dTOs = new List<CourseIncludeInstructorDTO>();
                foreach (Course course in courses)
                {
                    CourseIncludeInstructorDTO dTO = new CourseIncludeInstructorDTO();
                    dTO.id= course.Id;
                    dTO.Name = course.Name;
                    dTO.ImgPath = course.ImgPath;
                    dTO.DurationInHours = course.DurationInHours;
                    dTO.InstructorName = course.Instructor.Name;
                   
                    dTOs.Add(dTO);
                }
                return Ok(dTOs);
            }
            return NotFound(new
            {
                Error = "There is no courses"
            });
        }
        [HttpGet("ByCourseId/{courseId:int}")]
       // [Authorize]
        public IActionResult GetCourseByCourseId(int courseId)
        {
            var course = courseRepository.Get(c => c.Id == courseId);
            if (course == null)
            {
                return NotFound(new
                {
                    Error = "Course Not Found"
                });
            }
            CourseDTO courseDTO = mapper.Map<CourseDTO>(course);

            return Ok(courseDTO);

          
                return Ok(courseDTO);

        }
        [HttpGet("byInstructorId/{instructorId:int}")]
        [Authorize]
        public IActionResult GetCoursesForSpecificInstructor(int instructorId)
        {
            List<Course> courses = courseRepository.GetAll()
                .Where(c => c.InstructorId == instructorId).ToList();
            if (courses != null)
            {
                List<CourseDTO> dTOs = new List<CourseDTO>();
                foreach (Course course in courses)
                {
                    CourseDTO dTO = new CourseDTO();
                    dTO.Name = course.Name;
                    dTOs.Add(dTO);
                }
                return Ok(dTOs);
            }
            return NotFound(new
            {
                Error = "No courses found for this instructor."
            });

        }
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateCourse(int id, CourseDTO courseDTO)
        {
            Course existingCourse = courseRepository.Get(c => c.Id == id);
            var currenUser = await userManager.GetUserAsync(User);
            int insId = (int)currenUser.InstructorId;
            if (existingCourse == null)
            {
                return NotFound(new
                {
                    Error = "courses Not found"
                });
            }
            existingCourse.Name = courseDTO.Name;
            existingCourse.InstructorId = insId;
            courseRepository.update(existingCourse);
            courseRepository.save();

            return Ok(new
            {
                Message = "Course updated successfully"
            });
        }
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult DeleteCourse(int id)
        {
            Course existingCourse = courseRepository.Get(c => c.Id == id);
            if (existingCourse == null)
            {
                return NotFound(new
                {
                    Error = "Course not found"
                });

            }
            courseRepository.delete(existingCourse);
            courseRepository.save();

            return Ok(new
            {
                Message = "Course Deleted successfully"
            });
        }

    }
}
