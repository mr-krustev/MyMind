namespace RightoGo.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using Common.Models;

    public class University : BaseModel<int>
    {
        [Required]
        public string Name { get; set; }
    }
}
