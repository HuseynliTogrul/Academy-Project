
namespace Academy.Core.Models.BaseModels
{
    public abstract class BaseModel
    {
        public string Id { get; set; }
        public DateTime CreatAt { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}
