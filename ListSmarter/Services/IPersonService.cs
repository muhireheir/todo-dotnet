using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListSmarter.Services
{
    public interface IPersonService
    {
        List<PersonDto> getAllPeople();
    }
}