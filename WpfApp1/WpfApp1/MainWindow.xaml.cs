using Reactive.Bindings;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ReactiveCollection<Item> Items { get; }

        public MainWindow()
        {
            Items = new ReactiveCollection<Item>();
            for (int i = 1; i <= 100; i++)
            {
                Items.Add(new Item(i, isCheck:(i%2==0)));
            }

            InitializeComponent();
        }

        private void dataGrid_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            ScrollChanged(sender, e);
        }

        private void ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            if (sender == headerScrollViewer)
            {
                var child = VisualTreeHelper.GetChild(dataGrid, 0) as Decorator;
                if (child != null)
                {
                    var scroll = child.Child as ScrollViewer;
                    if (scroll != null)
                    {
                        scroll.ScrollToVerticalOffset(e.VerticalOffset);
                        scroll.ScrollToHorizontalOffset(e.HorizontalOffset);
                    }
                }
            }
            else
            {
                headerScrollViewer.ScrollToVerticalOffset(e.VerticalOffset);
                headerScrollViewer.ScrollToHorizontalOffset(e.HorizontalOffset);
            }
        }
    }
}