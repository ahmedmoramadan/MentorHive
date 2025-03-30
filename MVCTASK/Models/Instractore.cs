﻿using System.ComponentModel.DataAnnotations.Schema;

namespace MVCTASK.Models
{
    public class Instractore : Person
    {
        public  decimal Salary { get; set; }
        [ForeignKey("Course")]
        public int CrsId { get; set; }
        public Course Course { get; set; } = default!;
    }
}
