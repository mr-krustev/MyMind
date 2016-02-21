namespace RightoGo.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using Common.Models;

    public class Video : BaseModel<int>
    {
        [Required]
        public string Url { get; set; }
    }
}