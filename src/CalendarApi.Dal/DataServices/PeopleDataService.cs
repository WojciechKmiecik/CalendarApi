using CalendarApi.Dal.DataModels;
using CalendarApi.Dal.Mappings;
using CalendarApi.Definition.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalendarApi.Definition.DataServices;

namespace CalendarApi.Dal.DataServices
{
    internal class PeopleDataService : IPeopleDataService
    {
        private readonly CalendarContext _context;

        public PeopleDataService(CalendarContext context)
        {
            _context = context;
        }

        // add exception handling

        public async Task<List<PeopleModel>> GetAllFromList(List<string> peolpleNames)
        {
            var pList = await _context.Peoples.Where(pe => peolpleNames.Any(pn => pe.Name.ToLower() == pn.ToLower())).Select(x => x.Map()).ToListAsync();
            return pList;
        }

        public async Task<List<PeopleModel>> AddNonExistingPeople(List<string> peolpleNames)
        {

            var P = peolpleNames.Where(x => !_context.Peoples.ToList().Any(y => y.Name == x)).ToList();
            foreach (var item in P)
            {
                await _context.AddAsync(new PeopleEntity() { Name = item });
            }
            await _context.SaveChangesAsync();
            return await this.GetAllFromList(peolpleNames);
        }
    }
}
