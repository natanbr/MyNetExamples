using System.Collections.Generic;

namespace WPF_Tutorials.TreeView
{
    public abstract class ATree<T>
    {
        /// <summary>
        /// The root of the tree
        /// </summary>
        public TreeNode<KeyValuePair<string, T>> Root { get; set; }

        /// <summary>
        /// Spesify how to Add a new node to the Tree
        /// </summary>
        /// <param name="tree"></param>
        /// <param name="child"></param>
        protected abstract void AddNodeToTree(ref TreeNode<KeyValuePair<string, T>> tree,
            KeyValuePair<string, T> child);

        /// <summary>
        /// Virtual method to set the Root value
        /// </summary>
        /// <returns></returns>
        protected virtual TreeNode<KeyValuePair<string, T>> SetRoot()
        {
            return new TreeNode<KeyValuePair<string, T>>(new KeyValuePair<string, T>("Tests", default(T)));
        }

        /// <summary>
        /// Build new Tree from the given Dictionary, where the sting is the displayed name and the test is the node
        /// The method to add new node spesifed by the AddNodeToTree
        /// </summary>
        /// <param name="leafs">All the objects to be added to the tree as leafs</param>
        /// <returns></returns>
        public TreeNode<KeyValuePair<string, T>> BuildTree(Dictionary<string, T> leafs)
        {
            Root = SetRoot();

            foreach (KeyValuePair<string, T> i in leafs)
            {
                var treeNode = Root;

                AddNodeToTree(ref treeNode, i);
            }

            //Root = testTree;

            return Root;
        }
    }
}
