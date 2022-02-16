using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGTI.TechnologyLearningTools.Model
{
    public class QuestionOption
    {

        [Key]
        public int QuestionOptionId { get; set; }

        public string Title { get; set; }
        public bool IsChecked { get; set; }

        public int QuestionId { get; set; }
        public Question Question { get; set; }
    }
}
