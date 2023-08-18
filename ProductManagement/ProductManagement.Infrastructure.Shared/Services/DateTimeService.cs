using ProductManagement.Application.Interfaces;
using System;

namespace ProductManagement.Infrastructure.Shared.Services
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime NowUtc => DateTime.UtcNow;
    }
}