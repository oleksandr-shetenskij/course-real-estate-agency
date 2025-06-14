using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Course.Models
{
    public class RealEstateAgency
    {
        public List<Apartment> Offers { get; set; } = new List<Apartment>();
        public List<Demand> Demands { get; set; } = new List<Demand>();

        private const string OffersFile = "offers.json";
        private const string DemandsFile = "demands.json";

        public void AddOffer(Apartment apt) => Offers.Add(apt);
        public void AddDemand(Demand dem) => Demands.Add(dem);

        public List<Apartment> FindMatches(Demand demand)
        {
            string norm(string value) => value?.Trim().ToLower() ?? "";

            return Offers.Where(offer =>
                demand.PreferredDistricts.Any(d => norm(offer.District).Contains(norm(d))) &&
                demand.PreferredHouseTypes.Any(h => norm(offer.HouseDescription).Contains(norm(h))) &&
                demand.PreferredFlatTypes.Any(f => norm(offer.FlatDescription).Contains(norm(f))) &&
                offer.Price >= demand.MinPrice &&
                offer.Price <= demand.MaxPrice
            ).ToList();
        }

        public void SaveToFiles()
        {
            foreach (var offer in Offers)
                offer.SyncPhotosToBase64();

            File.WriteAllText(OffersFile, JsonSerializer.Serialize(Offers));
            File.WriteAllText(DemandsFile, JsonSerializer.Serialize(Demands));
        }

        public void LoadFromFiles()
        {
            if (File.Exists(OffersFile))
            {
                Offers = JsonSerializer.Deserialize<List<Apartment>>(File.ReadAllText(OffersFile)) ?? new();
                foreach (var offer in Offers)
                    offer.RestorePhotos();
            }

            if (File.Exists(DemandsFile))
            {
                Demands = JsonSerializer.Deserialize<List<Demand>>(File.ReadAllText(DemandsFile)) ?? new();
            }
        }
    }
}
