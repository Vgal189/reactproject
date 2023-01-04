using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace reactproject.ViewModels
{
    public class OrderViewModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string CustomerId { get; set; } 
        public CustomerInfoViewModel Customer { get; set; }
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public List<OrderItemViewModel> Items { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
