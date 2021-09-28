
namespace BLL.Entities
{
    public class StudentCourse : EntityBase
    {
        int id;
        public int StudID
        {
            get => id;
            set
            {
                if ((value != id))
                {
                    id = value;
                    if (this.State != EntityState.Added)
                        this.State = EntityState.Modified;
                }
            }
        }
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
        int? courseMarks;
        public int? CourseMarks
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
        public StudentCourse()
        {
            State = EntityState.Added;
        }
    }
}
