using Dapper;
using Data.Interfaces;
using Entities.Dtos;
using Entities.Entities;
using System.Data.SqlClient;

namespace Data.Repositories
{
    public class SalesRepository : ISalesRepository
    {
        public void Add(Sale sale, SqlConnection conn, SqlTransaction tran)
        {
            string insertQuery = @"INSERT INTO Sales 
                (CustomerId, SaleDate, IsGift, TotalAmount, Status ) 
                VALUES (@CustomerId, @SaleDate, @IfGift, @TotalAmount, @Status); 
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
            throw new NotImplementedException();
        }

        public int GetCaount(SqlConnection conn, Func<SalesListDto, bool>? filter)
        {
            var selectQuery = @"SELECT
				v.SaleId,
				COALESCE(v.CustomerId,999999) AS CustomerId,
				v.SaleDate,
				v.IsGift,
				v.TotalAmount,
				COALESCE(c.FirstName+' '+c.LastName,'Consumidor Final') as Customer
	
				FROM Sales v LEFT JOIN Customers c ON v.CustomerId=c.CustomerId
				ORDER BY v.SaleId";
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
				COALESCE(v.CustomerId,999999) AS CustomerId,
				v.SaleDate,
				v.IsGift,
				v.TotalAmount,
				v.Status,
				COALESCE(c.FirstName+' '+c.LastName,'Consumidor Final') as Customer
	
				FROM Sales v LEFT JOIN Customers c ON v.CustomerId=c.CustomerId
				ORDER BY v.SaleId";
            listaVentas = conn.Query<SalesListDto>(selectQuery).ToList();
            if (filter != null)
            {
                listaVentas = listaVentas.Where(filter).ToList();
            }
            return listaVentas.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
        }

        public Sale? GetSaleById(SqlConnection conn, int saleId, SqlTransaction? tran = null)
        {
            var selectQuery = @"SELECT
				v.SaleId,
				COALESCE(v.CustomerId,999999) AS CustomerId,
				v.SaleDate,
				v.IsGift,
				v.TotalAmount,
				v.Status,
				COALESCE(v.CustomerId,999999) AS CustomerId,
				COALESCE(c.FirstName,'Consumidor') as FirstName,
				COALESCE(c.LastName,'Final') as LastName,
				dv.SaleDetailsId,
				dv.SaleId,
				dv.ProductId,
				dv.ComboId,
				dv.Quantity,
				dv.Price,
				b.ProductId,
				b.ProductName AS Name,
				ca.ComboId,
				ca.ComboName As Name
				FROM Sales v LEFT JOIN Customers c ON v.CustomerId=c.CustomerId
				INNER JOIN SaleDetails dv ON v.SaleId=dv.SaleId
				LEFT JOIN Products b ON dv.ProductId=b.ProductId
				LEFT JOIN Combos ca ON dv.ComboId=ca.ComboId
				WHERE v.SaleId=@SaleId";
            var ventasDictionary = new Dictionary<int, Sale>();
            var resultado = conn.Query<Sale, Customer, SaleDetails, Product, Combo, Sale>(selectQuery,
                (sale, customer, details, product, combo) =>
                {
                    if (!ventasDictionary.TryGetValue(sale.SaleId, out var ventaEntry))
                    {
                        ventaEntry = sale;
                        sale.Customer = customer;
                        sale.Details = new List<SaleDetails>();
                        ventasDictionary.Add(sale.SaleId, ventaEntry);
                    }
                    details.Product = product;
                    details.Combo = combo;
                    ventaEntry.Details.Add(details);
                    return ventaEntry;

                },
                    new { @SaleId = saleId },
                    splitOn: "CustomerId,SaleDetailsId,ProductId,ComboId"
                ).FirstOrDefault();

            return ventasDictionary.Values.FirstOrDefault();
        }
    }
}
