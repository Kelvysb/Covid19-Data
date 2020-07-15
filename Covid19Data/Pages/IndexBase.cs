using System.Threading.Tasks;
using Covid19Data.Models;
using Covid19Data.Services;
using Microsoft.AspNetCore.Components;

namespace Covid19Data.Pages
{
    public class IndexBase : ComponentBase
    {
        [Inject]
        public IDataSourceService DataSource { get; set; }

        public CovidDataWorld Data { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Data = await DataSource.getWorldData();
            await base.OnInitializedAsync();
        }
    }
}