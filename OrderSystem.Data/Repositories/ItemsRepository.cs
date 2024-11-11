using Dapper;
using Data.Interfaces;
using Entities.Dtos;
using Entities.Entities;
using Entities.Enums;
using System.Data.SqlClient;

namespace Data.Repositories
{
    public class ItemsRepository : IItemsRepository
    {
        public void Add(Item item, SqlConnection conn, SqlTransaction tran)
        {
            if (item is Product product)
            {
                var insertQuery = @"INSERT INTO Products (ProductName, Description, Stock, CostPrice, SalePrice, 
                        ReorderLevel, Suspended, Image, CategoryId) VALUES (@ProductName, @Description, @Stock,
                        @CostPrice, @SalePrice, @ReorderLevel, @Suspended, @Image, @CategoryId); 
                        SELECT CAST(SCOPE_IDENTITY() as int)";

                int primaryKey = conn.QuerySingle<int>(insertQuery, new
                {
                    ProductName = product.Name,
                    Description = product.Description,
                    Stock = product.Stock,
                    CostPrice = product.CostPrice,
                    SalePrice = product.SalePrice,
                    ReorderLevel = product.ReorderLevel,
                    Suspended = product.Suspended,
                    Image = product.Image,
                    CategoryId = product.CategoryId
                }, tran);

                if (primaryKey > 0)
                {
                    item.ItemId = primaryKey;
                    return;
                }
                throw new Exception("The product could not be added");

            }
            if (item is Combo combo)
            {
                var insertQuery = @"INSERT INTO Combos (ComboName, Description, Stock, CostPrice, SalePrice, 
                        ReorderLevel, Suspended, StartDate, EndDate, Size, Image) VALUES 
                        (@ComboName, @Description,  @Stock, @CostPrice, @SalePrice, 
                        @ReorderLevel, @Suspended, @StartDate, @EndDate, @Size, @Image); 
                        SELECT CAST(SCOPE_IDENTITY() as int)";

                int primaryKey = conn.QuerySingle<int>(insertQuery, new
                {
                    ComboName = combo.Name,
                    Description = combo.Description,
                    Stock = combo.Stock,
                    CostPrice = combo.CostPrice,
                    SalePrice = combo.SalePrice,
                    ReorderLevel = combo.ReorderLevel,
                    Suspended = combo.Suspended,
                    StartDate = combo.StartDate,
                    EndDate = combo.EndDate,
                    Size = combo.Size,
                    Image = combo.Image
                }, tran);

