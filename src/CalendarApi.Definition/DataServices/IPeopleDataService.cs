using CalendarApi.Definition.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CalendarApi.Definition.DataServices
{
    public interface IPeopleDataService
    {
        Task<List<PeopleModel>> AddNonExistingPeople(List<string> peolpleNames);
        Task<List<PeopleModel>> GetAllFromList(List<string> peolpleNames);
    }
}
