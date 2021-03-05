using BookMyShowApi.Models;
using BookMyShowApi.Services;
using Microsoft.Extensions.Options;

namespace BookMyShowApi.Data
{
    public class DataBaseContext : IDataBaseContext
    { 
        private readonly AppSettings _appSettings;
        PetaPoco.Database _dataContext;

        public DataBaseContext(IOptions<AppSettings> appSettings)
        { 
            this._appSettings = appSettings.Value;
            this._dataContext = new PetaPoco.Database(_appSettings.Bookmyshow, "System.Data.SqlClient");
        }
        public PetaPoco.Database getDataBase()
        {
            return _dataContext;
        }
    }
}
