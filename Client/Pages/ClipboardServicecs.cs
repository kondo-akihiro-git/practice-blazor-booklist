using Microsoft.JSInterop;

public class ClipboardService : BlazorApp.Client.Pages.IClipboardService
{
    private readonly IJSRuntime _jsInterop;

    public ClipboardService(IJSRuntime jsInterop)
    {
        _jsInterop = jsInterop;
    }

    public async Task CopyToClipboard(string text)
    {

        await _jsInterop.InvokeVoidAsync("navigator.clipboard.writeText", text);
    }
}