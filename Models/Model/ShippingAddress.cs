namespace Models.Model
{
    public class ShippingAddress
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobilePhone { get; set; }
        public long ProvinceId { get; set; }
        public long DistrictId { get; set; }
        public long SubDistrictId { get; set; }
        public string Address { get; set; }
        public bool IsDefault { get; set; }
    }
}
