﻿namespace BlazorBootstrap;

public partial class Tooltip : BaseComponent
{
    #region Members

    private bool isFirstRenderComplete = false;
    private DotNetObjectReference<Tooltip> objRef = default!;
    private string title = default!;
    private TooltipColor color = default!;

    private string colorClass => BootstrapClassProvider.TooltipColor(Color);
    private string placement => Placement.ToTooltipPlacementName();

    #endregion Members

    #region Methods

    protected override async Task OnInitializedAsync()
    {
        title = Title;
        color = Color;
        objRef ??= DotNetObjectReference.Create(this);

        await base.OnInitializedAsync();

        ExecuteAfterRender(async () => { await JS.InvokeVoidAsync("window.blazorBootstrap.tooltip.initialize", ElementRef); });
    }

    protected override async Task OnParametersSetAsync()
    {
        if (isFirstRenderComplete)
        {
            if (title != Title || color != Color)
            {
                title = Title;
                color = Color;

                await JS.InvokeVoidAsync("window.blazorBootstrap.tooltip.dispose", ElementRef);
                await JS.InvokeVoidAsync("window.blazorBootstrap.tooltip.update", ElementRef);
            }
        }
    }

    protected override void OnAfterRender(bool firstRender)
    {
        if (firstRender)
            isFirstRenderComplete = true;

        base.OnAfterRender(firstRender);
    }

    /// <inheritdoc />
    protected override async ValueTask DisposeAsync(bool disposing)
    {
        if (disposing)
        {
            ExecuteAfterRender(async () => { await JS.InvokeVoidAsync("window.blazorBootstrap.tooltip.dispose", ElementRef); });
            objRef?.Dispose();
        }

        await base.DisposeAsync(disposing);
    }

    #endregion Methods

    #region Properties

    /// <inheritdoc/>
    protected override bool ShouldAutoGenerateId => true;

    /// <summary>
    /// Specifies the content to be rendered inside this.
    /// </summary>
    [Parameter] public RenderFragment ChildContent { get; set; } = default!;

    /// <summary>
    /// Displays informative text when users hover, focus, or tap an element.
    /// </summary>
    [Parameter, EditorRequired] public string Title { get; set; } = default!;

    /// <summary>
    /// Specifies the tooltip placement. Default is top right.
    /// </summary>
    [Parameter]
    public TooltipPlacement Placement { get; set; } = TooltipPlacement.Top;

    [Parameter]
    public TooltipColor Color { get; set; }

    #endregion Properties
}
