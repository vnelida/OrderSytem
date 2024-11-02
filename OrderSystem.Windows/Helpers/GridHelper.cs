using Entities.Dtos;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    r.Cells[0].Value = category.CategoryName;
                    break;
                case Employee employee:
                    r.Cells[0].Value = employee.FirstName;
                    r.Cells[1].Value = employee.LastName;
                    r.Cells[2].Value = employee.Phone;
                    r.Cells[3].Value = employee.Email;
                    r.Cells[4].Value = employee.Address;
                    break;
                case ProductDto product:
                    r.Cells[0].Value = product.ProductName;
                    r.Cells[1].Value = product.Description;
                    r.Cells[2].Value = product.Price;
                    r.Cells[3].Value = product.Stock;
                    r.Cells[4].Value = product.CategoryName;
                    r.Cells[5].Value = product.ProductId;
                    break;
                default:
                    break;
            }

            r.Tag = obj;
        }

        public static void AgregarFila(DataGridViewRow r,
            DataGridView grid)
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
                if ((int)row.Cells[5].Value == id)
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
