using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Course.Models
{
    public class Apartment
    {
        public string District { get; set; }
        public string Address { get; set; }
        public string HouseDescription { get; set; }
        public string FlatDescription { get; set; }
        public decimal Price { get; set; }
        public string OwnerName { get; set; }
        public string PhoneNumber { get; set; }

        [JsonIgnore]
        public List<Image> Photos { get; set; } = new();

        public List<string> PhotoBase64List { get; set; } = new();

        public Apartment() { }

        public Apartment(string district, string address, string houseDescription,
                         string flatDescription, decimal price, string ownerName,
                         string phoneNumber, List<Image> photos)
        {
            District = district;
            Address = address;
            HouseDescription = houseDescription;
            FlatDescription = flatDescription;
            Price = price;
            OwnerName = ownerName;
            PhoneNumber = phoneNumber;
            Photos = photos ?? new List<Image>();
            SyncPhotosToBase64();
        }

        public void SyncPhotosToBase64()
        {
            PhotoBase64List = Photos.Select(ImageToBase64).ToList();
        }

        public void RestorePhotos()
        {
            Photos = PhotoBase64List.Select(Base64ToImage).ToList();
        }

        public static string ImageToBase64(Image image)
        {
            using var ms = new MemoryStream();
            image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            return Convert.ToBase64String(ms.ToArray());
        }

        public static Image Base64ToImage(string base64)
        {
            if (string.IsNullOrWhiteSpace(base64)) return null;
            var bytes = Convert.FromBase64String(base64);
            using var ms = new MemoryStream(bytes);
            return Image.FromStream(ms);
        }

        public override string ToString()
        {
            return $"{District}, {Address}, {FlatDescription}, {Price:C}";
        }
    }
}
