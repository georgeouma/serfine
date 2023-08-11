using Serfine.PublicAPI.Endpoints.Content;

namespace Serfine.PublicAPI.Endpoints.Twitter;

public class GenerateTwitterPostOptions: GenerateContentOptions
{
    public string NumberOfPosts { get; set; }
    public ProductInfo ProductInfo { get; set; }
}