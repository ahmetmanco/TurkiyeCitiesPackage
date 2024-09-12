using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace TurkiyeCitiesPackage
{
    public class CityServices
    {
        private readonly List<City> _cityList;

        public CityServices()
        {
            var citiesJson = File.ReadAllText("Cities.json");
            _cityList = JsonConvert.DeserializeObject<List<City>>(citiesJson);
        }
        public List<City> GetAllCities()
        {
            return _cityList;
        }

        public City GetCityById(int id)
        {
            return _cityList.FirstOrDefault(x => x.Id == id);
        }
        public List<Districts> GetDistrictsByCityId(int cityId)
        {
            var city = _cityList.FirstOrDefault(c => c.Id == cityId);
            return city?.Districts;
        }
    }
}
