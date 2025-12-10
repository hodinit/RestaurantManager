using Grpc.Net.Client;
using Microsoft.AspNetCore.Mvc;
using LocationGrpcService;
using RestaurantManager.Models;
using Location = LocationGrpcService.Location;

namespace RestaurantManager.Controllers
{
    public class LocationsGrpcController : Controller
    {
        private readonly GrpcChannel channel;
        public LocationsGrpcController()
        {
            //a se modifica portul corespunzator (vezi in proiectul GrpcLocationService-> Properties->launchSettings.json)
            channel = GrpcChannel.ForAddress("https://localhost:7139");
        }
        [HttpGet]
        public IActionResult Index()
        {
            var client = new LocationService.LocationServiceClient(channel);
            LocationList cust = client.GetAll(new Empty());
            return View(cust);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Location Location)
        {
            if (ModelState.IsValid)
            {
                var client = new
                LocationService.LocationServiceClient(channel);
                var createdLocation = client.Insert(Location);
                return RedirectToAction(nameof(Index));
            }
            return View(Location);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var client = new LocationService.LocationServiceClient(channel);
            Location Location = client.Get(new LocationId() { Id = (int)id });
            if (Location == null)
            {
                return NotFound();
            }
            return View(Location);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var client = new LocationService.LocationServiceClient(channel);
            Empty response = client.Delete(new LocationId()
            {
                Id = id
            });
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var client = new LocationService.LocationServiceClient(channel);
            Location grpcLocation = client.Get(new LocationId() { Id = (int)id });
            if (grpcLocation == null)
            {
                return NotFound();
            }

            var modelLocation = new RestaurantManager.Models.Location
            {
                Id = grpcLocation.LocationId,
                Name = grpcLocation.Name,
                Adress = grpcLocation.Adress,
                Number = grpcLocation.Number,
            };

            return View(modelLocation);
        }

        [HttpPost]
        public IActionResult Update(RestaurantManager.Models.Location Location)
        {
            if (ModelState.IsValid)
            {
                var client = new LocationService.LocationServiceClient(channel);

                var grpcLocation = new Location
                {
                    LocationId = Location.Id,
                    Name = Location.Name,
                    Adress = Location.Adress,
                    Number = Location.Number,
                };

                client.Update(grpcLocation);
                return RedirectToAction(nameof(Index));
            }
            return View(Location);
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
                return NotFound();
                        
            var client = new LocationService.LocationServiceClient(channel);
            Location grpcLocation = client.Get(new LocationId() { Id = (int)id });
            if (grpcLocation == null)
                return NotFound();

            var modelLocation = new RestaurantManager.Models.Location
            {
                Id = grpcLocation.LocationId,
                Name = grpcLocation.Name,
                Adress = grpcLocation.Adress,
                Number = grpcLocation.Number,
            };

            return View(modelLocation);
        }
    }
}
