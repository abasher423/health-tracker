using Infrastructure.Authentication;
using Microsoft.Extensions.Options;

namespace HealthTracker.OptionsSetup;

public class JwtOptionsSetup : IConfigureNamedOptions<JwtOptions>
{
    private const string SectionName = "Jwt";
    private readonly IConfiguration _configuration;

    public JwtOptionsSetup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void Configure(JwtOptions options)
    {
        _configuration.GetSection(SectionName).Bind(options);
    }

    public void Configure(string? name, JwtOptions options)
    {
    }
}