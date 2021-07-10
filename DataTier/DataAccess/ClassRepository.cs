using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SIMS.DataTier.BusinessObject;
using SIMS.DataTier.DataAccess;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIMS.DataTier.Infrastructure
{
    public class ClassRepository : IRepository<Class>
    {
        private static SIMSContext ctx = new SIMSContext();

        public IEnumerable<ClassDetail> GetClassDetails(string classId)
        {
            return ctx.ClassDetails.Where(clD => clD.ClassId.Equals(classId)).ToList();
        }

        public IEnumerable<ClassDetail> GetClassDetailsByStudentId(string studentId)
        {
            return ctx.ClassDetails.ToList().Where(clD => clD.StudentId == (studentId));
        }

        public IEnumerable<Class> GetAvailableClasses(string courseId)
        {
            List<Class> classes = ctx.Classes.Where(c => c.CourseId.Equals(courseId)).ToList();
            foreach (Class cls in classes)
            {
                List<ClassDetail> clds = (List<ClassDetail>)GetClassDetails(cls.ClassId);
                if (clds.Count >= cls.NumOfStudent)
                {
                    classes.Remove(cls);
                }
            }
            return classes;
        }

        public IEnumerable<Class> GetClassesByStudentId(string studentId)
        {
            List<ClassDetail> classDetails = ctx.ClassDetails
                .Where(c => c.StudentId.Equals(studentId)).ToList();
            var classes = new List<Class>();

            foreach (ClassDetail cld in classDetails) {
                var tempCls = ctx.Classes.SingleOrDefault(c => c.ClassId == cld.ClassId);
                if (tempCls != null)
                {
                    classes.Add(tempCls);
                    Console.WriteLine("Class-courseId: " + tempCls.CourseId);
                }
            }

            return classes;
        }

        public Class GetClass(string classId)
        {
            return ctx.Classes.SingleOrDefault(c => c.ClassId.Equals(classId));
        }

        public IEnumerable<Student> GetStudentList(string classId)
        {
            var classDetails = GetClassDetails(classId);
            var students = new List<Student>();
            foreach (ClassDetail cld in classDetails)
            {
                var tempStu = ctx.Students.SingleOrDefault(s => s.StudentId == cld.StudentId);
                if (tempStu != null)
                {
                    students.Add(tempStu);
                }
            }
            foreach (Student s in students)
            {
                Console.WriteLine(students.Count);
            }

            return students;
        }

        public ClassDetail AddStudentToClass(string studentId, string classId)
        {
            var cld = new ClassDetail() { StudentId = studentId, ClassId = classId };
            try
            {
                ctx.ClassDetails.Add(cld);
                ctx.SaveChanges();
                return cld;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public ClassDetail CancelCourseForStudent(string classId, string studentId)
        {
            var classDetails = ctx.ClassDetails.ToList();

            foreach (ClassDetail cld in classDetails)
            {
                if (cld.ClassId.Equals(classId) && cld.StudentId.Equals(studentId))
                {
                    try
                    {
                        ctx.ClassDetails.Remove(cld);
                        ctx.SaveChanges();
                        Console.WriteLine("Class '"+ cld.ClassId +"' for '" + studentId + "  Canceled!");
                        return cld;
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
            }
            return null;
        }

        public bool Delete(Class entity, bool saveChanges = true)
        {
            using var ctx = new SIMSContext();
            ctx.Classes.Remove(entity);
            ctx.SaveChanges();
            return saveChanges;
        }

        public Class Find(params object[] values)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Class> FindAll()
        {
            return ctx.Classes;
        }

        public IEnumerable<Class> FindAll(string email)
        {
            var id = UserRepository.GetIdFromMail(email);
            return ctx.Classes.ToList().Where(c =>
            {
                return c.TeacherId.Equals(id);
            });
        }



        public IEnumerable<Class> getAll()
        {
            throw new NotImplementedException();
        }

        public bool Insert(Class entity, bool saveChanges = true)
        {
            throw new NotImplementedException();
        }

        public bool Update(Class Entity, bool saveChanges = true)
        {
            throw new NotImplementedException();
        }

        public bool UpdateList(IEnumerable<Class> Entities, bool saveChanges = true)
        {
            using var ctx = new SIMSContext();

            foreach (Class cl in Entities)
            {
                Console.WriteLine(cl.NumOfStudent);
                var toBeAdded = ctx.Classes.AsNoTracking<Class>().SingleOrDefault(c => c.ClassId.Equals(cl.ClassId));
                //The class is not on the list
                if (toBeAdded == null)
                {
                    ctx.Classes.Add(cl);
                }
                //The class is on the list
                else if (toBeAdded != null)
                {
                    var toBeUpdated = cl;
                    ctx.Classes.Update(toBeUpdated);
                }
            }
            ctx.SaveChanges();

            return saveChanges;
        }
    }
}
