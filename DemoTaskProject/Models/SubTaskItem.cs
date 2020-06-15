using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoTaskProject.Models
{
    public class SubTaskItem
    {

        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Task ID")]
        public int SubTaskId { get; set; }

        [Required]
        [Display(Name = "Task Name")]
        public string SubTaskName { get; set; }

        [Required]
        [MaxLength(500)]
        [Display(Name = "Description")]
        public string SubDescription { get; set; }

        [Required]
        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        public DateTime SubStartDate { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Finish Date")]
        public DateTime SubFinishDate { get; set; }


        [Display(Name = "State")]
        public string SubState { get; set; }

        [Required]
        [Display(Name = ("Parent Task ID"))]

        public int TaskId { get; set; }
        public virtual TaskItem TaskItem{ get; set; }
    }
}
