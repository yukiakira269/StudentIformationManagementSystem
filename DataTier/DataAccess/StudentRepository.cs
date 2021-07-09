using Microsoft.EntityFrameworkCore;
using SIMS.DataTier.BusinessObject;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SIMS.DataTier.Infrastructure
{
    public class StudentRepository : IRepository<Student>
    {

        public bool Delete(Student entity, bool saveChanges = true)
        {
            using var ctx = new SIMSContext();
            var removed = ctx.Parents.Find(entity.StudentId);
            ctx.Students.Remove(entity);
            ctx.Parents.Remove(removed);
            ctx.SaveChanges();
            return saveChanges;
        }

        public Student Find(params object[] values)
        {

            using var ctx = new SIMSContext();
            return ctx.Students.Find(values[0].ToString());
        }

        public IEnumerable<Student> FindAll()
        {
            using var ctx = new SIMSContext();
            return ctx.Students.ToList();
        }

        public IEnumerable<Student> getAll()
        {
            throw new NotImplementedException();
        }

        public bool Insert(Student entity, bool saveChanges = true)
        {
            throw new NotImplementedException();
        }

        public string GenerateId()
        {
            using var ctx = new SIMSContext();
            var lastId = ctx.Students.Where(s => s.StudentId.Contains("ST"))
                .OrderByDescending(s => s.StudentId).First().StudentId;
            Debug.WriteLine("LAST" + lastId);

            var lastDigits = Int32.Parse(lastId.Substring(2, lastId.Length - 2)) + 1;
            Debug.WriteLine("ST" + lastDigits.ToString());
            return "ST" + lastDigits.ToString();
        }

        public bool Update(Student Entity, bool saveChanges = true)
        {
            try
            {
                using var ctx = new SIMSContext();
                ctx.Students.Update(Entity);
                ctx.SaveChanges();
                Console.WriteLine("Updated!!");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return saveChanges;
        }


        public bool Authorise(Student Entity, bool saveChanges = true)
        {
            try
            {
                var id = GenerateId();
                using var ctx = new SIMSContext();
                var stu = ctx.Students.SingleOrDefault(s => s.Email.Equals(Entity.Email));
                Entity.StudentId = id;
                Debug.WriteLine("NewId" + Entity.StudentId);
                if (stu != null)
                {
                    ctx.Parents.Add(new Parent
                    {
                        StudentId = Entity.StudentId,
                        Balance = null,
                        Email = "",
                        Phone = Entity.ParentsPhone,
                    });
                    ctx.Students.Add(Entity);
                    var removed = ctx.Parents.Find(stu.StudentId);
                    ctx.Students.Remove(stu);
                    ctx.Parents.Remove(removed);
                    ctx.SaveChanges();
                }
                Console.WriteLine("Updated!!");
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return saveChanges;
        }
    }
}
