using CalendarApi.Dal.DataModels;
using CalendarApi.Definition.Models;

namespace CalendarApi.Dal.Mappings
{
    internal static class PeopleMapper
    {
        public static PeopleEntity Map(this PeopleModel model)
        {
            var entity = new PeopleEntity();
            if (model != null)
            {
                entity.Id = model.Id;
                entity.Name = model.Name;
                
                //TODO : extend it
            }
            return entity;
        }
        public static PeopleModel Map(this PeopleEntity entity)
        {
            var model = new PeopleModel();
            if (entity != null)
            {
                model.Id = entity.Id;
                model.Name = entity.Name;
                //TODO : extend it
            }
            return model;
        }
    }
}
