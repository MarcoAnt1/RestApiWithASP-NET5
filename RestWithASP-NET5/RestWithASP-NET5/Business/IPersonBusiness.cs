using RestWithASP_NET5.Data.VO;
using System.Collections.Generic;

namespace RestWithASP_NET5.Business
{
    public interface IPersonBusiness
    {
        PersonVO Create(PersonVO person);

        PersonVO Update(PersonVO person);

        void Delete(long id);

        PersonVO FindById(long id);

        List<PersonVO> FindAll();
    }
}
