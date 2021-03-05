using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookMyShowApi.Services
{
    public interface IDataBaseContext
    {
        PetaPoco.Database getDataBase();
    }
}
