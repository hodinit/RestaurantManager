using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using LocationGrpcService;
using DataAccess = RestaurantManager.Data;
using ModelAccess = RestaurantManager.Models;

namespace LocationGrpcService.Services
{
    public class GrpcCRUDService : LocationService.LocationServiceBase
    {
        private DataAccess.RestaurantManagerContext db = null;
        public GrpcCRUDService(DataAccess.RestaurantManagerContext db)
        {
            this.db = db;
        }
        public override Task<LocationList> GetAll(Empty empty, ServerCallContext context)
        {
            LocationList pl = new LocationList();
            var query = from loc in db.Location
                        select new Location()
                        {
                            Id = loc.Id,
                            Name = loc.Name,
                            Adress = loc.Adress,
                            Number = loc.Number
                        };
            pl.Item.AddRange(query.ToArray());
            return Task.FromResult(pl);
        }
        public override Task<Empty> Insert(Location requestData, ServerCallContext context)
        {
            db.Location.Add(new ModelAccess.Location
            {
                Id = requestData.Id,
                Name = requestData.Name,
                Adress = requestData.Adress,
                Number = requestData.Number
            });
            db.SaveChanges();
            return Task.FromResult(new Empty());
        }

        public override Task<Location> Get(LocationId requestData, ServerCallContext context)
        {
            var data = db.Location.Find(requestData.Id);
            Location loc = new Location()
            {
                Id = data.Id,
                Name = data.Name,
                Adress = data.Adress,
                Number = data.Number
            };
            return Task.FromResult(loc);
        }
        public override Task<Empty> Delete(LocationId requestData, ServerCallContext context)
        {
            var data = db.Location.Find(requestData.Id);
            db.Location.Remove(data);
            db.SaveChanges();
            return Task.FromResult(new Empty());
        }

        public override Task<Location> Update(Location requestData, ServerCallContext context)
        {
            var data = db.Location.Find(requestData.Id);
            data.Name = requestData.Name;
            data.Adress = requestData.Adress;
            data.Number = requestData.Number;
            db.SaveChanges();
            return Task.FromResult(requestData);
        }
    }
}
