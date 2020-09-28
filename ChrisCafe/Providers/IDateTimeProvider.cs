using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChrisCafe.Data.Providers
{
    public interface IDateTimeProvider
    {
        DateTime Today { get; }
        DateTime Now { get; }
        DateTime NowUtc { get; }
    }
}
