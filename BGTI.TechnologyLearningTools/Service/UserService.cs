using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGTI.TechnologyLearningTools.Service
{
    internal class UserService
    {
        public  static bool IsAdmin (string login , string password)
        {
            try
            {
                Model.MySqlLiteContext context = new Model.MySqlLiteContext();
                return context.Users.Any(x => x.Name.ToLower() == login.ToLower()
                && x.Password.ToLower() == password.ToLower());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        internal static void AddUser(string login, string password)
        {
            try
            {
                Model.MySqlLiteContext context = new Model.MySqlLiteContext();
                context.Users.Add(new Model.User { Name = login, Password = password });
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
