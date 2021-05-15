using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;

namespace MyBlogServerSide.Components
{
    public class CustomCssClassProvider<ProviderType>:ComponentBase where ProviderType:FieldCssClassProvider,new()
    {
        [CascadingParameter]
        EditContext? CurrentEditContext { get; set; }
        public ProviderType provider { get; set; } = new ProviderType();
        protected override void OnInitialized()
        {
            if (CurrentEditContext == null)
            {
                throw new InvalidOperationException($"{nameof(DataAnnotationsValidator)} requires a cascading " +
                    $"parameter of type {nameof(EditContext)}. For example, you can use {nameof(DataAnnotationsValidator)} " +
                    $"inside an EditForm.");
            }
            CurrentEditContext.SetFieldCssClassProvider(provider);
        }
    }
}
