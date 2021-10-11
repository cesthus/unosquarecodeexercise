using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UnosquareCodeExerciseAPI.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        
        [MaxLength(50, ErrorMessage = "{0} can have a max of {1} characters")]
        [Column(TypeName = "varchar(50)")]
        public string Name { get; set; }

        [MaxLength(100, ErrorMessage = "{0} can have a max of {1} characters")]
        [Column(TypeName = "varchar(100)")]
        public string? Description { get; set; }

        [Range(0, 100, ErrorMessage = "Enter a value between 1 and 100")]
        public int? AgeRestriccion { get; set; }

        
        [MaxLength(50, ErrorMessage = "{0} can have a max of {1} characters")]
        [Column(TypeName = "varchar(50)")]
        public string Company { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(0, 1000, ErrorMessage = "Enter a value between 1 and 1000")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

    }
}
