using System.Threading.Tasks;
using Covid19Data.Models;

namespace Covid19Data.Services
{
    public interface IDataSourceService
    {
        Task<CovidDataFioCruz> getFioCruzData();

        Task<CovidDataWorld> getWorldData();
    }
}