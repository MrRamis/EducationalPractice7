using System.Windows.Controls;

namespace WPFDecstop.vm;

public partial class PageListViewCabinet : Page
{
    public PageListViewCabinet(string text)
    {
        InitializeComponent();
        TextBox.Text = text;
    }
}