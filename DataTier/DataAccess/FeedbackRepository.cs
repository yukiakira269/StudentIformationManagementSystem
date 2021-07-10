using Microsoft.EntityFrameworkCore;
using SIMS.DataTier.BusinessObject;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIMS.DataTier.Infrastructure
{
    public class FeedbackRepository : IRepository<Feedback>
    {
        public bool Delete(Feedback entity, bool saveChanges = true)
        {
            throw new NotImplementedException();
        }

        public Feedback Find(params object[] values)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Feedback> FindAll(string teacherId)
        {
            using var ctx = new SIMSContext();

            //Get teaching classes
            var teachingClasses = ctx.Classes.Where(c => c.TeacherId.Equals(teacherId)).ToList();

            //Get students from teaching classes
            var studentsFromTeachingClasses = new List<Student>();
            foreach(var c in teachingClasses)
            {
                var stuDet = ctx.ClassDetails.Where(det => det.ClassId.Equals(c.ClassId)).ToList();
                //For each detail, get the student
                foreach(var d in stuDet)
                {
                    studentsFromTeachingClasses.Add(ctx.Students.SingleOrDefault(s => s.StudentId.Equals(d.StudentId)));
                }
            }

            //Get feedbacks of all teaching students
            var feedbackList = new List<Feedback>();
            foreach(var stu in studentsFromTeachingClasses)
            {
                var feedback = ctx.Feedbacks.SingleOrDefault(f => f.StudentId.Equals(stu.StudentId));
                //There is already a feedback
                if(feedback != null)
                {
                    feedbackList.Add(feedback);
                }
                //There is no feedback yet, create an empty feedback
                else
                {
                    var newFeedback = new Feedback
                    {
                        Feedback1 = "",
                        StudentId = stu.StudentId,
                        TeacherId = teacherId
                    };
                    feedbackList.Add(newFeedback);
                    //Also sync with the database
                    ctx.Feedbacks.Add(newFeedback);
                    ctx.SaveChanges();
                }
            }
            return feedbackList;
            //return ctx.Feedbacks.Where(f => f.TeacherId.Equals(teacherId)).ToList();
        }


        public IEnumerable<Feedback> FindAll()
        {
            throw new NotImplementedException();
        }

        public bool Insert(Feedback entity, bool saveChanges = true)
        {
            throw new NotImplementedException();
        }

        public bool Update(Feedback Entity, bool saveChanges = true)
        {
            try
            {
                using var ctx = new SIMSContext();
                ctx.Feedbacks.Update(Entity);
                ctx.SaveChanges();
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
