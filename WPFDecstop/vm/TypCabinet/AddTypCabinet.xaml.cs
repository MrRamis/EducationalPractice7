using System.Windows;
using System.Windows.Controls;
using WPFDecstop.Models;

namespace WPFDecstop.vm.TypCabinet;

public partial class AddTypCabinet : Page
{
    public AddTypCabinet()
    {
        InitializeComponent();
    }

    private void ButtonBase_OnClick_Add_an_account_type(object sender, RoutedEventArgs e)
    {
        using (TimetableContext db = new TimetableContext())
        {
            CabinetType cabinetType = new CabinetType()
            {
                CabinetName = Cabinet_Type_Name_TextBox.Text,
                Discription = Description_TextBox.Text
            };
            db.CabinetTypes.Add(cabinetType);
            db.SaveChanges();
        }
        NavigationService.Navigate(null);
    }
}