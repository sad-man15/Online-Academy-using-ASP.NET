using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface IRepo2<TYPE, ID, RET>:IRepo<TYPE, ID,RET>
    {
        TYPE Get(string name,string password);
        RET ChangePass(int id, string password, string newPassword);
        TYPE ForgetPass(string gmail);
        bool ResetPass(int id, string password);
    }
}
