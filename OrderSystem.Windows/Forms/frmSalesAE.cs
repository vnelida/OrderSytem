using Entities.Entities;
using Entities.Enums;
using Microsoft.Extensions.DependencyInjection;
using Services.Interfaces;
using System.Text;
using Windows.Helpers;
using Windows.UsersControl;

namespace Windows.Forms
{
    public partial class frmSalesAE : Form
    {
        private readonly IItemsService? _itemService;
        private readonly IServiceProvider _serviceProvider;
        private List<Item>? items;
        private ItemType itemType = ItemType.Combo;

        private Sale? sale;
        public frmSalesAE(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            _itemService = _serviceProvider.GetService<IItemsService>();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            CombosHelper.LoadOrderStatusComboBx(ref cboOrderStatus, _serviceProvider);
            CombosHelper.LoadOrderTypesComboBx(ref cboOrderType, _serviceProvider);
        }
        private void frmSalesAE_Load(object sender, EventArgs e)
        {
            sale = new Sale();
            RecargarGrilla();
        }
        private void RecargarGrilla()
        {
            items = _itemService!.GetItemList(itemType);
            flp.Controls.Clear();
            foreach (var item in items)
            {
                ucItem ucItem = new ucItem();
                SetearUcControl(ucItem, item);
                AgregarUcControl(ucItem);
            }
        }

        private void SetearUcControl(ucItem ucItem, Item item)
        {
            ucItem.ItemId = item.ItemId;
            ucItem.Name = item.Name;
            ucItem.ItemPrice = item.SalePrice;
            ucItem.ItemImage = item.Image;




            ucItem.btnOk.Tag = item;

            ucItem.btnOk.Click += BtnAdd_Click;
        }

