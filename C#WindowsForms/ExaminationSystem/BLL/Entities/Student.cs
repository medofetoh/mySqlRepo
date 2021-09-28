
namespace BLL.Entities
{
    public class Student : EntityBase
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
        string studFName;
        public string StudFName
        {
            get => studFName;
            set
            {
                if ((value != studFName))
                {
                    studFName = value;
                    if (this.State != EntityState.Added)
                        this.State = EntityState.Modified;
                }
            }

        }

        string studLName;
        public string StudLName
        {
            get => studLName;
            set
            {
                if ((value != studLName))
                {
                    studLName = value;
                    if (this.State != EntityState.Added)
                        this.State = EntityState.Modified;
                }
            }

        }

        string studEmail;
        public string StudEmail
        {
            get => studEmail;
            set
            {
                if ((value != studEmail))
                {
                    studEmail = value;
                    if (this.State != EntityState.Added)
                        this.State = EntityState.Modified;
                }
            }

        }
        string studPassword;
        public string StudPassword
        {
            get => studPassword;
            set
            {
                if ((value != studPassword))
                {
                    studPassword = value;
                    if (this.State != EntityState.Added)
                        this.State = EntityState.Modified;
                }
            }

        }

        char studTotalGrade;
        public char StudTotalGrade
        {
            get => studTotalGrade;
            set
            {
                if ((value != studTotalGrade))
                {
                    studTotalGrade = value;
                    if (this.State != EntityState.Added)
                        this.State = EntityState.Modified;
                }
            }

        }
        string depID;
        public string DeptID
        {
            get => depID;
            set
            {
                if ((value != depID))
                {
                    depID = value;
                    if (this.State != EntityState.Added)
                        this.State = EntityState.Modified;
                }
            }

        }
        public Student()
        {
            State = EntityState.Added;
        }
    }
}
