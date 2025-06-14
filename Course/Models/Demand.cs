using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Course.Models
{

    public class Demand
    {
        public List<string> PreferredDistricts { get; set; }
        public List<string> PreferredHouseTypes { get; set; }
        public List<string> PreferredFlatTypes { get; set; }

        public decimal MinPrice { get; set; }
        public decimal MaxPrice { get; set; }

        public string BuyerName { get; set; }
        public string PhoneNumber { get; set; }

        [JsonIgnore]
        public string DistrictsDisplay => string.Join(", ", PreferredDistricts);

        [JsonIgnore]
        public string HouseTypesDisplay => string.Join(", ", PreferredHouseTypes);

        [JsonIgnore]
        public string FlatTypesDisplay => string.Join(", ", PreferredFlatTypes);

        public Demand() { }

        public Demand(List<string> preferredDistricts,
                      List<string> preferredHouseTypes,
                      List<string> preferredFlatTypes,
                      decimal minPrice,
                      decimal maxPrice,
                      string buyerName,
                      string phoneNumber)
        {
            PreferredDistricts = preferredDistricts ?? new List<string>();
            PreferredHouseTypes = preferredHouseTypes ?? new List<string>();
            PreferredFlatTypes = preferredFlatTypes ?? new List<string>();
            MinPrice = minPrice;
            MaxPrice = maxPrice;
            BuyerName = buyerName;
            PhoneNumber = phoneNumber;
        }

        public override string ToString()
        {
            return $"{BuyerName} — {MinPrice:C} до {MaxPrice:C}";
        }
    }
}
