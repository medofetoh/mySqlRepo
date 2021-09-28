
namespace BLL.Entities
{
    public class Choice : EntityBase
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

        public Choice()
        {
            State = EntityState.Added;
        }
    }
}
