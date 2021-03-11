using PetaPoco;

namespace BookMyShowApi.Models.Data
{
    [TableName("Show")]
    public class Show
    {
        public int Id { get; set; }

        public int TheatreId { get; set; }

        public int MovieId { get; set; }

        public int Slot { get; set; }
    }
}
