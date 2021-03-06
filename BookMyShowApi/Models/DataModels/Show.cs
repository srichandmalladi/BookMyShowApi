using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PetaPoco;

namespace BookMyShowApi.Models.DataModels
{
    [PetaPoco.TableName("Show")]
    public class Show
    {
        public int Id { get; set; }

        public int TheatreId { get; set; }

        public int MovieId { get; set; }

        public int Slot { get; set; }
    }
}
