
namespace BLL.Entities
{
    public class StudentExam : EntityBase
    {
        /*
         * Q.QuestID, Q.QuestType ,Q.QuestBody,Q.CourseID ,Ch.QuestChoices
         * for the stored porcedure 
         */

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

        string questChoices;
        public string QuestChoices
        {
            get => questChoices;
            set
            {
                if ((value != questChoices))
                {
                    questChoices = value;
                    if (this.State != EntityState.Added)
                        this.State = EntityState.Modified;
                }
            }
        }
    }
}
