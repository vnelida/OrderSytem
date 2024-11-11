﻿using Entities.Entities;
using Windows.Helpers;

namespace Windows.Forms
{
    public partial class frmProductsAE : Form
    {
        private readonly IServiceProvider? _serviceProvider;
        private Category? selectedCategory;
        private Product? product;

        private string imagenNoDisponible = Environment.CurrentDirectory + @"\Imagenes\SinImagenDisponible.jpg";
        private string archivoNoEncontrado = Environment.CurrentDirectory + @"\Imagenes\ArchivoNoEncontrado.jpg";
        private string? archivoImagen = string.Empty;
        private string carpetaImagen = Environment.CurrentDirectory + @"\Imagenes\";

        public frmProductsAE(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            CombosHelper.CargarComboCategories(ref cboCategories, _serviceProvider);
            if (product != null)
            {
                txtProductName.Text = product.Name;
                txtDescription.Text = product.Description;
                numPrice.Value = product.CostPrice;
                numSalePrice.Value = product.SalePrice;
                numStock.Value = product.Stock;
                cboCategories.SelectedValue = product.CategoryId;
                numReorderLevel.Value = product.ReorderLevel;
                checkBoxSuspended.Checked = product.Suspended;
                //ver tamaño y tipo de imagen
                if (product.Image != string.Empty)
                {
                    if (!File.Exists($"{carpetaImagen}{product.Image}"))
                    {
                        picImage.Image = Image.FromFile(archivoNoEncontrado);
                    }
                    else
                    {
                        picImage.Image = Image.FromFile($"{carpetaImagen}{product.Image}");
                        archivoImagen = product.Image;
                    }
                }
                else
                {
                    picImage.Image = Image.FromFile(imagenNoDisponible);
                }
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (ValidateData())
            {

                if (product == null)
                {
                    product = new Product();
                }
                product.Name = txtProductName.Text;
                product.Description = txtDescription.Text;
                product.Stock = (int)numStock.Value;
                product.ReorderLevel = (int)numReorderLevel.Value;
                product.Suspended = checkBoxSuspended.Checked;
                product.CostPrice = numPrice.Value;
                product.SalePrice = numSalePrice.Value;
                if (cboCategories.SelectedValue is not null)
                {
                    product.CategoryId = (int)cboCategories.SelectedValue;
                    product.Category = selectedCategory;

                }
                if (product.Image != string.Empty || product.Image is not null)
                {
                    if (!File.Exists($"{carpetaImagen}{product.Image}"))
                    {
                        picImage.Image = Image.FromFile(archivoNoEncontrado);
                    }
                    else
                    {
                        picImage.Image = Image.FromFile($"{carpetaImagen}{product.Image}");
                        archivoImagen = product.Image;
                    }
                }
                else
                {
                    picImage.Image = Image.FromFile(imagenNoDisponible);
                }
                DialogResult = DialogResult.OK;
            }
        }
        private void cboCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCategories.SelectedIndex == 0)
            {
                selectedCategory = null;
            }
            else
            {
                selectedCategory = (Category?)cboCategories.SelectedItem;
            }
        }
        internal Product? GetTipo()
        {
            return product;
        }
        private bool ValidateData()
        {
            bool valido = true;
            errorProvider1.Clear();

            if (string.IsNullOrEmpty(txtProductName.Text))
            {
                valido = false;
                errorProvider1.SetError(txtProductName, "The product name is required.");
            }
            if (txtProductName.Text.Length > 40 )
            {
                valido = false;
                errorProvider1.SetError(txtProductName, "The product name must not exceed 40 characters.");
            }
            if (txtProductName.Text.Length < 3)
            {
                valido = false;
                errorProvider1.SetError(txtProductName, "The product name must be at least 3 characters long.");
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtProductName.Text, @"^[a-zA-Z\s]+$"))
            {
                valido = false;
                errorProvider1.SetError(txtProductName, "The product name must contain only letters and spaces.");
            }
            if (string.IsNullOrEmpty(txtDescription.Text) || txtDescription.Text.Length > 100 || txtDescription.Text.Length < 3 || !System.Text.RegularExpressions.Regex.IsMatch(txtDescription.Text, @"^[a-zA-Z\s]+$"))
            {
                valido = false;
                errorProvider1.SetError(txtDescription, "A description is required.");
            }
            if (txtDescription.Text.Length > 100)
            {
                valido = false;
                errorProvider1.SetError(txtDescription, "The description must not exceed 100 characters.");
            }
            if (txtDescription.Text.Length < 3)
            {
                valido = false;
                errorProvider1.SetError(txtDescription, "The description must be at least 3 characters long.");
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtDescription.Text, @"^[a-zA-Z\s]+$"))
            {
                valido = false;
                errorProvider1.SetError(txtDescription, "The description must contain only letters and spaces.");
            }
            if (!decimal.TryParse(numPrice.Text, out decimal costPrice)
                || costPrice <= 0)
            {
                valido = false;
                errorProvider1.SetError(numPrice, "The cost price cannot be negative or null.");
            }
            if (!decimal.TryParse(numSalePrice.Text, out decimal salePrice) || salePrice <= numPrice.Value)
            {
                valido = false;
                errorProvider1.SetError(numSalePrice, "The sale price cannot be lower than the cost price.");
            }
            if (cboCategories.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(cboCategories, "You must select a category.");
            }
            if (!int.TryParse(numStock.Text, out int stock) || stock < 0)
            {
                valido = false;
                errorProvider1.SetError(numStock, "Stock cannot be negative.");
            }
            return valido;
        }

        public void SetTipo(Product product)
        {
            this.product = product;
        }
        private void btnSearchImages_Click(object sender, EventArgs e)
        {
            openFileDialog1.Multiselect = false;
            openFileDialog1.InitialDirectory = Environment.CurrentDirectory + @"\Imagenes\";
            openFileDialog1.Filter = @"Archivos jpg (*.jpg) | *.jpg |Archivos png (*.png) | *.png |Archivos jfif (*.jfif) | *.jfif | 
                Todos (*.*) | *.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;
            DialogResult dr = openFileDialog1.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                if (openFileDialog1.FileName == null)
                {
                    return;
                }
                picImage.Image = Image.FromFile(openFileDialog1.FileName);
                archivoImagen = openFileDialog1.FileName;
            }

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
