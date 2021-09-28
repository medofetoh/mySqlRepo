
namespace BLL.Entities
{
    public class ExamQuestion : EntityBase
    {
        int examID;
        public int ExamID
        {
            get => examID;
            set
            {
                if ((value != examID))
                {
                    examID = value;
                    if (this.State != EntityState.Added)
                        this.State = EntityState.Modified;
                }
            }
        }

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

        public ExamQuestion()
        {
            State = EntityState.Added;
        }
    }
}
