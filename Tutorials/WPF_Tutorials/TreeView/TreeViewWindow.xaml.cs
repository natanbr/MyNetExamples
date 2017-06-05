using System;
using System.Windows;
using WPF_Tutorials.TreeView;

namespace WPF_Tutorials
{
    /// <summary>
    /// Interaction logic for TreeViewWindow.xaml
    /// </summary>
    public partial class TreeViewWindow : Window
    {
        public TreeViewWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Not a MVVM style! but, this is an example for getting a value
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TreeView3_OnSelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            var selected = JointTree3.SelectedItem as Joint;
            if (selected == null) return;
            var selectedName = selected.Name;
            // the name can be used to retrive the object from the dictionary
        }
    }
}
