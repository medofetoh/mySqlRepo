
namespace BLL.Entities
{
    public class Instructor : EntityBase
    {
        int instID;
        public int InstID
        {
            get => instID;
            set
            {
                if ((value != instID))
                {
                    instID = value;
                    if (this.State != EntityState.Added)
                        this.State = EntityState.Modified;
                }
            }
        }
        string instFName;
        public string InstFName
        {
            get => instFName;
            set
            {
                if ((value != instFName))
                {
                    instFName = value;
                    if (this.State != EntityState.Added)
                        this.State = EntityState.Modified;
                }
            }

        }
        string instLName;
        public string InstLName
        {
            get => instLName;
            set
            {
                if ((value != instLName))
                {
                    instLName = value;
                    if (this.State != EntityState.Added)
                        this.State = EntityState.Modified;
                }
            }

        }
        public string FullName
        {
            get
            {
                return InstFName + " " + InstLName;
            }
        }
        string instEmail;
        public string InstEmail
        {
            get => instEmail;
            set
            {
                if ((value != instEmail))
                {
                    instEmail = value;
                    if (this.State != EntityState.Added)
                        this.State = EntityState.Modified;
                }
            }

        }
        string instPassword;
        public string InstPassword
        {
            get => instPassword;
            set
            {
                if ((value != instPassword))
                {
                    instPassword = value;
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
        public Instructor()
        {
            State = EntityState.Added;
        }
    }
}
