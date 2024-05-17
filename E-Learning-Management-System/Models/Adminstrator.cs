using E_Learning_Management_System.Repository;
using System.ComponentModel.DataAnnotations.Schema;
using E_Learning_Management_System.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.EntityFrameworkCore;

namespace E_Learning_Management_System.Models
{
    public class Adminstrator : IDeletable
    {
        public int id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; } = false;

        [ForeignKey("Account")]
        public string? AccountId { get; set; }
        public ApplicationUser? Account { get; set; }
        [ForeignKey("Content")]
        public int? ContentId { get; set; }
        public Content? Content { get; set; }
    }


}
