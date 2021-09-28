
namespace BLL.Entities
{
    public class Topic : EntityBase
    {
        int topicID;
        public int TopID
        {
            get => topicID;
            set
            {
                if ((value != topicID))
                {
                    topicID = value;
                    if (this.State != EntityState.Added)
                        this.State = EntityState.Modified;
                }
            }
        }
        string courseID;
        public string CourseID
        {
            get => courseID;
            set
            {
                if ((value != courseID))
                {
                    courseID = value;
                    if (this.State != EntityState.Added)
                        this.State = EntityState.Modified;
                }
            }

        }
        string topName;
        public string TopName
        {
            get => topName;
            set
            {
                if ((value != topName))
                {
                    topName = value;
                    if (this.State != EntityState.Added)
                        this.State = EntityState.Modified;
                }
            }

        }
        public Topic()
        {
            State = EntityState.Added;
        }
    }
}
