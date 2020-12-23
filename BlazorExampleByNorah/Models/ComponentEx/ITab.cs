using Microsoft.AspNetCore.Components;

namespace BlazorExampleByNorah.Models
{
    public interface ITab
    {
        RenderFragment ChildContent { get; }
    }
}
