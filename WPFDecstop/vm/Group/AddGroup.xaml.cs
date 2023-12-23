using System.Linq;
using System.Windows;
using System.Windows.Controls;
using WPFDecstop.Models;

namespace WPFDecstop.vm.Group;

public partial class AddGroup : Page
{
    public AddGroup()
    {
        InitializeComponent();
    }

    private void ButtonBase_OnClick_Add_an_group(object sender, RoutedEventArgs e)
    {
        using (TimetableContext db = new TimetableContext())
        {
            if (0 == db.Groups.Where(p => p.GroupNumber == group_number_TextBox.Text).Count() &&
                0 == db.Groups.Where(p => p.ShortNumber == Short_number_TextBox.Text).Count())
            {
                int studentAmmount = 0;
                int.TryParse(number_of_students_TextBox.Text, out studentAmmount);
                Models.Group group = new Models.Group
                {
                    GroupNumber = group_number_TextBox.Text,
                    ShortNumber = Short_number_TextBox.Text,
                    StudentAmmount = studentAmmount,
                };
                db.Groups.Add(group);
                db.SaveChanges();
            }
        }
    }
}