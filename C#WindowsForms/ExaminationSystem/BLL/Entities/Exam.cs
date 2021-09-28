
namespace BLL.Entities
{
   public class Exam : EntityBase
    {
        int examID;
        public int ExamID
        {
            get => examID;
            set
            {
                if ((value != examID) )
                {
                    examID = value;
                    if (this.State != EntityState.Added)
                        this.State = EntityState.Modified;
                }
            }
        }
        int examNoOfQuest;
        public int ExamNoOfQuest
        {
            get => examNoOfQuest;
            set
            {
                if ((value != examNoOfQuest) )
                {
                    examNoOfQuest = value;
                    if (this.State != EntityState.Added)
                        this.State = EntityState.Modified;
                }
            }
        }
        string examDateTime;
        public string ExamDatetime
        {
            get => examDateTime;
            set
            {
                if ((value != examDateTime) )
                {
                    examDateTime = value;
                    if (this.State != EntityState.Added)
                        this.State = EntityState.Modified;
                }
            }
        }
        int? examDuration;
        public int? ExamDuration
        {
            get => examDuration;
            set
            {
                if ((value != examDuration) )
                {
                    examDuration = value;
                    if (this.State != EntityState.Added)
                        this.State = EntityState.Modified;
                }
            }
        }

        string examType;
        public string ExamType
        {
            get => examType;
            set
            {
                if ((value != examType) )
                {
                    examType = value;
                    if (this.State != EntityState.Added)
                        this.State = EntityState.Modified;
                }
            }
        }
        public Exam()
        {
            State = EntityState.Added;
        }
    }
}
