using Entities.Dtos;
using Entities.Entities;
using Entities.ViewModels;

namespace Windows.Helpers
{
    public static class GridHelper
    {
        public static void MostrarDatosEnGrilla<T>(List<T> lista, DataGridView dgv) where T : class
        {
            LimpiarGrilla(dgv);
            foreach (var item in lista)
            {
                var r = ConstruirFila(dgv);
                SetearFila(r, item);
                AgregarFila(r, dgv);
            }
        }
        public static void LimpiarGrilla(DataGridView grid)
        {
            grid.Rows.Clear();
        }
        public static DataGridViewRow ConstruirFila(DataGridView grid)
        {
            var r = new DataGridViewRow();
            r.CreateCells(grid);
            return r;
        }

        public static void SetearFila(DataGridViewRow r, object obj)
        {
            Phone? debugPhone = obj as Phone;
            switch (obj)
            {
                case AddressWithTypeVM addressWithType:
                    r.Cells[0].Value = addressWithType.AddressId;          
                    r.Cells[1].Value = addressWithType.AddressTypeDescription; 
                    r.Cells[2].Value = addressWithType.Street;
                    r.Cells[3].Value = addressWithType.BuildingNumber;
                    r.Cells[4].Value = addressWithType.CityName;
                    r.Cells[5].Value = addressWithType.PostalCode;
                    r.Cells[6].Value = addressWithType.StateProvinceName;
                    r.Cells[7].Value = addressWithType.CountryName;
                    break;
                case PhonesWithTypeVM phonesWithType:
                    r.Cells[0].Value = phonesWithType.PhoneId;          
                    r.Cells[1].Value = phonesWithType.PhoneTypeDescription;
                    r.Cells[2].Value = phonesWithType.PhoneNumber;                   
                    break;
                case Category category:
                    r.Cells[0].Value = category.CategoryId;
                    r.Cells[1].Value = category.CategoryName;
                    break;
                case EmployeeListDto employee:
                    r.Cells[0].Value = employee.EmployeeId;
                    r.Cells[1].Value = employee.FirstName;
                    r.Cells[2].Value = employee.LastName;
                    r.Cells[3].Value = employee.Phone;
                    r.Cells[4].Value = employee.Email;
                    r.Cells[5].Value = employee.Address;
                    r.Cells[6].Value = employee.Dni;
                    r.Cells[7].Value = employee.DateOfBirth.ToShortDateString();
                    r.Cells[8].Value = employee.GenreName;
                    break;
                case ProductListDto product: 
                    r.Cells[0].Value = product.ItemId;
                    r.Cells[1].Value = product.Name;
                    r.Cells[2].Value = product.Description;
                    r.Cells[3].Value = product.CategoryName;
                    r.Cells[4].Value = product.CostPrice;
                    r.Cells[5].Value = product.SalePrice;
                    r.Cells[6].Value = product.Stock;
                    r.Cells[7].Value = product.ReorderLevel;
                    r.Cells[8].Value = product.Suspended;
                    break;
                case ComboListDto combo:
                    r.Cells[0].Value = combo.ItemId;
                    r.Cells[1].Value = combo.Name;
                    r.Cells[2].Value = combo.Description;
                    r.Cells[3].Value = combo.CostPrice;
                    r.Cells[4].Value = combo.SalePrice;
                    r.Cells[5].Value = combo.Stock;
                    r.Cells[6].Value = combo.ReorderLevel;
                    r.Cells[7].Value = combo.Suspended;
                    r.Cells[8].Value = combo.StartDate.ToShortDateString();
                    r.Cells[9].Value = combo.EndDate.ToShortDateString();
                    r.Cells[10].Value = combo.Size;

                    break;
                case ComboDetail detail:
                    r.Cells[0].Value = detail.ComboDetailId;
                    r.Cells[1].Value = detail.Product!.Name;
                    r.Cells[2].Value = detail.Quantity;
                    break;
                case Genre genre:
                    r.Cells[0].Value = genre.GenreId;
                    r.Cells[1].Value = genre.GenreName;
                    break;
                case CustomerListDto customer:
                    r.Cells[0].Value = customer.CustomerId;
                    r.Cells[1].Value = customer.DocumentNumber;
                    r.Cells[2].Value = customer.FullName;
                    r.Cells[3].Value = customer.PrincipalAddress;
                    r.Cells[4].Value = customer.PrincipalPhone;
                    break;
                case SalesListDto sale:
                    r.Cells[0].Value = sale.SaleId;
                    r.Cells[1].Value = sale.Customer;
                    r.Cells[2].Value = sale.SaleDate.ToShortDateString();
                    r.Cells[3].Value = sale.OrderStatus;
                    r.Cells[4].Value = sale.OrderType;
                    r.Cells[5].Value = sale.TotalAmount;
                    break;
                case SaleDetail saleDetails:
                    r.Cells[0].Value = saleDetails.SaleId;
                    r.Cells[1].Value = saleDetails.ProductId is null ? saleDetails.Combo!.Name : saleDetails.Product!.Name;
                    r.Cells[2].Value = saleDetails.Quantity; 
                    r.Cells[3].Value = saleDetails.Price;
                    r.Cells[4].Value = saleDetails.Quantity * saleDetails.Price;
                    break;
                case Address address:
                    r.Cells[0].Value = address.AddressId;
                    r.Cells[1].Value = address.ToString();
                    break;
                case Phone phone:
                    r.Cells[0].Value = phone.PhoneId;
                    r.Cells[1].Value = phone.ToString();
                    break;
                case AddressListDto address:
                    r.Cells[0].Value = address.AddressId;
                    r.Cells[1].Value = address.AddressType;
                    r.Cells[2].Value = address.Street;
                    r.Cells[3].Value = address.BuildingNumber;
                    r.Cells[4].Value = address.BetweenStreet1;
                    r.Cells[5].Value = address.BetweenStreet2;
                    r.Cells[6].Value = address.PostalCode;
                    r.Cells[7].Value = address.City;
                    r.Cells[8].Value = address.StateProvince;
                    r.Cells[9].Value = address.Country;
                    
                    break;
                case PhoneListDto phone:
                    r.Cells[0].Value = phone.PhoneId;
                    r.Cells[1].Value = phone.PhoneType;
                    r.Cells[2].Value = phone.PhoneNumber;
                    break;
                case Permission permission:
                    r.Cells[0].Value = permission.PermissionId;
                    r.Cells[1].Value = permission.Menu;
                    break;
                case UserListDto userDto:
                    r.Cells[0].Value = userDto.UserId;
                    r.Cells[1].Value = userDto.UserName;
                    r.Cells[2].Value = userDto.RoleName;
                    r.Cells[3].Value = userDto.IsActive;
                    break;
                case PaymentReportDto report:
                    r.Cells[0].Value = report.SaleId;
                    r.Cells[1].Value = report.SaleDate;
                    r.Cells[2].Value = report.CashAmount;
                    r.Cells[3].Value = report.CardAmount;
                    r.Cells[4].Value = report.CouponAmount;
                    r.Cells[5].Value = report.TransferAmount;
                    break;
                default:
                    break;
            }

            r.Tag = obj;
        }

        public static void AgregarFila(DataGridViewRow r, DataGridView grid)
        {
            grid.Rows.Add(r);
        }
        public static void QuitarFila(DataGridViewRow r,
            DataGridView grid)
        {
            grid.Rows.Remove(r);
        }

        public static int ObtenerRowIndex(DataGridView dgv, int id)
        {
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                var row = dgv.Rows[i];
                if ((int)row.Cells[0].Value == id)
                {
                    return i;
                }
            }
            return -1;

        }

        public static void MarcarRow(DataGridView dgv, int rowIndex)
        {
            if (rowIndex >= 0)
            {
                dgv.Rows[rowIndex].Selected = true;
                dgv.FirstDisplayedScrollingRowIndex = rowIndex;
            }

        }
    }
}
