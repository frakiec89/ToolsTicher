using BGTI.TechnologyLearningTools.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace BGTI.TechnologyLearningTools.Service
{
    internal class ExemService
    {
        public static List<Model.Exam> Exams()
        {
            try
            {
                using Model.MySqlLiteContext context = new Model.MySqlLiteContext();
                return context.Exams.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        internal static void Add(string name)
        {
            try
            {
                using Model.MySqlLiteContext context = new Model.MySqlLiteContext();
                context.Exams.Add(new Model.Exam { DateTime = DateTime.Now, Name = name });
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        internal static IEnumerable GetRezExament()
        {
            try
            {
                using Model.MySqlLiteContext context = new Model.MySqlLiteContext();
                return context.UserTestQuestions.Include(x=>x.UserTest).Include(x=>x.UserTest.Exam).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        internal static List<Question> GetQuestionId(int idEx)
        {
            using Model.MySqlLiteContext mySqlLiteContext = new Model.MySqlLiteContext();
            return mySqlLiteContext.Questions.Where(x => x.ExamId == idEx).ToList();
        }

        internal static List<QuestionOption> GetQuestionToStudent(int idEx)
        {
           using Model.MySqlLiteContext mySqlLiteContext = new Model.MySqlLiteContext();
           return   mySqlLiteContext.QuestionOption.Where(x => x.Question.ExamId == idEx).Include(x=>x.Question).ToList();
        }

        internal static List<string> GetQuestion(int  idExem)
        {
          using Model.MySqlLiteContext mySqlLiteContext = new Model.MySqlLiteContext();
           var  list =  mySqlLiteContext.QuestionOption.Where(x=>x.Question.ExamId==idExem).
                Include(x=>x.Question).ToList();
            List<string> vs = new List<string>();
            int  x = 1;
            foreach (var q in list.GroupBy(x=>x.QuestionId))
            {
                
                string v = "Вопрос - "+ x + ". ";
                foreach (var item in q)
                {
                    v += item.Question.Title  + " Цена -  " + item.Question.QuestionWeight +"\n";
                    break;
                }

                foreach (var it in q)
                {
                    v += " Вариант ответа -  " + it.Title + " \t верный ответ -  " + it.IsChecked +"\n";
                }
                vs.Add(v);
                x++;
            }
            return vs;
        }

        internal static void AddQuestion(Question question , List< Model.QuestionOption> pos)
        {
            Model.MySqlLiteContext mySqlLiteContext = new Model.MySqlLiteContext();
            Model.Question question1 = new Model.Question(); 
            question1.ExamId = question.ExamId;
            question1.Title = question.Title;
            question1.QuestionWeight = question.QuestionWeight;
            mySqlLiteContext.Questions.Add(question1);
            mySqlLiteContext.SaveChanges();

            foreach (var item in pos)
            {
                var np = new Model.QuestionOption()
                {
                    IsChecked = item.IsChecked,
                    QuestionId = question1.QuestionId,
                    Title = item.Title
                };
                mySqlLiteContext.QuestionOption.Add(np);
                mySqlLiteContext.SaveChanges();
            }
        }

        internal static string GetRezCoutn(UserTest userTest, int idEx)
        {
            Model.MySqlLiteContext mySqlLiteContext = new MySqlLiteContext();
            var s = mySqlLiteContext.UserTestQuestions.
                 Where(x => x.UserTestId == userTest.UserTestId).Sum(x=>x.Count);
            return s.ToString();
               

        }
    }
}
