using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace InvokeDotNETInstanceMethodFromJavaScript.Pages;

public partial class Index: IDisposable
{
    [Inject] private IJSRuntime? JsRuntime { get; set; }
    
    private DotNetObjectReference<Index>? _objRef;
    private int _currentNumber;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await SetDotNetHelper();
        await base.OnAfterRenderAsync(firstRender);
    }

    private async Task SetDotNetHelper()
    {
        _objRef = DotNetObjectReference.Create(this);
        if (JsRuntime != null) await JsRuntime.InvokeAsync<string>("SetDotNetHelper", _objRef);
    }
    
    [JSInvokable]
    public void BlazorMethod()
    {
        _currentNumber++;
        StateHasChanged();
    }

    public void Dispose()
    {
        _objRef?.Dispose();
    }
}