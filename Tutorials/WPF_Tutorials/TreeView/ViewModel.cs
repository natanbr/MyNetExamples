using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WPF_Tutorials.TreeView
{
	class ViewModel
	{
		public ObservableCollection<Joint> JointTree1 { get; private set; }	
		public ObservableCollection<Joint> JointTree2 { get; private set; }	
		public ObservableCollection<Joint> JointTree3 { get; private set; }

        private Joint selectedItem;
	    public Joint SelectedItem1
	    {
            get { return selectedItem; }
            set
            {
                if (selectedItem == value)
                    return;

                selectedItem = value;
                // Do logic on selection change.
            }
	    }

	    public ViewModel()
		{
		    MostSimpleExample_Joint();

		    TreeOfObjectsExample_TreeNodes();

		    TreeOfObjectsFromDictionary_TreeNode();
		}

	    private void TreeOfObjectsFromDictionary_TreeNode()
	    {
	        var dictionary = new Dictionary<string, Ex3Obj>();

	        dictionary.Add("A", new Ex3Obj("A-"));
	        dictionary.Add("E", new Ex3Obj("E-"));
	        dictionary.Add("B", new Ex3Obj("B-"));
	        dictionary.Add("F", new Ex3Obj("F-"));
	        dictionary.Add("C", new Ex3Obj("C-"));

	        var tree = new Ex3Tree();
	        var root = tree.BuildTree(dictionary);
	        JointTree3 = TreeViewModel<Ex3Obj>.ConvertTreeNodeToItemView(root);
	    }

	    private void TreeOfObjectsExample_TreeNodes()
	    {
	        var treeNode =
	            new TreeNode<KeyValuePair<string, Ex2Obj>>(new KeyValuePair<string, Ex2Obj>("Root", new Ex2Obj()));

	        treeNode.AddChild(new KeyValuePair<string, Ex2Obj>("This is Exampel 2", new Ex2Obj()));
	        JointTree2 = (new TreeViewModel<Ex2Obj>(treeNode)).JointTree;
	    }

	    private void MostSimpleExample_Joint()
	    {
	        JointTree1 = new ObservableCollection<Joint>();
	        Joint root =
	            new Joint("This")
	            {
	                new Joint("Is")
	                {
	                    new Joint("Example")
	                    {
	                        new Joint("1")
	                    }
	                },
	                new Joint("Spine")
	            };

	        JointTree1.Add(root);
	    }


	    private class Ex2Obj { }

	    private class Ex3Obj
	    {
	        public string Name;

	        public Ex3Obj(string name)
	        {
	            Name = name;
	        }
	    }

        private class Ex3Tree : ATree<Ex3Obj>
        {
            protected override void AddNodeToTree(ref TreeNode<KeyValuePair<string, Ex3Obj>> tree, KeyValuePair<string, Ex3Obj> child)
            {
                var rNode = tree.FindLastTreeNode(node => String.CompareOrdinal(child.Value.Name, node.Data.Value.Name) > 0);
                var lNode = tree.FindFirstTreeNode(node => String.CompareOrdinal(child.Value.Name, node.Data.Value.Name) < 0);

                if (rNode == null && lNode == null)
                    tree.AddChild(child);
                else if (rNode != null)
                    rNode.AddChild(child);
                else if (lNode != null)
                    lNode.AddChild(child);
            }

            protected override TreeNode<KeyValuePair<string, Ex3Obj>> SetRoot()
            {
                return new TreeNode<KeyValuePair<string, Ex3Obj>>(new KeyValuePair<string, Ex3Obj>("Root", new Ex3Obj("ERoot")));
            }
        }
	}
}
