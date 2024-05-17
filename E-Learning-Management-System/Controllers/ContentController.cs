using AutoMapper;
using E_Learning_Management_System.DTO;
using E_Learning_Management_System.Models;
using E_Learning_Management_System.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace E_Learning_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContentController : ControllerBase
    {
        private readonly IRepository<Content> contentRepository;
        private readonly ICourseRepository courseRepository;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IMapper mapper;

        
        public ContentController(ICourseRepository courseRepository,IRepository<Content> contentRepository, UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            this.contentRepository = contentRepository;
            this.userManager = userManager;
            this.mapper = mapper;
            this.courseRepository = courseRepository;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddContent(ContentDTO contentDTO)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Content content = new Content
                    {
                        Type = contentDTO.Type,
                    };
                    contentRepository.insert(content);
                    contentRepository.save();

                    return Ok("Content added successfully");
                }
                catch (Exception ex)
                {
                    return StatusCode(500, "An error occurred while adding content");
                }
            }
            return BadRequest("Invalid content data");
        }

        [HttpGet]
      //  [Authorize]
        public IActionResult GetAll()
        {
            List<Content> contents = contentRepository.GetAll();
            if (contents != null)
            {
                List<ContentDTO> dtos = contents.Select(c => new ContentDTO
                {
                    Id = c.Id,
                    Type = c.Type,
                    content=c.content,
                    videoPathURL= c.videoPathURL,
                }).ToList();
                return Ok(dtos);
            }
            return NotFound("No content found");
        }

        [HttpGet("{id}")]
        [Authorize]
        public IActionResult GetContentById(int id)
        {
            var content = contentRepository.Get(c => c.Id == id);
            if (content == null)
            {
                return NotFound("Content not found");
            }
            ContentDTO dto = new ContentDTO
            {
                Id = content.Id,
                Type = content.Type,
                content = content.content,
                videoPathURL = content.videoPathURL,
            };
            return Ok(dto);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateContent(int id, ContentDTO contentDTO)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Content existingContent = contentRepository.Get(c => c.Id == id);

                    if (existingContent == null)
                    {
                        return NotFound("Content not found");
                    }

                    existingContent.Type = contentDTO.Type;
                    contentRepository.update(existingContent);
                    contentRepository.save();

                    return Ok("Content updated successfully");
                }
                catch (Exception ex)
                {
                    return StatusCode(500, "An error occurred while updating content");
                }
            }
            return BadRequest("Invalid content data");
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteContent(int id)
        {
            try
            {
                Content existingContent = contentRepository.Get(c => c.Id == id);
                if (existingContent == null)
                {
                    return NotFound("Content not found");
                }
                contentRepository.delete(existingContent);
                contentRepository.save();

                return Ok("Content deleted successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while deleting content");
            }
        }

        [HttpGet("course/{courseId}")]
        //[Authorize]
        public IActionResult GetContentsByCourseId(int courseId)
        {
            try
            {

                var course = courseRepository.Get(c=>c.Id==courseId);

                if (course == null)
                {
                    return NotFound("Course not found");
                }
                // List<Content> Contents = contentRepository.GetAll().ToList();
                // Retrieve contents associated with the course
                List<ContentDTO> contentDTOs = contentRepository.GetAll()
             .Where(c => c.CourseId == courseId)
             .Select(c => new ContentDTO
             {
                 Id = c.Id,
                 Type = c.Type,
                 content = c.content, // Ensure property names match
                 videoPathURL = c.videoPathURL
             }).ToList();

                return Ok(contentDTOs);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while retrieving contents by course id");
            }
        }

    }
}
