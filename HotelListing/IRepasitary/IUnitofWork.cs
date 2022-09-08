﻿using HotelListing.Data;

namespace HotelListing.IRepasitary
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Country> Countries { get; }
        IGenericRepository<Hotel> Hotels { get; } 
        Task Save();

    }
}
