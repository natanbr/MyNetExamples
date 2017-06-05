using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WPF_Tutorials.TreeView
{
	public class Joint : ObservableCollection<Joint>
	{
		public string Name { get; private set; }

		public Joint( string i_name )
		{
			Name = i_name;
		}
	}

    public class TreeViewModel<T>
    {
        public ObservableCollection<Joint> JointTree { get; private set; }

        public TreeNode<KeyValuePair<string, T>> Tree { get; set; }

        public TreeViewModel(TreeNode<KeyValuePair<string, T>> tree)
        {
            Tree = tree;

            JointTree = new ObservableCollection<Joint>();

            var root = new Joint(string.Empty);
            TreeToItemView(Tree, ref root);

            JointTree.Add(root);
        }

        protected static void TreeToItemView(TreeNode<KeyValuePair<string, T>> tree, ref Joint root)
        {
            if (tree == null) return;

            if (tree.IsLeaf)
            {
                root.Add(new Joint(tree.Data.Key));
                return;
            }

            var breanch = new Joint(tree.Data.Key);

            if (root.Name == string.Empty)
                root = breanch;
            else
                root.Add(breanch);

            foreach (var node in tree.Children)
                TreeToItemView(node, ref breanch);
        }

        public static ObservableCollection<Joint> ConvertTreeNodeToItemView(TreeNode<KeyValuePair<string, T>> tree)
        {
            var testJointTree = new ObservableCollection<Joint>();

            var root = new Joint(string.Empty);
            TreeToItemView(tree, ref root);

            testJointTree.Add(root);

            return testJointTree;
        }
    }
}
