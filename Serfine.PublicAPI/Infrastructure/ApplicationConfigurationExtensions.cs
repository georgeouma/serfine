using Azure.Extensions.AspNetCore.Configuration.Secrets;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;

namespace Serfine.PublicAPI.Infrastructure;

public static class ApplicationConfigurationExtensions
{
    public static void ConfigureAppSettings(this WebApplicationBuilder builder)
    {
        var appSettingSection = builder.Configuration.GetSection("AppSettings");
        builder.Services.Configure<AppSetting>(appSettingSection);
        
        // OpenAI API Options
        var openAiOptionsSection = appSettingSection.GetSection(nameof(OpenAIApiOptions));
        builder.Services.AddOptions<OpenAIApiOptions>()
            .Bind(openAiOptionsSection)
            .ValidateDataAnnotations();
        
        // Twitter API Options
        var twitterApiOptionsSection = appSettingSection.GetSection(nameof(TwitterApiOptions));
        builder.Services.AddOptions<TwitterApiOptions>()
            .Bind(twitterApiOptionsSection)
            .ValidateDataAnnotations();
        
        // Configure KeyVault AppSettings
        if (builder.Environment.IsProduction())
        {
            string? keyVaultEndpoint = Environment.GetEnvironmentVariable("KEYVAULT_ENDPOINT");

            if (keyVaultEndpoint is null)
                throw new InvalidOperationException(
                    "Store the key vault endpoint in a KEYVAULT_ENDPOINT environment variable.");

            var secretClient = new SecretClient(new(keyVaultEndpoint), new DefaultAzureCredential());
            builder.Configuration.AddAzureKeyVault(secretClient, new KeyVaultSecretManager());
        }

    }
}