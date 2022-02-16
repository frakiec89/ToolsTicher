using BGTI.TechnologyLearningTools.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGTI.TechnologyLearningTools.Service
{
    internal class UserTestService
    {
        public static UserTest Adduser ( String name , int exam )
        {
            UserTest user = new UserTest() { UserName = name ,  DateTime = DateTime.Now ,  ExamId = exam };
            using Model.MySqlLiteContext    mySqlLiteContext = new Model.MySqlLiteContext();  
            mySqlLiteContext.UserTests.Add( user );
            mySqlLiteContext.SaveChanges();
            return user;
        }

        internal static void AddOtvet(UserTest userTest, string otvet, double count)
        { 
            Model.UserTestQuestion question = new Model.UserTestQuestion()
            {
                     Count = count, Otvet = otvet, UserTestId = userTest.UserTestId
             };

            using Model.MySqlLiteContext mySqlLiteContext = new Model.MySqlLiteContext();
            mySqlLiteContext.UserTestQuestions.Add(question);
            mySqlLiteContext.SaveChanges();

        }
    }
}
