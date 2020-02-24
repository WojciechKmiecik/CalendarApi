using CalendarApi.Dal.DataModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CalendarApi.Definition.DataServices
{
    public interface ILocationsDataService
    {
        Task<LocationModel> Add(string name);
        Task<LocationModel> Get(string name);
    }
}
