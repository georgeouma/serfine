namespace Serfine.PublicAPI.Endpoints.Content;

public class GenerateContentOptions
{
    public long Id { get; set; }
    public long PromptTemplateId { get; set; }
    public IDictionary<string, string> MetaData { get; set; }
}