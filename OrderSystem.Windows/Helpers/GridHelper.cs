using Entities.Dtos;
using Entities.Entities;

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
