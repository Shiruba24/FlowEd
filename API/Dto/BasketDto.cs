using Entity.Entities;

namespace API.Dto
{
    public class BasketDto
    {
        public string ClientId { get; set; } = string.Empty;
        public List<BasketItemDto> Items { get; set; }
    }
}
