using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission06_Pratte.Models
{
    public class Movie
    {
        [Key]
        [Required]
        public int MovieId { get; set; }


        [Required(ErrorMessage = "Please enter a title.")]
        public string Title { get; set; }


        [ForeignKey("CategoryId")]
        public int? CategoryId { get; set; }
        public Category? CategoryName { get; set; }


        [Required(ErrorMessage = "Please enter a year.")] // Validate empty field
        [Range(1888,3000,ErrorMessage = "Please enter a valid year.")] // Validate field range
        public int? Year { get; set; }

        public string? Director { get; set; }

        public string? Rating { get; set; }

        [Required]
        public bool Edited { get; set; }

        public string? LentTo { get; set; }

        [Required]
        public bool CopiedToPlex { get; set; }

        public string? Notes { get; set; }
    }
}
