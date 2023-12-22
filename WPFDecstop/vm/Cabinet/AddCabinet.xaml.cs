using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using WPFDecstop.Models;

namespace WPFDecstop.vm.Cabinet;

public partial class AddCabinet : Page
{
    public List<CabinetType> CabinetTypeListBox { get; set; }
    public AddCabinet()
    {
        InitializeComponent();
        using (TimetableContext db = new TimetableContext())
        {
            Cabinet_Type_ListBox.ItemsSource = db.CabinetTypes.ToList();
        }
    }

    private void ButtonBase_OnClick_Add_an_account(object sender, RoutedEventArgs e)
    {
        if (Cabinet_Type_ListBox.SelectedItem != null)
        {
            using (TimetableContext db = new TimetableContext())
            {
                if (0 == db.Cabinets.Where(p => p.CabinetNumber == Office_Number_TextBox.Text).Count())
                {
                    int ammountOfPlaces = 0;
                    int.TryParse(Number_Of_TextBox.Text, out ammountOfPlaces);
                    CabinetType idCabinetType = (CabinetType)Cabinet_Type_ListBox.SelectedItem;
                    Models.Cabinet cabinet = new Models.Cabinet()
                    {
                        AmmountOfPlaces = ammountOfPlaces,
                        CabinetNumber = Office_Number_TextBox.Text,
                        IdCabinetType = idCabinetType.Id
                    };
                    db.Cabinets.Add(cabinet);
                    db.SaveChanges();
                }
            }
        }
        else
            MessageBox.Show("Выберите тип кабинета");
    }
}