using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGTI.TechnologyLearningTools.Model
{
    public class UserTest
    {
        [Key]
        public int UserTestId { get; set; }
        public string UserName { get; set; }
        public DateTime DateTime { get; set; }
        public int ExamId { get; set; }
        public Exam Exam { get; set; }
        public double Count { get; set; }
    }


    public class UserTestQuestion
    {
        [Key]
        public int UserTestQuestionId { get; set; }

        public int UserTestId { get; set; }
        public UserTest UserTest { get; set; }
        public string Otvet { get; set; }   
        public double Count { get ; set; }

    }
}
