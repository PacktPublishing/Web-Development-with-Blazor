using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using MyBlogServerSide.Data;

namespace MyBlogServerSide.Pages
{
    //<FetchDataWithCodeBehind>
    public partial class FetchDataWithCodeBehind
    {
        [Inject]
        public WeatherForecastService ForecastService { get; set; }
        private WeatherForecast[] forecasts;

        protected override async Task OnInitializedAsync()
        {
            forecasts = await ForecastService.GetForecastAsync(DateTime.Now);
        }
    }
    //</FetchDataWithCodeBehind>
}
