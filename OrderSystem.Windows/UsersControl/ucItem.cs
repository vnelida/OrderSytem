namespace Windows.UsersControl
{
    public partial class ucItem : UserControl
    {
        private string _imagesBasePath = Path.Combine(Environment.CurrentDirectory, "Imagenes"); // Carpeta base de las imágenes
        private string _noImageAvailablePath; // Ruta completa a la imagen "No disponible"
        private string _fileNotFoundPath;     // Ruta completa a la imagen "Archivo no encontrado"

        // Campo privado para almacenar el nombre del archivo de imagen del producto/combo.
        private string? _itemImageFileName;

        public ucItem()
        {
            InitializeComponent();
            _noImageAvailablePath = Path.Combine(_imagesBasePath, "SinImagenDisponible.jpg");
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
                _itemImageFileName = value; // Guardamos el nombre del archivo (ej. "kpXBMZ00.jpg")

                // Ahora, llamamos al método que realmente carga y muestra la imagen
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
            // Primero, aseguramos que el PictureBox esté vacío antes de intentar cargar una nueva imagen
            this.picImage.Image = null; // Asume que tu PictureBox se llama 'picImage'. ¡Asegúrate de que el nombre sea correcto!

            // Verificamos si tenemos un nombre de archivo de imagen válido para el producto/combo
            if (!string.IsNullOrEmpty(_itemImageFileName))
            {
                // Construimos la ruta COMPLETA al archivo de imagen del producto/combo
                string fullPathToProductImage = Path.Combine(_imagesBasePath, _itemImageFileName);

                try
                {
                    // Intentamos cargar la imagen real del producto/combo
                    if (File.Exists(fullPathToProductImage))
                    {
                        this.picImage.Image = Image.FromFile(fullPathToProductImage); // ¡Aquí se carga la imagen real!
                        this.picImage.SizeMode = PictureBoxSizeMode.Zoom; // Ajusta el tamaño de la imagen en el PictureBox
                    }
                    else
                    {
                        // Si el archivo de imagen del producto no se encuentra, mostramos la imagen de "Archivo no encontrado"
                        if (File.Exists(_fileNotFoundPath))
                        {
                            this.picImage.Image = Image.FromFile(_fileNotFoundPath);
                            this.picImage.SizeMode = PictureBoxSizeMode.CenterImage; // Ajuste para las imágenes de error/respaldo
                        }
                        else
                        {
                            // Último recurso si ni siquiera la imagen de "no encontrado" existe
                            System.Diagnostics.Debug.WriteLine($"Error: Imagen de 'Archivo no encontrado' no existe en: {_fileNotFoundPath}");
                            this.picImage.Image = null; // Deja el PictureBox vacío
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Capturamos errores si el archivo existe pero no se puede cargar (ej. corrupto, formato inválido)
                    System.Diagnostics.Debug.WriteLine($"Error al cargar la imagen '{fullPathToProductImage}': {ex.Message}");
                    // En caso de error, mostramos la imagen de "Archivo no encontrado"
                    if (File.Exists(_fileNotFoundPath))
                    {
                        this.picImage.Image = Image.FromFile(_fileNotFoundPath);
                        this.picImage.SizeMode = PictureBoxSizeMode.CenterImage;
                    }
                    else
                    {
                        this.picImage.Image = null;
                    }
                }
            }
            else // Si _itemImageFileName es nulo o vacío (el producto/combo no tiene una imagen asignada en la BD)
            {
                // Mostramos la imagen de "Sin imagen disponible"
                if (File.Exists(_noImageAvailablePath))
                {
                    this.picImage.Image = Image.FromFile(_noImageAvailablePath);
                    this.picImage.SizeMode = PictureBoxSizeMode.CenterImage;
                }
                else
                {
                    // Último recurso si ni siquiera la imagen de "no disponible" existe
                    System.Diagnostics.Debug.WriteLine($"Error: Imagen de 'No disponible' no existe en: {_noImageAvailablePath}");
                    this.picImage.Image = null;
                }
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {

        }
    }
}
