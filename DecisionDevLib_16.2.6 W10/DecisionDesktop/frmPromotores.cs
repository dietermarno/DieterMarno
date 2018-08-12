using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DecisionDesktop
{
    public partial class frmPromotores : Form
    {
        public frmPromotores()
        {
            InitializeComponent();
            mySqlDataAdapter1.Fill(mySqlDataTable1);
            //gridView1.OptionsEditForm.CustomEditFormLayout = new fruPromotores();
        }

        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            mySqlDataAdapter1.Update(mySqlDataTable1);
        }
    }
}
