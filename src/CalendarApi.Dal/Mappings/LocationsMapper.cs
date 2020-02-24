using CalendarApi.Dal.DataModels;
using CalendarApi.Definition.Models;

namespace CalendarApi.Dal.Mappings
{
    internal static class LocationsMapper
    {
        public static LocationsEntity Map(this LocationModel model)
        {
            var entity = new LocationsEntity();
            if (model != null)
            {
                entity.Id = model.Id;
                entity.Name = model.Name;
                
                //TODO : extend it
            }
            return entity;
        }
        public static LocationModel Map(this LocationsEntity entity)
        {
            var model = new LocationModel();
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
