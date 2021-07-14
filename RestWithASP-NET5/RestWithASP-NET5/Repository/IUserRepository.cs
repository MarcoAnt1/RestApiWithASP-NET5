using RestWithASP_NET5.Data.VO;
using RestWithASP_NET5.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASP_NET5.Repository
{
    public interface IUserRepository
    {
        User ValidadeCredentials(UserVO user);
    }
}
