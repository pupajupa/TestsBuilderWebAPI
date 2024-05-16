using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestsBuilder.Application.Common.Interfaces.Services;

namespace TestsBuilder.Infastructure.Services
{
    public class DateTimeProvider:IDateTimeProvider
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}
