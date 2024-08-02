
namespace OrderDeliverySystem.Catalog.Application.CatalogItems.GetAllCatalogItemByWeek
{
    public class CatalogItemsByWeekDto
    {
        public DateTime WeekStart { get; set; }
        public DateTime WeekEnd { get; set; }
        public List<CatalogItemDto> CatalogItems { get; set; } = new();
    }
}
