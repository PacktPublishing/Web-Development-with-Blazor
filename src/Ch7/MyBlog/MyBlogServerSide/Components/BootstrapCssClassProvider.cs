using System;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components;
using System.Linq;
using Blazm;

namespace Microsoft.AspNetCore.Components.Forms
{
    public class CustomCssClassProvider<T> : ComponentBase where T: FieldCssClassProvider
    {
        [CascadingParameter]
        EditContext? CurrentEditContext { get; set; }

        public FieldCssClassProvider provider { get; set; } = default!;

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