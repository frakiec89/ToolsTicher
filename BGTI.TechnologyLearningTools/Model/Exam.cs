using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGTI.TechnologyLearningTools.Model
{
    public class Exam
    {
        [Key]
        public int ExamId { get; set; } 
        public string Name { get; set; }
        public DateTime DateTime { get; set; }
    }
}
