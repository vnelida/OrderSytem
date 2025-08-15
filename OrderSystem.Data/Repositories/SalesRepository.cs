using Dapper;
using Data.Interfaces;
using Entities.Dtos;
using Entities.Entities;
using Entities.Enums;
using System.Data.SqlClient;
using System.Text;

namespace Data.Repositories
{
    public class SalesRepository : ISalesRepository
    {
      
        public void Add(Sale sale, SqlConnection conn, SqlTransaction tran)
        {
            string insertQuery = @"INSERT INTO Sales 
                (CustomerId, SaleDate, TotalAmount, OrderStatusId, OrderTypeId ) 
                VALUES (@CustomerId, @SaleDate, @TotalAmount, @OrderStatusId, @OrderTypeId); 
                SELECT CAST(SCOPE_IDENTITY() as int)";

            int primaryKey = conn.QuerySingle<int>(insertQuery, sale, tran);
            if (primaryKey > 0)
            {
                sale.SaleId = primaryKey;
                return;
            }
            throw new Exception("Sale could not be added");
        }

        public void Edit(Sale sale, SqlConnection conn, SqlTransaction tran)
        {
            string updateQuery = @"UPDATE Sales 
                                   SET OrderStatusId = @OrderStatusId
                                   WHERE SaleId = @SaleId";

            int affectedRows = conn.Execute(updateQuery, sale, tran);

            if (affectedRows == 0)
            {
                throw new Exception("Sale could not be updated.");
            }
        }

        public int GetCaount(SqlConnection conn, Func<SalesListDto, bool>? filter)
        {
            var selectQuery = @"SELECT
                                v.SaleId,
                                COALESCE(v.CustomerId, 999999) AS CustomerId,
                                v.SaleDate,
                                v.TotalAmount,
                                v.OrderTypeId,      
                                ot.TypeName AS OrderType, 
                                v.OrderStatusId,    
                                os.StatusName AS OrderStatus,
                                COALESCE(c.FirstName + ' ' + c.LastName, 'Consumidor Final') AS CustomerName
                            FROM
                                Sales AS v
                            LEFT JOIN
                                Customers AS c ON v.CustomerId = c.CustomerId
                            LEFT JOIN
                                OrderTypes AS ot ON v.OrderTypeId = ot.OrderTypeId   
                            LEFT JOIN
                                OrderStatuses AS os ON v.OrderStatusId = os.OrderStatusId 
                            ORDER BY
                                v.SaleId";
            var listaVentas = conn.Query<SalesListDto>(selectQuery).ToList();
            if (filter is not null)
            {
                listaVentas.Where(filter).ToList();
            }
            return listaVentas.Count;
        }

        public List<SalesListDto> GetList(SqlConnection conn, int currentPage, int pageSize, Func<SalesListDto, bool>? filter = null, SqlTransaction? tran = null)
        {
            var listaVentas = new List<SalesListDto>();
            string selectQuery = @"SELECT
                                    v.SaleId,
                                    COALESCE(v.CustomerId, 999999) AS CustomerId,
                                    v.SaleDate,
                                    v.TotalAmount,
                                    v.OrderTypeId,
                                    ot.TypeName AS OrderType,
                                    v.OrderStatusId,
                                    os.StatusName AS OrderStatus,
                                    COALESCE(c.FirstName + ' ' + c.LastName, 'Consumidor Final') AS Customer
                                FROM
                                    Sales AS v
                                LEFT JOIN
                                    Customers AS c ON v.CustomerId = c.CustomerId
                                LEFT JOIN
                                    OrderTypes AS ot ON v.OrderTypeId = ot.OrderTypeId
                                LEFT JOIN
                                    OrderStatuses AS os ON v.OrderStatusId = os.OrderStatusId
                                ORDER BY
                                    v.SaleId";
            listaVentas = conn.Query<SalesListDto>(selectQuery).ToList();
            if (filter != null)
            {
                listaVentas = listaVentas.Where(filter).ToList();
            }
            return listaVentas.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
        }

