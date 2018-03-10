using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Example
{
    public class CategoryExplorer : ICategoryExplorer
    {
        public bool AddRootCategory(TreeView treeView, string textNode)
        {
            TreeNode node = new TreeNode();
            node.Text = textNode;
            node.Name = Guid.NewGuid().ToString();
            treeView.Nodes.Add(node);
            //node.Name=
            return true;
        }

        public bool EditNode(TreeNode nodeEdit, string textNode)
        {
            nodeEdit.Text=textNode;
            return true;
        }

        bool ICategoryExplorer.AddNode(TreeNode parentNode, string textNode)
        {
            TreeNode node=new TreeNode();
            node.Text = textNode;
            node.Name = Guid.NewGuid().ToString();
            parentNode.Nodes.Add(node);
            return true;
        }
        
    }
}
