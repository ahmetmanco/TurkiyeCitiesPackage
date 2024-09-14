using Newtonsoft.Json;
using System.Reflection;

namespace TurkiyeCitiesPackage
{
    public class CityServices
    {
        private readonly List<City> _cityList;

        public CityServices()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "TurkiyeCitiesPackage.Cities.json"; // Dosya yolunu belirtin

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
                if (stream == null)
                {
                    throw new Exception($"Resource {resourceName} not found.");
                }

                using (StreamReader reader = new StreamReader(stream))
                {
                    var citiesJson = reader.ReadToEnd();
                    _cityList = JsonConvert.DeserializeObject<List<City>>(citiesJson);
                }
            }
        }

        public List<City> GetAllCities()
        {
            return _cityList;
        }

        public City GetCityById(int id)
        {
            return _cityList.FirstOrDefault(x => x.Id == id);
        }

        public List<District> GetDistrictsByCityId(int cityId)
        {
            var city = _cityList.FirstOrDefault(c => c.Id == cityId);
            return city?.Districts;
        }
    }
}