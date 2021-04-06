using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using MyBlogServerSide.Data;

namespace MyBlogServerSide.Pages
{
    //This class is named something completelly different than the razor file (even if the file is named the same)
    public class FetchDataWithInheritsModel:ComponentBase
    {
        [Inject]
        public WeatherForecastService ForecastService { get; set; }
        protected WeatherForecast[] forecasts;

        protected override async Task OnInitializedAsync()
        {
            forecasts = await ForecastService.GetForecastAsync(DateTime.Now);
        }
    }

}
