using HotelListing.Data;

namespace HotelListing.IRepasitary
{
    public interface IUnitofWork : IDisposable
    {
        IGenericRepository<Country> Countries { get; }
        IGenericRepository<Hotel> Hotels { get; } 
        Task Save();

    }
}
