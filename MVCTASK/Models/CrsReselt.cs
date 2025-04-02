using System.ComponentModel.DataAnnotations.Schema;

namespace MVCTASK.Models
{
    public class CrsReselt
    {
        //public int Id { get; set; }
        public int Gredee { get; set; }
        [ForeignKey("Trainee")]
        public int TraineeId { get; set; }
        public Trainee Trainee { get; set; } = default!;
        [ForeignKey("Course")]
        public int CourseId { get; set; }
        public Course Course { get; set; } = default!;
    }
}
