using Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FonNature.Services
{
    public class BookingService : IBookingService
    {
        private readonly IServiceRepository _serviceRepository;
        public BookingService(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        
    }
}