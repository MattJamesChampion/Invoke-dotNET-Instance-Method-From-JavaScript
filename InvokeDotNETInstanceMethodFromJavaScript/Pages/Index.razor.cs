using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace InvokeDotNETInstanceMethodFromJavaScript.Pages;

public partial class Index: IDisposable
{
    //Bundle/set up class instance
    [Inject] private IJSRuntime? JsRuntime { get; set; }
    
    private DotNetObjectReference<Index>? _objRef;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await BundleAndSendDotNetHelper();
        await base.OnAfterRenderAsync(firstRender);
    }

    private async Task BundleAndSendDotNetHelper()
    {
        _objRef = DotNetObjectReference.Create(this);
        if (JsRuntime != null)
        {
            await JsRuntime.InvokeAsync<string>("SetDotNetHelper", _objRef);
        }
    }
    
    public void Dispose()
    {
        _objRef?.Dispose();
    }
    
    //Invoke method
    private int _currentNumber;
    
    [JSInvokable]
    public void BlazorMethod()
    {
        _currentNumber++;
        StateHasChanged();
    }
}
