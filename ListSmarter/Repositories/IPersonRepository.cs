using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListSmarter.Repositories
{
    public interface IPersonRepository
    {
        List<PersonDto> getAll();
        
    }
}