namespace Serfine.PublicAPI.Infrastructure;

public class AppSetting
{
    public OpenAIApiOptions OpenAIApiOptions { get; set; }
    public TwitterApiOptions TwitterApiOptions { get; set; }
}

public class TwitterApiOptions
{
    public string ConsumerKey { get; set; }
    public string ConsumerSecret { get; set; }
    public string AccessToken { get; set; }
}

public class OpenAIApiOptions
{
    public string ApiKey { get; set; }
}
