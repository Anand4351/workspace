using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManPowerProject.Models
{
    [Table("Tasks")]
    public class Tasks
    {
        [Key]
        public int task_id { get; set; }
        public string task_name { get; set; } = "";
        public DateTime task_sdate { get; set;}
        public DateTime task_edate { get; set; }
        public string assigned_to { get; set; } = "";
        public decimal total_cost { get; set; } = 0;

    }
}
