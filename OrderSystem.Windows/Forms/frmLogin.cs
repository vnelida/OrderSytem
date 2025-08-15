using Entities.Entities;
using Microsoft.Extensions.DependencyInjection;
using OrderSystem.Windows;
using Services.Interfaces;

namespace Windows.Forms
{
    public partial class frmLogin : Form
    {
        private readonly IServiceProvider? serviceProvider;
        private readonly IUsersService? _service;
        private User? user;
        public frmLogin(IServiceProvider? serviceProvider)
        {
            InitializeComponent();
            this.serviceProvider = serviceProvider;
            _service = serviceProvider!.GetService<IUsersService>();
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainMenu frm = new MainMenu(serviceProvider);
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLoginn_Click(object sender, EventArgs e)
        {
            user = _service.GetUser(txtUser.Text, txtPassword.Text);
            if (user != null)
            {
                Hide();
                var frm = new MainMenu(serviceProvider);
                frm.FormClosing += Frm_FormClosing;
                frm.SetUser(user);
                frm.Show();
            }
            else
            {
                MessageBox.Show("User not found" + Environment.NewLine + "or incorrect password",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                LimpiarTextos();
            }

        }

        private void LimpiarTextos()
        {
            txtUser.Clear();
            txtPassword.Clear();
            txtUser.Focus();
        }

        private void Frm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Show();
            LimpiarTextos();
        }
    }
}