        private void BtnAdd_Click(object? sender, EventArgs e)
        {
            if (sender is not null)
            {
                Button button = (Button)sender;
                Item item = (Item)button.Tag!;
                int? quantitySale = GetSaleQuantity(1);
                if (quantitySale is null) return;

                var itemInOrder = _itemService!.GetItemById(itemType, item.ItemId);

                var quantityAlreadyInCart = sale!.Details
                    .Where(sd => (itemType == ItemType.Product && sd.ProductId == itemInOrder.ItemId) ||
                                 (itemType == ItemType.Combo && sd.ComboId == itemInOrder.ItemId))
                    .Sum(sd => sd.Quantity);

                var availableStock = itemInOrder.Stock - quantityAlreadyInCart;

                if (quantitySale.Value <= availableStock)
                {
                    SaleDetail detail = new SaleDetail
                    {
                        ProductId = itemInOrder is Product ? itemInOrder.ItemId : null,
                        ComboId = itemInOrder is Combo ? itemInOrder.ItemId : null,
                        Product = itemInOrder is Product product ? product : null,
                        Combo = itemInOrder is Combo combo ? combo : null,
                        Price = itemInOrder.SalePrice,
                        Quantity = quantitySale.Value
                    };

                    sale!.Add(detail);

                    GridHelper.MostrarDatosEnGrilla<SaleDetail>(sale.Details, dgv);
                    MostrarTotales();
                }
                else
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("Insufficient stock." + Environment.NewLine);
                    sb.AppendFormat($"Available stock: {availableStock}");
                    MessageBox.Show(sb.ToString(), "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private int? GetSaleQuantity(int cantidadDefault)
        {
            while (true)
            {
                var stringCantidad = Microsoft.VisualBasic.Interaction.InputBox("Quantity",
                        "Quantity", cantidadDefault.ToString());
                if (stringCantidad == null || stringCantidad == string.Empty) return null;
                if (!int.TryParse(stringCantidad, out int cantidad) || (cantidad <= 0))
                {
                    MessageBox.Show("Invalid quantity", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    return cantidad;
                }

            }
        }

        private void MostrarTotales()
        {
            lblTotal.Text = sale!.GetTotal().ToString();
            lblCantidad.Text = sale!.GetQuantity().ToString();
        }

        private void AgregarUcControl(ucItem ucItem)
        {
            flp.Controls.Add(ucItem);
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (sale.GetQuantity() == 0)
            {
                valido = false;
                errorProvider1.SetError(dgv, "You must enter at least one item.");
            }
            if (cboOrderType.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(cboOrderType, "You must select an order type.");
            }

            if (cboOrderStatus.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(cboOrderStatus, "You must select an order status.");
            }
            return valido;
        }

        private void CancelarCompra()
        {
        }


        public Sale? GetSale()
        {
            return sale;
        }

        private void dgvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                var filaSeleccionada = e.RowIndex;
                var r = dgv.Rows[filaSeleccionada];
                SaleDetail dt = (SaleDetail)r.Tag!;
                DialogResult dr = MessageBox.Show("Remove selected item?",
                    "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (dr == DialogResult.No) return;

                var itemType = dt.ProductId is null ? ItemType.Combo : ItemType.Product;
                var itemId = dt.ProductId ?? dt.ComboId;
                var itemInOrder = _itemService!.GetItemById(itemType, itemId!.Value);
                itemInOrder!.OnOrderQuantity -= dt.Quantity;
                _itemService.Save(itemInOrder);

                sale.Delete(dt);
                GridHelper.QuitarFila(r, dgv);
                MostrarTotales();
            }
            if (e.ColumnIndex == 6)
            {
                var filaSeleccionada = e.RowIndex;
                var r = dgv.Rows[filaSeleccionada];
                SaleDetail dt = (SaleDetail)r.Tag!;
                int? cantidadVendida = GetSaleQuantity(dt.Quantity);
                if (cantidadVendida is null) return;

                var itemType = dt.ProductId is null ? ItemType.Combo : ItemType.Product;
                var itemId = dt.ProductId ?? dt.ComboId;
                var itemOnOrder = _itemService!.GetItemById(itemType, itemId!.Value);
                itemOnOrder!.OnOrderQuantity = itemOnOrder.OnOrderQuantity + cantidadVendida.Value - dt.Quantity;

                if (cantidadVendida <= itemOnOrder.Stock)
                {
                    _itemService.Save(itemOnOrder);

                    dt.Quantity = cantidadVendida.Value;
                    GridHelper.SetearFila(r, dt);
                    MostrarTotales();

                }
                else
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("Insufficient stock." + Environment.NewLine);
                    sb.AppendFormat($"Available stock: {itemOnOrder.Stock}");
                    MessageBox.Show(sb.ToString(), "Warning",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
            }
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            itemType = ItemType.Product;
            RecargarGrilla();
        }

        private void btnCombos_Click(object sender, EventArgs e)
        {
            itemType = ItemType.Combo;
            RecargarGrilla();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                frmSelectCustomer frm = new frmSelectCustomer(_serviceProvider) { Text = "Select Customer" };
                DialogResult dr = frm.ShowDialog(this);
                if (dr == DialogResult.Cancel)
                {
                    CancelarCompra();
                    return;
                }
                Customer? customer = frm.GetCustomer();
                sale!.CustomerId = customer!.CustomerId != 99999 ? customer.CustomerId : null;
                sale.Customer = customer;
                sale.SaleDate = DateTime.Now;

                sale.OrderStatusId = (int)cboOrderStatus.SelectedValue;
                sale.OrderTypeId = (int)cboOrderType.SelectedValue;

                sale.TotalAmount = sale.GetTotal();

                DialogResult = DialogResult.OK;
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                frmSelectCustomer frmCustomer = new frmSelectCustomer(_serviceProvider) { Text = "Seleccionar Cliente" };
                DialogResult drCustomer = frmCustomer.ShowDialog(this);

                if (drCustomer == DialogResult.OK)
                {
                    Customer? customer = frmCustomer.GetCustomer();
                    sale!.CustomerId = customer!.CustomerId != 99999 ? customer.CustomerId : null;
                    sale.Customer = customer;
                    sale.SaleDate = DateTime.Now;
                    sale.OrderStatusId = (int)cboOrderStatus.SelectedValue;
                    sale.OrderTypeId = (int)cboOrderType.SelectedValue;
                    sale.TotalAmount = sale.GetTotal();

                    frmPayment frmPayment = new frmPayment(sale, _serviceProvider);
                    DialogResult drPayment = frmPayment.ShowDialog(this);

                    if (drPayment == DialogResult.OK)
                    {
                       DialogResult = DialogResult.OK;
                       Close();
                    }
                    else
                    {
                        MessageBox.Show("El proceso de pago fue cancelado. La venta no se guardará.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }

        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            CancelarCompra();
            DialogResult = DialogResult.Cancel;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }                
    }
}
