using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Example
{
    public interface ICategoryExplorer : IDisposable
    {
        void LoadTreeView(TreeView treeView);
        bool AddRootCategory(TreeView treeView, string textNode);
        bool AddNode(TreeNode parentNode, string textNode);
        bool EditNode(TreeNode nodeEdit, string textNode);


    }
}
