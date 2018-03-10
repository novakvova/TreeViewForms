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
            _ce = new EFCategoryExplorer(); //new CategoryExplorer();
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

        private void CategoryForm_Load(object sender, EventArgs e)
        {
            _ce.LoadTreeView(tvCategory);
        }

        private void tvCategory_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if(e.Node.Nodes[0].Text=="")
            {
                TreeNode node = _ce.GetParentSubNodes(e.Node);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(tvCategory.SelectedNode!=null)
            {
                var name = tvCategory.SelectedNode.Text;
                DialogResult result = MessageBox
                    .Show(string.Format("Ви дійсно бажаєте видалити '{0}'", name),
                    "Видалення!", MessageBoxButtons.YesNo);
                if(result == DialogResult.Yes)
                {
                    _ce.RemoveCategory(tvCategory, tvCategory.SelectedNode);
                }
            }
        }
    }
}
