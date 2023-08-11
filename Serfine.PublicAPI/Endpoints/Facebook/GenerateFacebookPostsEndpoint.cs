using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Serfine.PublicAPI.Endpoints.Facebook;

[ApiController]
[Route("api/facebook")]
public class GenerateFacebookPostsEndpoint: EndpointBaseAsync
    .WithRequest<GenerateFacebookPostOptions>
    .WithActionResult<FacebookPostDto>
{
    [HttpPost("posts/generate")]
    [SwaggerOperation(
        Summary = "Generate facebook posts",
        Description = "Generates facebook posts based on provided facebookPostOptions",
        OperationId = "Facebook.GenerateFacebookPosts",
        Tags = new[] { "Facebook" })
    ]
    public override async Task<ActionResult<FacebookPostDto>> HandleAsync(GenerateFacebookPostOptions options, CancellationToken cancellationToken = new CancellationToken())
    {
        throw new NotImplementedException();
    }
}

public class FacebookPostDto
{
    public string Message { get; set; }
}

public class GenerateFacebookPostOptions
{
}