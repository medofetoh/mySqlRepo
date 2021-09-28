
namespace BLL.Entities
{
    public class Question : EntityBase
    {
        int questID;
        public int QuestID
        {
            get => questID;
            set
            {
                if ((value != questID))
                {
                    questID = value;
                    if (this.State != EntityState.Added)
                        this.State = EntityState.Modified;
                }
            }
        }

        string questType;
        public string QuestType
        {
            get => questType;
            set
            {
                if ((value != questType))
                {
                    questType = value;
                    if (this.State != EntityState.Added)
                        this.State = EntityState.Modified;
                }
            }
        }

        string questBody;
        public string QuestBody
        {
            get => questBody;
            set
            {
                if ((value != questBody))
                {
                    questBody = value;
                    if (this.State != EntityState.Added)
                        this.State = EntityState.Modified;
                }
            }
        }
        int marks;
        public int Marks
        {
            get => marks;
            set
            {
                if ((value != marks))
                {
                    marks = value;
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
        string correctAns;
        public string CorrectAns
        {
            get => correctAns;
            set
            {
                if ((value != correctAns))
                {
                    correctAns = value;
                    if (this.State != EntityState.Added)
                        this.State = EntityState.Modified;
                }
            }
        }
        public Question()
        {
            State = EntityState.Added;
        }
    }
}
