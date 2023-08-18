using System;
using ProductManagement.Application.Interfaces;

namespace ProductManagement.Infrastructure.Persistence.Services
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime NowUtc => DateTime.UtcNow;
    }
}