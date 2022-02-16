using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGTI.TechnologyLearningTools.Model
{
    public class Question
    {

        [Key]
        public int QuestionId {  get ; set; }
        public string Title { get; set; }
        public int?  QuestionWeight { get; set; }
        public int? ExamId { get; set; }
        public Exam? Exam { get; set; }  
    }
}
