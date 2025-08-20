using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Windows.Forms
{
    public partial class frmFilterDateReport : Form
    {

        private readonly IServiceProvider _serviceProvider;
        public frmFilterDateReport(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            var firstDate = dtpStartDate.Value;
            var secdDate = dtpEndDate.Value.AddDays(1);
            frmPaymentReport frm = new frmPaymentReport(_serviceProvider);
            frm.SetDate(firstDate, secdDate);
            frm.ShowDialog();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
