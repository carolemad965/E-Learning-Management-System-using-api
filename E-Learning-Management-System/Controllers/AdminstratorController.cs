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
    public class AdminstratorController : ControllerBase
    {

        private readonly IRepository<Adminstrator> AdminRepository;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IMapper mapper;
      
        public AdminstratorController(IRepository<Adminstrator> adminRepository, UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            AdminRepository = adminRepository;
            this.userManager = userManager;
            this.mapper = mapper;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddAdmin(AdminstratorDTO adminstratorDTO)
        {
            if (ModelState.IsValid)
            {
                var currentUser = await userManager.GetUserAsync(User);
                Adminstrator Adminstrator = mapper.Map<Adminstrator>(adminstratorDTO);
                Adminstrator.AccountId = currentUser.Id;
                AdminRepository.insert(Adminstrator);
                AdminRepository.save();
                return Ok("Adminstrator added successfully");


            }
            return BadRequest("Invalid Adminstrator data");

        }
        [HttpGet]
        [Authorize]
        public IActionResult GetAll()
        {
            List<Adminstrator> Admins = AdminRepository.GetAll();
            if (Admins != null)
            {
                List<AdminstratorDTO> DTOs = new List<AdminstratorDTO>();
                foreach (Adminstrator adminstrator in Admins)
                {
                    AdminstratorDTO DTO = new AdminstratorDTO();
                    DTO.Name = adminstrator.Name;
                    DTOs.Add(DTO);
                }
                return Ok(DTOs);
            }
            return NotFound("There is no Admins");
        }
        [HttpGet("ByAdminId/{AdminId:int}")]
        [Authorize]
        public IActionResult GetAdminByAdminId(int AdminId)
        {
            var Admin = AdminRepository.Get(c => c.id == AdminId);
            if (Admin == null)
            {
                return NotFound("Admin not found");
            }
            AdminstratorDTO adminstratorDTO = mapper.Map<AdminstratorDTO>(Admin);
            return Ok(adminstratorDTO);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateAdminstrator(int id, AdminstratorDTO adminstratorDTO)
        {
            Adminstrator Adminstrator = AdminRepository.Get(a => a.id == id);

            if (Adminstrator == null)
            {
                return NotFound("Adminstrator not found");
            }
            var currentUser = await userManager.GetUserAsync(User);
            Adminstrator.Name = adminstratorDTO.Name;
            Adminstrator.AccountId = currentUser.Id;
            AdminRepository.update(Adminstrator);
            AdminRepository.save();
            return Ok("Adminstrator updated successfully");

        }
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult DeleteAdmin(int id)
        {
            Adminstrator existingAdmin = AdminRepository.Get(a => a.id == id);
            if (existingAdmin == null)
            {
                return NotFound("Admin not found");
            }
            AdminRepository.delete(existingAdmin);
            AdminRepository.save();

            return Ok("Admin deleted successfully");
        }
    }
}
