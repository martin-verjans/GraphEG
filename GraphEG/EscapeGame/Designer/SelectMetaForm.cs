using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphEG.EscapeGame
{
    public partial class SelectMetaForm : Form
    {
        public object SelectedValue => cbMetaList.SelectedItem;
        public SelectMetaForm()
        {
            InitializeComponent();
            FillComboBox();
        }

        private void FillComboBox()
        {
            cbMetaList.Items.Clear();
            cbMetaList.Items.Add("Exit");
            cbMetaList.Items.Add("Victory");
        }
    }
}
