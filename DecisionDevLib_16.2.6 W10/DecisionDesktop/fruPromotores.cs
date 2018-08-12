using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using Decision.Lists;

namespace DecisionDesktop
{
    public partial class fruPromotores : EditFormUserControl 
    {
        public fruPromotores()
        {
            InitializeComponent();
        }

        private void fruPromotores_Load(object sender, EventArgs e)
        {
            this.cboStatus.Properties.Items.Add(new ComboItem("Ativo", "A"));
            this.cboStatus.Properties.Items.Add(new ComboItem("Inativo", "I"));
            this.cboStatus.EditValue = this.cboStatus.Text;
        }

        private void fruPromotores_Enter(object sender, EventArgs e)
        {
            if (this.cboStatus.Text == "A")
                this.cboStatus.SelectedItem = this.cboStatus.Properties.Items[0];
            else
                this.cboStatus.SelectedItem = this.cboStatus.Properties.Items[1];
        }

        private void fruPromotores_Leave(object sender, EventArgs e)
        {
            this.cboStatus.Text = this.cboStatus.Text.Substring(0, 1);
        }
    }
}
