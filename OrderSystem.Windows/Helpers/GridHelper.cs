using Entities.Dtos;
using Entities.Entities;
using Entities.ViewModels;

namespace Windows.Helpers
{
    public static class GridHelper
    {

        //public static void MostrarDatosEnGrilla<T>(List<T> lista, DataGridView grid)
        //{
        //    GridHelper.LimpiarGrilla(grid); // Limpia la grilla antes de llenarla

        //    if (lista is not null)
        //    {
        //        foreach (var item in lista)
        //        {
        //            var r = GridHelper.ConstruirFila(grid);

        //            // ¡AQUÍ ESTÁ EL CAMBIO CLAVE!
        //            // Verificamos si el 'item' es un ViewModel de tipo AddressWithTypeVM o PhonesWithTypeVM.
        //            // Si lo es, pasamos a SetearFila el objeto de entidad anidado (Address o Phone).
        //            // De lo contrario, pasamos el 'item' tal cual.
        //            if (item is AddressWithTypeVM addressVm)
        //            {
        //                // Pasamos la ENTIDAD Address al SetearFila
        //                // Asumo que tu Address.ToString() mostrará todo lo necesario.
        //                GridHelper.SetearFila(r, addressVm.Address);
        //            }
        //            else if (item is PhonesWithTypeVM phoneVm)
        //            {
        //                // Pasamos la ENTIDAD Phone al SetearFila
        //                // Asumo que tu Phone.ToString() mostrará todo lo necesario.
        //                GridHelper.SetearFila(r, phoneVm.Phone);
        //            }
        //            else
        //            {
        //                // Para todos los demás tipos (como CustomerListDto en la grilla principal,
        //                // o si en otros lugares pasas entidades directamente a MostrarDatosEnGrilla)
        //                // SetearFila(r, item); // Esto es lo que hacía antes
        //                GridHelper.SetearFila(r, item); // Pasamos el item tal cual (esto es para el caso CustomerListDto)
        //            }

        //            GridHelper.AgregarFila(r, grid); // Agrega la fila a la grilla
        //        }
        //    }
        //}
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
                    r.Cells[2].Value = saleDetails.Price;
                    r.Cells[3].Value = saleDetails.Quantity;
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
                    r.Cells[6].Value = address.City;
                    r.Cells[7].Value = address.StateProvince;
                    r.Cells[8].Value = address.Country;
                    r.Cells[9].Value = address.PostalCode;
                    break;
                case PhoneListDto phone:
                    r.Cells[0].Value = phone.PhoneId;
                    r.Cells[1].Value = phone.PhoneType;
                    r.Cells[2].Value = phone.PhoneNumber;
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
