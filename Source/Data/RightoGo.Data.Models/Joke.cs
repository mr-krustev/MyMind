namespace RightoGo.Data.Models
{
    using RightoGo.Data.Common.Models;

    public class Joke : BaseModel<int>
    {
        public string Content { get; set; }

        public int CategoryId { get; set; }

        public virtual JokeCategory Category { get; set; }
    }
}
