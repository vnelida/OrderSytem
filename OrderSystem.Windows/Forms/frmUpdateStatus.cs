namespace Windows
{
    public partial class frmUpdateStatus : Form
    {
        public frmUpdateStatus(string mensaje)
        {
            InitializeComponent();
            lblMssg.Text = mensaje;
        }
        private void btnYes_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }
    }
}