                if (primaryKey > 0)
                {
                    item.ItemId = primaryKey;
                    return;
                }
                throw new Exception("The combo could not be added");


            }
        }

        public void Delete(ItemType itemType, int itemId, SqlConnection conn, SqlTransaction tran)
        {
            if (itemType is ItemType.Product)
            {
                var deleteQuery = @"DELETE FROM Products WHERE ProductId=@ProductId";
                int recordsAffected = conn.Execute(deleteQuery, new { @ProductId = itemId }, tran);
                if (recordsAffected == 0)
                {
                    throw new Exception("The product could not be deleted");
                }

            }
            else
            {
                var deleteQuery = @"DELETE FROM Combos WHERE ComboId=@ComboId";
                int recordsAffected = conn.Execute(deleteQuery, new { @ComboId = itemId }, tran);
                if (recordsAffected == 0)
                {
                    throw new Exception("The combo could not be deleted");
                }

            }
        }

        public void Edit(Item item, SqlConnection conn, SqlTransaction tran)
        {
            if (item is Product product)
            {
                var updateQuery = @"UPDATE Products SET 
                    ProductName = @Name,
                    Description = @Description,
                    Stock = @Stock,
                    CostPrice = @CostPrice,
                    SalePrice = @SalePrice,
                    ReorderLevel = @ReorderLevel,
                    Suspended = @Suspended,
                    Image = @Image,
                    CategoryId = @CategoryId
                    WHERE ProductId=@ItemId";

                int recordsAffected = conn.Execute(updateQuery, new
                {
                    product.Name,
                    product.Description,
                    product.Stock,
                    product.CostPrice,
                    product.SalePrice,
                    product.ReorderLevel,
                    product.Suspended,
                    product.Image,
                    product.CategoryId,
                    product.ItemId
                }, tran);

                if (recordsAffected == 0)
                {
                    throw new Exception("The product could not be edited.");
                }

            }
            if (item is Combo combo)
            {
                var updateQuery = @"UPDATE Combos SET 
                    ComboName = @Name,
                    Description = @Description,
                    Stock = @Stock,
                    CostPrice = @CostPrice,
                    SalePrice = @SalePrice,
                    ReorderLevel = @ReorderLevel,
                    Suspended = @Suspended,
                    StartDate=@StartDate,
                    EndDate=@EndDate,
                    Size=@Size,
                    Image = @Image                         
                    WHERE ComboId = @ItemId";

                int recordsAffected = conn.Execute(updateQuery, new
                {
                    combo.Name,
                    combo.Description,
                    combo.Stock,
                    combo.CostPrice,
                    combo.SalePrice,
                    combo.ReorderLevel,
                    combo.Suspended,
                    combo.StartDate,
                    combo.EndDate,
                    combo.Size,
                    combo.Image,
                    combo.ItemId
                }, tran);

                if (recordsAffected == 0)
                {
                    throw new Exception("The combo could not be edited.");
                }
            }
        }

        public bool Exist(Item item, SqlConnection conn)
        {
            if (item is Product product)
            {
                var selectQuery = "SELECT COUNT(*) FROM Products WHERE ProductName = @Name";
                if (product.ItemId != 0)
                {
                    selectQuery += " AND ProductId<>@ItemId";
                }

                return conn.QuerySingle<int>(selectQuery, item) > 0;

            }
            else if (item is Combo combo)
            {
                var selectQuery = "SELECT COUNT(*) FROM Combos WHERE ComboName = @Name";
                if (combo.ItemId != 0)
                {
                    selectQuery += " AND ComboId<>@ItemId";
                }

                return conn.QuerySingle<int>(selectQuery, combo) > 0;

            }
            return false;
        }

        public int GetCount(SqlConnection conn, ItemType itemType, Func<ItemListDto, bool>? filter = null, SqlTransaction? tran = null)
        {
            var listItems = new List<ItemListDto>();
            if (itemType == ItemType.Product)
            {
                var selectQuery = @"SELECT ProductId as ItemId, ProductName as Name, Description, CostPrice, SalePrice,
                                    Stock, Suspended, ReorderLevel, Image, CategoryId
                                    FROM Products";
                var productList = conn.Query<ProductListDto>(selectQuery).ToList();
                listItems.AddRange(productList);

            }
            if (itemType == ItemType.Combo)
            {
                var selectQuery = @"SELECT c.ComboId AS ItemId, c.ComboName AS Name, (SELECT COUNT(*) 
                FROM ComboDetails cd WHERE cd.ComboId=c.ComboId) AS Variedades,
                (SELECT SUM(cd.Quantity) FROM ComboDetails cd WHERE cd.ComboId=c.ComboId) as CantidadCombos,
                c.CostPrice AS Precio,
                c.Stock,
                c.Suspended 
                FROM Combos c";
                var combosList = conn.Query<ComboListDto>(selectQuery).ToList();
                listItems.AddRange(combosList);

            }

            if (filter != null)
            {
                listItems = listItems.Where(filter).ToList();
            }
            return listItems.Count;
        }

        public Item? GetItemById(ItemType itemType, int itemId, SqlConnection conn)
        {
            if (itemType is ItemType.Product)
            {
                string selectQuery = @"SELECT 
                        ProductId AS ItemId, 
                        ProductName AS Name, 
                        Description, 
                        Stock, 
                        CostPrice, 
                        SalePrice, 
                        Suspended, 
                        Image, 
                        ReorderLevel, 
                        CategoryId 
                        FROM Products 
                        WHERE ProductId=@ProductId";

                return conn.QuerySingleOrDefault<Product>(selectQuery, new { @ProductId = itemId });

            }
            else if (itemType is ItemType.Combo)
            {
                string selectQuery = @"SELECT 
                           c.ComboId AS ItemId, 
                           c.ComboName AS Name, 
                           c.Description, 
                           c.CostPrice, 
                           c.SalePrice, 
                           c.Stock, 
                           c.ReorderLevel, 
                           c.Image, 
                           c.Suspended,
                           c.Size, 
                           c.StartDate, 
                           c.EndDate,
						   cd.ComboDetailId,
						   cd.ComboId,
						   cd.ProductId,
						   cd.Quantity,
						   p.ProductId As ItemId,
						   p.ProductName As Name
						   FROM Combos c
						   INNER JOIN ComboDetails cd ON c.ComboId=cd.ComboId
						   INNER JOIN Products p ON p.ProductId=cd.ProductId
						WHERE c.ComboId=@ComboId";
                var comboDictionary = new Dictionary<int, Combo>();
                //Ver cuando el combo no tenga detalles
                var result = conn.Query<Combo, ComboDetail, Product, Combo>(
                    selectQuery, (combo, detail, product) =>
                    {
                        if (!comboDictionary.TryGetValue(combo.ItemId, out var comboEntry))
                        {
                            comboEntry = combo;
                            comboEntry.Details = new List<ComboDetail>();
                            comboDictionary.Add(combo.ItemId, comboEntry);
                        };
                        detail.Product = product;
                        comboEntry.Details.Add(detail);
                        return comboEntry;


                    }, new { @ComboId = itemId },
                    splitOn: "ComboDetailId,ItemId");
                return comboDictionary.Values.FirstOrDefault();
            }
            return null;
        }

        public List<Item> GetItemList(SqlConnection conn, ItemType itemType)
        {
            var itemsList = new List<Item>();
            if (itemType is ItemType.Product)
            {

                var selectQuery = @"SELECT c.ProductId AS ItemId, c.ProductName AS Name, c.SalePrice, c.Stock
                                    FROM Products c 
                                    WHERE c.Suspended=0
                                    ORDER BY c.ProductName";
                var productList = conn.Query<Product>(selectQuery).ToList();
                itemsList.AddRange(productList);

            }
            if (itemType is ItemType.Combo)
            {

                var selectQuery = @"SELECT c.CajaId AS ProductoId, 
                                   c.NombreCaja AS Nombre,
                                c.PrecioVenta,
                                c.Stock
                            FROM Cajas c WHERE c.Suspendido=0
                            ORDER BY c.NombreCaja";
                var combosList = conn.Query<Combo>(selectQuery).ToList();
                itemsList.AddRange(combosList);

            }

            return itemsList;
        }

        public List<ItemListDto> GetList(SqlConnection conn, int currentPage, int pageSize, ItemType itemType, Func<ItemListDto, bool>? filter = null, SqlTransaction? tran = null)
        {
            var itemsList = new List<ItemListDto>();

            if (itemType == ItemType.Product)
            {
                var selectQuery = @"SELECT p.ProductId as ItemId, p.ProductName as Name, p.Description, p.CostPrice, p.SalePrice,
                                    p.Stock, p.Suspended, p.ReorderLevel, p.Image, c.CategoryName
                                    FROM Products p INNER JOIN Categories c on p.CategoryId=c.CategoryId ORDER BY p.ProductName";
                var productList = conn.Query<ProductListDto>(selectQuery).ToList();
                itemsList.AddRange(productList);

            }
            if (itemType == ItemType.Combo)
            {
                var selectQuery = @"SELECT c.ComboId as ItemId, c.ComboName as Name, c.Description, c.CostPrice, c.SalePrice,
                                    c.Stock, c.Suspended, c.ReorderLevel, c.Image, c.Size, c.StartDate, c.EndDate
                                    FROM Combos c";
                var combosList = conn.Query<ComboListDto>(selectQuery).ToList();
                itemsList.AddRange(combosList);

            }
            if (filter != null)
            {
                itemsList = itemsList.Where(filter).ToList();
            }
            return itemsList.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
        }

        public int GetPageByRecord(SqlConnection conn, ItemType itemType, string name, int pageSize)
        {
            string positionQuery = string.Empty;
            if (itemType is ItemType.Product)
            {
                positionQuery = @"
                        WITH ProductOrder AS (
                        SELECT 
                            ROW_NUMBER() OVER (ORDER BY ProductName) AS RowNum,
                            ProductName
                        FROM 
                            Products
                    )
                    SELECT 
                        RowNum 
                    FROM 
                        ProductOrder 
                    WHERE 
                        ProductName = @Name";

            }
            else
            {
                positionQuery = @"
                        WITH ComboOrder AS (
                        SELECT 
                            ROW_NUMBER() OVER (ORDER BY ComboName) AS RowNum,
                            ComboName
                        FROM 
                            Combos
                    )
                    SELECT 
                        RowNum 
                    FROM 
                        ComboOrder 
                    WHERE 
                        ComboName = @Name"
                ;
            }

            int position = conn.ExecuteScalar<int>(positionQuery, new { Name = name });
            return (int)Math.Ceiling((decimal)position / pageSize);
        }

        public bool IsRelated(ItemType itemType, int itemId, SqlConnection conn)
        {
            if (itemType is ItemType.Product)
            {
                var selectQuery = @"SELECT COUNT(*) FROM ComboDetails WHERE ProductId=@ProductId";
                return conn.QuerySingle<int>
                    (selectQuery, new { @ProductId = itemId }) > 0;

            }
            else if (itemType is ItemType.Combo)
            {
                var selectQuery = @"SELECT COUNT(*) FROM ComboDetails WHERE ComboId=@ComboId";
                return conn.QuerySingle<int>
                    (selectQuery, new { @ComboId = itemId }) > 0;

            }
            return false;
        }
    }
}
