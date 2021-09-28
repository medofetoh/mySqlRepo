using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Entities
{
    public class StudentAnswer:EntityBase
    {
        /* @StudAnswer varchar(100),@quesID int , @quesType varchar(20)*/
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

        string studAnswer;
        public string StudAnswer
        {
            get => studAnswer;
            set
            {
                if ((value != studAnswer))
                {
                    studAnswer = value;
                    if (this.State != EntityState.Added)
                        this.State = EntityState.Modified;
                }
            }
        }
        public StudentAnswer()
        {
            this.State = EntityState.Added;
        }

    }
}
