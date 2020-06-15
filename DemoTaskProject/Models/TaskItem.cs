using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DemoTaskProject.Models
{
    public class TaskItem
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name="Task ID")]
        public int TaskId { get; set; }

        [Required]
        [Display(Name ="Task Name")]
        public string TaskName { get; set; }

        [Required]
        [MaxLength(500)]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Finish Date")]
        public DateTime FinishDate { get; set; }


        [Display(Name = "State")]
        public string State { get; set; }

    }
}
