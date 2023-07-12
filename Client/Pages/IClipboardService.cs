namespace BlazorApp.Client.Pages
{
    public interface IClipboardService
    {
        Task CopyToClipboard(string text);
    }
}
