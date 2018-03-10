using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Example
{
    public partial class CategoryForm : Form
    {
        ICategoryExplorer _ce;
        public CategoryForm()
        {
            _ce = new CategoryExplorer();
            InitializeComponent();
        }

        private void btnAddRoot_Click(object sender, EventArgs e)
        {
            CreateCategoryForm dlg = new CreateCategoryForm();
            if(dlg.ShowDialog()==DialogResult.OK)
            {
                _ce.AddRootCategory(tvCategory, dlg.CategoryName);
                tvCategory.Focus();
            }
            //
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (tvCategory.SelectedNode != null)
            {
                CreateCategoryForm dlg = new CreateCategoryForm();
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    _ce.AddNode(tvCategory.SelectedNode, dlg.CategoryName);
                    tvCategory.Focus();
                }
            }

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (tvCategory.SelectedNode != null)
            {
                _ce.EditNode(tvCategory.SelectedNode, "EditNode");
            }
        }
    }
}
