namespace RightoGo.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using Common.Models;

    public class Topic : BaseModel<int>
    {
        [Required]
        public string Value { get; set; }
    }
}
