namespace Windows.UsersControl
{
    public partial class ucItem : UserControl
    {
        private string _imagesBasePath = Path.Combine(Environment.CurrentDirectory, "Imagenes"); 
        private string _noImageAvailablePath; 
        private string _fileNotFoundPath;
        private string? _itemImageFileName;

        public ucItem()
        {
            InitializeComponent();
            _noImageAvailablePath = Path.Combine(_imagesBasePath, "ArchivoNoEncontrado1.jpg");
            _fileNotFoundPath = Path.Combine(_imagesBasePath, "ArchivoNoEncontrado1.jpg");

        }
        public int ItemId { get; set; }
        public string? Name { set => lblName.Text = value; }
        public decimal ItemPrice { set => lblPrice.Text = value.ToString(); }
        public string? ItemImage
        {
            get { return _itemImageFileName; }
            set
            {
                _itemImageFileName = value; 
                LoadAndDisplayItemImage();
            }
        }
        private void ucItem_MouseEnter(object sender, EventArgs e)
        {
            BackColor = Color.Gray;
        }
        private void ucItem_MouseLeave(object sender, EventArgs e)
        {
            BackColor = Color.White;
        }
        
        private void LoadAndDisplayItemImage()
        {
            picImage.Image = null;
            if (!string.IsNullOrEmpty(_itemImageFileName))
            {
                string fullPathToProductImage = Path.Combine(_imagesBasePath, _itemImageFileName);

                try
                {
                    if (File.Exists(fullPathToProductImage))
                    {
                        picImage.Image = Image.FromFile(fullPathToProductImage);
                        picImage.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    else
                    {
                        if (File.Exists(_fileNotFoundPath))
                        {
                            picImage.Image = Image.FromFile(_fileNotFoundPath);
                            picImage.SizeMode = PictureBoxSizeMode.StretchImage;
                        }
                        else
                        {
                            System.Diagnostics.Debug.WriteLine($"Error: Imagen de 'Archivo no encontrado' no existe en: {_fileNotFoundPath}");
                            picImage.Image = null;
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Error al cargar la imagen '{fullPathToProductImage}': {ex.Message}");
                    if (File.Exists(_fileNotFoundPath))
                    {
                        picImage.Image = Image.FromFile(_fileNotFoundPath);
                        picImage.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    else
                    {
                        picImage.Image = null;
                    }
                }
            }
            else
            {
                if (File.Exists(_noImageAvailablePath))
                {
                    picImage.Image = Image.FromFile(_noImageAvailablePath);
                    picImage.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine($"Error: Imagen de 'No disponible' no existe en: {_noImageAvailablePath}");
                    picImage.Image = null;
                }
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {

        }
    }
}
