using Entities.Dtos;
using Entities.Entities;
using Entities.Enums;
using System.Data.SqlClient;

namespace Data.Interfaces
{
    public interface IItemsRepository
    {
        List<ItemListDto> GetList(SqlConnection conn, int currentPage, int pageSize, ItemType itemType, Order? order = Order.None, Category? selectedCategory = null, DateTime? currentDate = null, SqlTransaction? tran = null);
        int GetCount(SqlConnection conn, ItemType itemType, Category? selectedCategory = null, Func<ItemListDto, bool>? filter = null, SqlTransaction? tran = null);
        void Delete(ItemType itemType, int itemId, SqlConnection conn, SqlTransaction tran);
        bool IsRelated(ItemType itemType, int itemId, SqlConnection conn);
        bool Exist(Item item, SqlConnection conn);
        Item? GetItemById(ItemType itemType, int itemId, SqlConnection conn);
        int GetPageByRecord(SqlConnection conn, ItemType itemType, string name, int pageSize);
        void Add(Item item, SqlConnection conn, SqlTransaction tran);
        void Edit(Item item, SqlConnection conn, SqlTransaction tran);
        List<Item> GetItemList(SqlConnection conn, ItemType itemType);

    }
}
