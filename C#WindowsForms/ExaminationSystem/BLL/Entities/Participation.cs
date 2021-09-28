
namespace BLL.Entities
{
    public class Participation : EntityBase
    {
        int partID;
        public int PartID
        {
            get => partID;
            set
            {
                if ((value != partID))
                {
                    partID = value;
                    if (this.State != EntityState.Added)
                        this.State = EntityState.Modified;
                }
            }
        }
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
        int? studID;
        public int? StudID
        {
            get => studID;
            set
            {
                if ((value != studID))
                {
                    studID = value;
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
        string studAns;
        public string StudAns
        {
            get => studAns;
            set
            {
                if ((value != studAns))
                {
                    studAns = value;
                    if (this.State != EntityState.Added)
                        this.State = EntityState.Modified;
                }
            }
        }
        int? studMarks;
        public int? StudMarks
        {
            get => studMarks;
            set
            {
                if ((value != studMarks))
                {
                    studMarks = value;
                    if (this.State != EntityState.Added)
                        this.State = EntityState.Modified;
                }
            }
        }
        public Participation()
        {
            State = EntityState.Added;
        }
    }
}
