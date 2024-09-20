using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace ChrisCafe.Models.HealthChecks
{
    public class LiveCheck : IHealthCheck
    {
        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(HealthCheckResult.Healthy());
        }
    }
}
