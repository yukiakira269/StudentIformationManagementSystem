using SIMS.DataTier.BusinessObject;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SIMS.DataTier.DataAccess
{
    public static class UserRepository
    {
        public static string GetIdFromMail(string mail)
        {
            //TO-DO
            using var ctx = new SIMSContext();
            try
            {
                if (ctx.Admins.SingleOrDefault(u => u.Email.Equals(mail)) != null)
                {
                    Debug.WriteLine("Admin");
                    return ctx.Admins.SingleOrDefault(u => u.Email.Equals(mail)).AdminId;
                }
                else if (ctx.Teachers.SingleOrDefault(u => u.Email.Equals(mail)) != null)
                {
                    Debug.WriteLine("Teacher");
                    return ctx.Teachers.SingleOrDefault(u => u.Email.Equals(mail)).TeacherId;
                }
                else if (ctx.Students.SingleOrDefault(u => u.Email.Equals(mail)) != null)
                {
                    Debug.WriteLine("Student");
                    return ctx.Students.SingleOrDefault(u => u.Email.Equals(mail)).StudentId;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
            return null;
        }

        public static dynamic GetUserFromMail(string mail)
        {
            //TO-DO
            using var ctx = new SIMSContext();
            try
            {
                if (ctx.Admins.SingleOrDefault(u => u.Email.Equals(mail)) != null)
                {
                    return ctx.Admins.SingleOrDefault(u => u.Email.Equals(mail));
                }
                else if (ctx.Teachers.SingleOrDefault(u => u.Email.Equals(mail)) != null)
                {
                    return ctx.Teachers.SingleOrDefault(u => u.Email.Equals(mail));
                }
                else if (ctx.Students.SingleOrDefault(u => u.Email.Equals(mail)) != null)
                {
                    return ctx.Students.SingleOrDefault(u => u.Email.Equals(mail));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
            return null;
        }

        public static Student GetStudentFromMail(string mail)
        {
            using var ctx = new SIMSContext();
            try
            {
                if (ctx.Students.SingleOrDefault(u => u.Email.Equals(mail)) != null)
                    return ctx.Students.SingleOrDefault(u => u.Email.Equals(mail));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
            return null;
        }
    }
}
