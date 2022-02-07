function SetDotNetHelper(dotNetHelper) {
    window.dotNetHelper = dotNetHelper;
}

function CallBlazorMethod()
{
    window.dotNetHelper.invokeMethodAsync('BlazorMethod');
}
