using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Serfine.PublicAPI.Endpoints.Content;
using Swashbuckle.AspNetCore.Annotations;

namespace Serfine.PublicAPI.Endpoints.Twitter;

[ApiController]
[Route("api/twitter")]
public class GenerateTwitterPostsEndpoint: EndpointBaseAsync
    .WithRequest<GenerateTwitterPostOptions>
    .WithActionResult<TwitterPostDto>
{
    [HttpPost("posts/generate")]
    [SwaggerOperation(
        Summary = "Generate twitter posts",
        Description = "Generates twitter posts based on provided twitterPostOptions",
        OperationId = "Twitter.GenerateTwitterPosts",
        Tags = new[] { "Twitter" })
    ]
    public override async Task<ActionResult<TwitterPostDto>> HandleAsync(GenerateTwitterPostOptions request, CancellationToken cancellationToken = new CancellationToken())
    {
        throw new NotImplementedException();
    }
}