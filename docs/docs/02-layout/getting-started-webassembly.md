---
id: blazor-webassembly
sidebar_label: Blazor WebAssembly
sidebar_position: 1
title: Blazor WebAssembly
---

# Layout Setup - Blazor WebAssembly

Get started with the Enterprise-class Blazor Bootstrap Component library built on the Blazor and Bootstrap CSS framework.

## Prerequisites

Assuming you followed the getting started docs for the initial setup.

1. **Blazor WebAssembly Project:** Follow the [getting started](/docs/getting-started/blazor-webassembly) steps for the initial setup.
1. **Blazor Server Project:** Follow the [getting started](/docs/getting-started/blazor-server) steps for the initial setup.

## Steps

Replace **MainLayout.razor** page code with the below code.

:::danger NOTE
Remove all the CSS content from the **Shared/MainLayout.razor.css** file.
:::

```cshtml {} showLineNumbers
@inherits LayoutComponentBase

<div class="bb-page">

    <Sidebar @ref="sidebar"
             IconName="IconName.BootstrapFill"
             Title="Blazor Bootstrap"
             DataProvider="SidebarDataProvider" />

    <main>
        <div class="bb-top-row px-4 d-flex justify-content-end">
            <a href="https://docs.microsoft.com/aspnet/" target="_blank">About</a>
        </div>

        <article class="content px-4">
            <div class="py-2">
                @Body
            </div>
        </article>
    </main>

</div>

@code {
    private Sidebar sidebar = default!;
    private IEnumerable<NavItem> navItems = default!;

    private async Task<SidebarDataProviderResult> SidebarDataProvider(SidebarDataProviderRequest request)
    {
        if (navItems is null)
            navItems = GetNavItems();

        return await Task.FromResult(request.ApplyTo(navItems));
    }

    private IEnumerable<NavItem> GetNavItems()
    {
        navItems = new List<NavItem>
        {
            new NavItem { Id = "1", Href = "/", IconName = IconName.HouseDoorFill, Text = "Home", Match=NavLinkMatch.All},
            new NavItem { Id = "2", Href = "/counter", IconName = IconName.PlusSquareFill, Text = "Counter"},
            new NavItem { Id = "3", Href = "/fetchdata", IconName = IconName.Table, Text = "Fetch Data"},
        };

        return navItems;
    }
}
```

## Starter templates

### .NET 6

1. [Blazor Bootstrap - Blazor WebAssembly App](https://github.com/vikramlearning/blazorbootstrap-starter-templates/tree/master/src/BlazorBootstrap.Templates.Starter/NET6.BlazorWebAssemblyApp)

   <img src="https://i.imgur.com/aRV3rJm.png" alt="Blazor Bootstrap - Blazor WebAssembly App" />

### .NET 7

1. [Blazor Bootstrap - Blazor WebAssembly App](https://github.com/vikramlearning/blazorbootstrap-starter-templates/tree/master/src/BlazorBootstrap.Templates.Starter/NET7.BlazorWebAssemblyApp)

   <img src="https://i.imgur.com/4P8u0HR.png" alt="Blazor Bootstrap - Blazor WebAssembly App" />

1. [Blazor Bootstrap - Blazor Empty WebAssembly App](https://github.com/vikramlearning/blazorbootstrap-starter-templates/tree/master/src/BlazorBootstrap.Templates.Starter/NET7.BlazorWebAssemblyAppEmpty)

   <img src="https://i.imgur.com/CBEoZ6P.png" alt="Blazor Bootstrap - Blazor Empty WebAssembly App" />
