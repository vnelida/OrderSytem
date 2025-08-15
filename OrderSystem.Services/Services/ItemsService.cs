using Data.Interfaces;
using Entities.Dtos;
using Entities.Entities;
using Entities.Enums;
using Services.Interfaces;
using System.Data.SqlClient;

namespace Services.Services
{
    public class ItemsService : IItemsService
    {
        private readonly IItemsRepository? _repository;
        private readonly IComboDetailsRepository? _repositoryComboDetails;
        private readonly string? _cadena;

        public ItemsService(IItemsRepository? repository, IComboDetailsRepository repositoryComboDetails, string? cadena)
        {
            _repository = repository ?? throw new ApplicationException("dependencies not loaded.");
            _repositoryComboDetails = repositoryComboDetails ?? throw new ApplicationException("Dependencies not loaded.");
            _cadena = cadena;

        }

        public void DeductStock(SaleDetail item, SqlConnection conn, SqlTransaction tran)
        {
            if (item.ProductId != null)
            {
                _repository.UpdateProductStock(item.ProductId.Value, -item.Quantity, conn, tran);
            }
            else if (item.ComboId != null)
            {
                _repository.UpdateComboStock(item.ComboId.Value, -item.Quantity, conn, tran);
            }
        }

        public void Delete(ItemType itemType, int itemId)
        {
            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                using (var tran = conn.BeginTransaction())
                {
                    try
                    {
                        if (itemType is ItemType.Combo)
                        {
                            _repositoryComboDetails!.Delete(itemId, conn, tran);
                        }
                        _repository!.Delete(itemType, itemId, conn, tran);

                        tran.Commit();
                    }
                    catch (Exception)
                    {
                        tran.Rollback();
                        throw;
                    }
                }
            }
        }

        public bool Exist(Item item)
        {
            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                return _repository!.Exist(item, conn);
            }
        }

        public int GetCount(ItemType itemType, Category? selectedCategory = null, Func<ItemListDto, bool>? filter = null)
        {
            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                return _repository!.GetCount(conn, itemType, selectedCategory, filter);
            }
        }

        public Item? GetItemById(ItemType itemType, int itemId)
        {
            using (var conn = new SqlConnection(_cadena))
            {
                return _repository!.GetItemById(itemType, itemId, conn);
            }
        }

        public List<Item> GetItemList(ItemType itemType)
        {
            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                return _repository!.GetItemList(conn, itemType);
            }
        }

        public List<ItemListDto> GetList(int currentPage, int pageSize, ItemType itemType, Order? order = Order.None, Category? selectedCategory = null, DateTime? currentDate = null)
        {
            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                return _repository!.GetList(conn, currentPage, pageSize, itemType, order, selectedCategory, currentDate);
            }
        }

        public int GetPageByRecord(ItemType itemType, string name, int pageSize)
        {
            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                return _repository!.GetPageByRecord(conn, itemType, name, pageSize);
            }
        }

        public bool IsRelated(ItemType itemType, int itemId)
        {
            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                return _repository!.IsRelated(itemType, itemId, conn);
            }
        }

        public void RevertStock(List<SaleDetail> saleDetails, SqlConnection conn, SqlTransaction tran)
        {
            foreach (var detail in saleDetails)
            {
                if (detail.ProductId != null)
                {
                    _repository.UpdateProductStock(detail.ProductId.Value, detail.Quantity, conn, tran);
                }
                else if (detail.ComboId != null)
                {
                    _repository.UpdateComboStock(detail.ComboId.Value, detail.Quantity, conn, tran);

                }
            }
        }

        public void Save(Item item)
        {
            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                using (var tran = conn.BeginTransaction())
                {
                    try
                    {
                        if (item.ItemId == 0)
                        {
                            _repository!.Add(item, conn, tran);
                            if (item is Combo combo)
                            {
                                foreach (var c in combo.Details)
                                {
                                    c.ComboId = combo.ItemId;
                                    _repositoryComboDetails!.Add(c, conn, tran);
                                }
                            }
                        }
                        else
                        {

                            _repository!.Edit(item, conn, tran);
                            if (item is Combo combo)
                            {
                                _repositoryComboDetails!.Delete(combo.ItemId, conn, tran);
                                foreach (var c in combo.Details)
                                {
                                    c.ComboId = combo.ItemId;
                                    _repositoryComboDetails.Add(c, conn, tran);
                                }

                            }
                        }

                        tran.Commit();
                    }
                    catch (Exception)
                    {
                        tran.Rollback();
                        throw;
                    }
                }
            }
        }

    }
}
