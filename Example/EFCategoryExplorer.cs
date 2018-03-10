using Example.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;

namespace Example
{
    public class EFCategoryExplorer : ICategoryExplorer
    {
        private readonly EFContext _context;
        public EFCategoryExplorer()
        {
            _context = new EFContext();
        }
        public bool AddNode(TreeNode parentNode, string textNode)
        {
            try
            {
                var model = (CategoryViewModel)parentNode.Tag;
                Category category = new Category
                {
                    Name = textNode,
                    ParentId = model.Id
                };
                _context.Categories.Add(category);
                _context.SaveChanges();
                TreeNode node = new TreeNode();
                node.Text = textNode;
                node.Name = Guid.NewGuid().ToString();
                node.Tag = new CategoryViewModel
                {
                    Id=category.Id,
                    Name=category.Name,
                    ParentId=category.ParentId
                };
                parentNode.Nodes.Add(node);
                return true;
            }
            catch 
            {

                return false;
            }
            
        }

        public bool AddRootCategory(TreeView treeView, string textNode)
        {
            try
            {
                Category category = new Category
                {
                    Name = textNode,
                    ParentId = null
                };
                _context.Categories.Add(category);
                _context.SaveChanges();
                CategoryViewModel model = new CategoryViewModel
                {
                    Id=category.Id,
                    Name=category.Name,
                    ParentId=category.ParentId
                };
                TreeNode node = new TreeNode();
                node.Text = textNode;
                node.Name = Guid.NewGuid().ToString();
                node.Tag = model;
                treeView.Nodes.Add(node);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public bool EditNode(TreeNode nodeEdit, string textNode)
        {
            throw new NotImplementedException();
        }

        public void LoadTreeView(TreeView treeView)
        {
            try
            {
                var query = from c in _context.Categories
                            where c.ParentId == null
                            orderby c.Name
                            select new CategoryViewModel
                            {
                                Id = c.Id,
                                Name = c.Name,
                                ParentId = c.ParentId
                            };
                foreach(var c in query)
                {
                    TreeNode node = new TreeNode();
                    node.Text = c.Name;
                    node.Name = Guid.NewGuid().ToString();
                    node.Tag = c;
                    //??????
                    node.Nodes.Add("");
                    treeView.Nodes.Add(node);
                }
            }
            catch 
            {

                throw;
            };
        }

        public TreeNode GetParentSubNodes(TreeNode parentNode)
        {
            try
            {
                var model = (CategoryViewModel)parentNode.Tag;
                var query = from c in _context.Categories
                            where c.ParentId == model.Id
                            orderby c.Name
                            select new CategoryViewModel
                            {
                                Id=c.Id,
                                Name=c.Name,
                                ParentId=c.ParentId
                            };
                parentNode.Nodes.Clear();
                foreach (var c in query)
                {
                    TreeNode node = new TreeNode();
                    node.Text = c.Name;
                    node.Name = Guid.NewGuid().ToString();
                    node.Tag = c;
                    //??????
                    node.Nodes.Add("");
                    parentNode.Nodes.Add(node);

                }

            }
            catch(Exception ex)
            {
                MessageBox.Show("Виникла помилка при оновлені дочірнього вузла!\n"
                    + ex.Message);
                //throw;
            }
            return parentNode;
        }

        public bool RemoveCategory(TreeView treeView, TreeNode node)
        {
            try
            {
                var model = (CategoryViewModel)node.Tag;
                var category = _context.Categories
                    .SingleOrDefault(c => c.Id == model.Id);
                if(category!=null)
                {
                    if (category.Categories.Count == 0)
                    {
                        _context.Categories.Remove(category);
                        _context.SaveChanges();
                        treeView.Nodes.Remove(node);
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
            
            return true;
        }
    }
}
