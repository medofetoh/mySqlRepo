
namespace BLL.Entities
{
    public class Department : EntityBase
    {
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
        string depDesc;
        public string DeptDesc
        {
            get => depDesc;
            set
            {
                if ((value != depDesc))
                {
                    depDesc = value;
                    if (this.State != EntityState.Added)
                        this.State = EntityState.Modified;
                }
            }
        }
        string depNmae;
        public string DeptName
        {
            get => depNmae;
            set
            {
                if ((value != depNmae))
                {
                    depNmae = value;
                    if (this.State != EntityState.Added)
                        this.State = EntityState.Modified;
                }
            }
        }
        public Department()
        {
            State = EntityState.Added;
        }
    }

}
