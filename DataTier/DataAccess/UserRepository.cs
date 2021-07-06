using SIMS.DataTier.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIMS.DataTier.DataAccess
{
    public static class UserRepository
    {
        public static string GetIdFromMail(string mail)
        {
            //TO-DO
            SIMSContext ctx = new SIMSContext();
            try
            {
                if (ctx.Admins.SingleOrDefault(u => u.Email.Equals(mail)) != null)
                {
                    return ctx.Admins.SingleOrDefault(u => u.Email.Equals(mail)).AdminId;
                }
                else if (ctx.Teachers.SingleOrDefault(u => u.Email.Equals(mail)) != null)
                {
                    return ctx.Teachers.SingleOrDefault(u => u.Email.Equals(mail)).TeacherId;
                }
                else
                {
                    return ctx.Students.SingleOrDefault(u => u.Email.Equals(mail)).StudentId;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
            return null;
        }
    }
}
