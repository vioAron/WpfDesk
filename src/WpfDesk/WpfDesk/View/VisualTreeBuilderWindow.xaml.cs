using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfDesk.View
{
    /// <summary>
    /// Interaction logic for VisualTreeBuilderWindow.xaml
    /// </summary>
    public partial class VisualTreeBuilderWindow : Window
    {
        public VisualTreeBuilderWindow()
        {
            InitializeComponent();
        }

        public void BuildVisualTree(DependencyObject dependencyObject)
        {
            treeElements.Items.Clear();

            TraverseElement(dependencyObject, null);
        }

        private void TraverseElement(DependencyObject currentElement, TreeViewItem parentItem)
        {
            var item = new TreeViewItem();
            item.Header = currentElement.GetType().Name;
            item.IsExpanded = true;

            if (parentItem == null)
            {
                treeElements.Items.Add(item);
            }
            else
            {
                parentItem.Items.Add(item);
            }

            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(currentElement); i++)
            {
                TraverseElement(VisualTreeHelper.GetChild(currentElement, i), item);
            }
        }
    }
}
