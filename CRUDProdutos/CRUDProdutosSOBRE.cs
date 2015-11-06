using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUDProdutos
{
    public partial class CRUDProdutosSOBRE : Form
    {
        public CRUDProdutosSOBRE()
        {
            InitializeComponent();
        }

        private void CRUDProdutosSOBRE_FormClosed(object sender, FormClosedEventArgs e)
        {
            CRUDProdutosUIL uil = new CRUDProdutosUIL();
            uil.Show();
            this.Visible = false;
        }
    }
}
