namespace Models.Repository
{
    public interface IIPAddressRepository
    {
        bool AddIpAddress(string IpAddress);
        bool AddVisitor(string infor);
    }
}