        public Sale? GetSaleById(SqlConnection conn, int saleId, SqlTransaction? tran = null)
        {
            var selectQuery = @"
                                SELECT
                            v.SaleId,
	                        COALESCE(v.CustomerId,999999) AS CustomerId,
                            v.SaleDate,
                            v.TotalAmount,

                            COALESCE(v.CustomerId,999999) AS CustomerId,
				            COALESCE(c.FirstName,'Consumidor') as FirstName,
				            COALESCE(c.LastName,'Final') as LastName,

                            dv.SaleDetailId, 
                            dv.SaleId,
                            dv.ProductId, 
                            dv.ComboId,  
                            dv.Quantity,
                            dv.Price,

                            p.ProductId, 
                            p.ProductName AS Name,

                            co.ComboId,
                            co.ComboName as Name,

                            ot.OrderTypeId, 
                            ot.TypeName AS TypeName,

                            os.OrderStatusId,
                            os.StatusName AS StatusName

                        FROM Sales v
                        LEFT JOIN Customers c ON v.CustomerId = c.CustomerId
                        INNER JOIN SaleDetails dv ON v.SaleId = dv.SaleId
                        LEFT JOIN Products p ON dv.ProductId = p.ProductId 
                        LEFT JOIN Combos co ON dv.ComboId = co.ComboId      
                        LEFT JOIN OrderTypes ot ON v.OrderTypeId = ot.OrderTypeId
                        LEFT JOIN OrderStatuses os ON v.OrderStatusId = os.OrderStatusId
                        WHERE v.SaleId = @SaleId";

            var salesDictionary = new Dictionary<int, Sale>();

            var result = conn.Query<Sale, Customer, SaleDetail, Product, Combo, OrderType, OrderStatus, Sale>(
                selectQuery,
                (sale, customer, saleDetail, product, combo, orderType, orderStatus) =>
                {
                    if (!salesDictionary.TryGetValue(sale.SaleId, out var saleEntry))
                    {
                        saleEntry = sale;
                        saleEntry.Customer = customer;
                        saleEntry.OrderType = orderType;
                        saleEntry.OrderStatus = orderStatus;
                        saleEntry.Details = new List<SaleDetail>();
                        salesDictionary.Add(sale.SaleId, saleEntry);
                    }

                    if (saleDetail != null)
                    {
                        if (saleDetail.ProductId.HasValue && product != null)
                        {
                            saleDetail.Product = product;
                        }
                        else if (saleDetail.ComboId.HasValue && combo != null)
                        {
                            saleDetail.Combo = combo;
                        }
                        saleEntry.Details.Add(saleDetail);
                    }

                    return saleEntry;
                },
                new { SaleId = saleId },
                splitOn: "CustomerId,SaleDetailId,ProductId,ComboId,OrderTypeId,OrderStatusId",
                transaction: tran
            ).ToList();

            return salesDictionary.Values.FirstOrDefault();
        }

        public List<SaleDetail> GetSaleDetailsBySaleId(int saleId, SqlConnection conn, SqlTransaction tran)
        {
            var sql = @"SELECT
                                sd.SaleDetailId, sd.SaleId, sd.ProductId, sd.ComboId, sd.Quantity, sd.Price,
                                p.ProductId AS ItemId, p.ProductName AS Name, p.Stock, -- Alias para mapear a la clase base Item
                                c.ComboId AS ItemId, c.ComboName AS Name, c.CostPrice, c.SalePrice, c.Stock, c.Size, c.StartDate, c.EndDate -- <<<--- Columnas agregadas
                            FROM SaleDetails sd
                            LEFT JOIN Products p ON sd.ProductId = p.ProductId
                            LEFT JOIN Combos c ON sd.ComboId = c.ComboId
                            WHERE sd.SaleId = @SaleId;
                        ";

            var saleDetails = conn.Query<SaleDetail, Product, Combo, SaleDetail>(
                sql,
                (saleDetail, product, combo) =>
                {
                    saleDetail.Product = product;
                    saleDetail.Combo = combo;
                    return saleDetail;
                },
                param: new { SaleId = saleId },
                transaction: tran,
                splitOn: "ItemId, ItemId"
            ).ToList();

            return saleDetails;
        }

