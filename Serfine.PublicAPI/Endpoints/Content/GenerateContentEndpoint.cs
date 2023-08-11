using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Serfine.PublicAPI.Infrastructure;
using Swashbuckle.AspNetCore.Annotations;

namespace Serfine.PublicAPI.Endpoints.Content;

[ApiController]
[Route("api/content")]
public class GenerateContentEndpoint : EndpointBaseAsync.WithRequest<GenerateContentOptions>
    .WithActionResult<GeneratedContent>
{
    private readonly ILogger<GenerateContentEndpoint> _logger;
    private readonly OpenAIApiOptions _openAiOptions;
    
    public GenerateContentEndpoint(IOptions<OpenAIApiOptions> openAiOptions,
        ILogger<GenerateContentEndpoint> logger)
    {
        _openAiOptions = openAiOptions.Value;
        _logger = logger;
    }

    [HttpPost("generate")]
    [SwaggerOperation(
        Summary = "Generate content",
        Description = @"Generates content based on provided ContentOptions",
        OperationId = "Content.Generate",
        Tags = new[] { "Content" })
    ]
    public override async Task<ActionResult<GeneratedContent>> HandleAsync(GenerateContentOptions options, CancellationToken cancellationToken = new CancellationToken())
    {
        throw new NotImplementedException();
    }
}