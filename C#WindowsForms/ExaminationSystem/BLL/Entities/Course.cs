

namespace BLL.Entities
{
    public class Course : EntityBase
    {
        string courseID;
        public string CourseID
        {
            set
            {
                if ((value != courseID))
                {
                    courseID = value;
                    if (this.State != EntityState.Added)
                        this.State = EntityState.Modified;
                }
            }
            get => courseID;
        }
        string courseName;
        public string CourseName
        {
            set
            {
                if ((value != courseName))
                {
                    courseName = value;
                    if (this.State != EntityState.Added)
                        this.State = EntityState.Modified;
                }
            }
            get => courseName;
        }
        int courseMarks;
        public int CourseMarks
        {
            set
            {
                if ((value != courseMarks))
                {
                    courseMarks = value;
                    if (this.State != EntityState.Added)
                        this.State = EntityState.Modified;
                }
            }
            get => courseMarks;
        }
        decimal coursePass;
        public decimal CoursePassPercentage
        {
            set
            {
                if ((value != coursePass))
                {
                    coursePass = value;
                    if (this.State != EntityState.Added)
                        this.State = EntityState.Modified;
                }
            }
            get => coursePass;
        }
        int maxNoOfStuds;

        public int MaxNoOfStuds
        {
            set
            {
                if ((value != maxNoOfStuds))
                {
                    maxNoOfStuds = value;
                    if (this.State != EntityState.Added)
                        this.State = EntityState.Modified;
                }
            }
            get => maxNoOfStuds;
        }
        int instID;
        public int InstID
        {
            set
            {
                if ((value != instID))
                {
                    instID = value;
                    if (this.State != EntityState.Added)
                        this.State = EntityState.Modified;
                }
            }
            get => instID;
        }

        public Course()
        {
            instID = 1013;
            State = EntityState.Added;

        }

    }
}