        public List<SalesListDto> GetSalesListt(SqlConnection conn, int currentPage, int pageSize, OrderTypes? orderType = null, OrderStatuses? status = null, Order? order = null, SqlTransaction? tran = null)
        {
            var selectQuery = new StringBuilder(@"
                                        SELECT
                                        v.SaleId,
                                        COALESCE(v.CustomerId, 999999) AS CustomerId,
                                        v.SaleDate,
                                        v.TotalAmount,
                                        v.OrderTypeId,
                                        ot.TypeName AS OrderType,
                                        v.OrderStatusId,
                                        os.StatusName AS OrderStatus,
                                        COALESCE(c.FirstName + ' ' + c.LastName, 'Consumidor Final') AS Customer
                                    FROM
                                        Sales AS v
                                    LEFT JOIN
                                        Customers AS c ON v.CustomerId = c.CustomerId
                                    LEFT JOIN
                                        OrderTypes AS ot ON v.OrderTypeId = ot.OrderTypeId
                                    LEFT JOIN
                                        OrderStatuses AS os ON v.OrderStatusId = os.OrderStatusId");

            var parameters = new DynamicParameters();
            var conditions = new List<string>();

            if (orderType.HasValue && orderType.Value != OrderTypes.None)
            {
                conditions.Add("v.OrderTypeId = @OrderTypeId");
                parameters.Add("OrderTypeId", (int)orderType.Value);
            }

            if (status.HasValue && status.Value != OrderStatuses.None)
            {
                conditions.Add("v.OrderStatusId = @OrderStatusId");
                parameters.Add("OrderStatusId", (int)status.Value);
            }

            if (conditions.Any())
            {
                selectQuery.Append(" WHERE " + string.Join(" AND ", conditions));
            }

            var orderBy = " ORDER BY v.SaleId "; 
            switch (order)
            {
                case Order.None:
                    break;
                case Order.CustomerName:
                    orderBy = " ORDER BY c.Customer ASC ";
                    break;
                case Order.CustomerNameDesc:
                    orderBy = " ORDER BY c.Customer DESC ";
                    break;
                case Order.SaleDate:
                    orderBy = " ORDER BY v.SaleDate ASC ";
                    break;
                case Order.SaleDateDesc:
                    orderBy = " ORDER BY v.SaleDate DESC ";
                    break;
                case Order.Total:
                    orderBy = " ORDER BY v.TotalAmount ASC ";
                    break;
                case Order.TotalDesc:
                    orderBy = " ORDER BY v.TotalAmount DESC ";
                    break;
                default:
                    break;
            }
            selectQuery.Append(orderBy);

            selectQuery.Append(" OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY");
            parameters.Add("Offset", (currentPage - 1) * pageSize);
            parameters.Add("PageSize", pageSize);

            return conn.Query<SalesListDto>(selectQuery.ToString(), parameters, tran).ToList();
        }

        public int GetSalesCountt(SqlConnection conn, OrderTypes? orderType = null, OrderStatuses? status = null, SqlTransaction? tran = null)
        {
            var selectQuery = new StringBuilder(@"
            SELECT COUNT(*) FROM Sales AS v
            -- ... (tus LEFT JOINs)
        ");

            var parameters = new DynamicParameters();
            var conditions = new List<string>();

            if (orderType.HasValue && orderType.Value != OrderTypes.None)
            {
                conditions.Add("v.OrderTypeId = @OrderTypeId");
                parameters.Add("OrderTypeId", (int)orderType.Value);
            }

            if (status.HasValue && status.Value != OrderStatuses.None)
            {
                conditions.Add("v.OrderStatusId = @OrderStatusId");
                parameters.Add("OrderStatusId", (int)status.Value);
            }

            if (conditions.Any())
            {
                selectQuery.Append(" WHERE " + string.Join(" AND ", conditions));
            }

            return conn.QuerySingle<int>(selectQuery.ToString(), parameters, tran);
        }

        public void UpdateSaleStatus(int saleId, int statusId, SqlConnection conn, SqlTransaction tran)
        {
            var sql = "UPDATE Sales SET OrderStatusId = @StatusId WHERE SaleId = @SaleId;";
            conn.Execute(sql, new { SaleId = saleId, StatusId = statusId }, transaction: tran);

        }
    }
}
