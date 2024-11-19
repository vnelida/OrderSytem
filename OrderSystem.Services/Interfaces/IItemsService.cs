using Entities.Dtos;
using Entities.Entities;
using Entities.Enums;

namespace Services.Interfaces
{
    public interface IItemsService
    {
        void Delete(ItemType itemType, int itemId);
        bool IsRelated(ItemType itemType, int itemId);
        bool Exist(Item item);
        Item? GetItemById(ItemType itemType, int itemId);
        int GetCount(ItemType itemType, Category? selectedCategory = null, Func<ItemListDto, bool>? filter = null);
        List<ItemListDto> GetList(int currentPage, int pageSize, ItemType itemType, Order? order = Order.None, Category? selectedCategory = null, DateTime? currentDate=null);
        int GetPageByRecord(ItemType itemType, string name, int pageSize);
        void Save(Item item);
        List<Item> GetItemList(ItemType itemType);

    }
}
