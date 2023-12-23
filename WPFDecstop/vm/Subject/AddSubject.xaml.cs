using System.Linq;
using System.Windows;
using System.Windows.Controls;
using WPFDecstop.Models;

namespace WPFDecstop.vm.Item;

public partial class AddSubject : Page
{
    public AddSubject()
    {
        InitializeComponent();
    }

    private void ButtonBase_OnClick_Add_subject(object sender, RoutedEventArgs e)
    {
        using (TimetableContext db = new TimetableContext())
        {
            int semester_num = 0;
            int.TryParse(semester_num_TextBox.Text, out semester_num);
            int hours = 0;
            int.TryParse(hours_TextBox.Text, out hours);
            int practic_hours_ammount = 0;
            int.TryParse(practic_hours_ammount_TextBox.Text, out practic_hours_ammount);
            int lab_amount = 0;
            int.TryParse(lab_amount_TextBox.Text, out lab_amount);
            int attestation = 0;
            int.TryParse(attestation_TextBox.Text, out attestation);
            int consultation = 0;
            int.TryParse(consultation_TextBox.Text, out consultation);
            int consultation_hours_ammount = 0;
            int.TryParse(consultation_hours_ammount_TextBox.Text, out consultation_hours_ammount);
            int total_hours = 0;
            int.TryParse(total_hours_TextBox.Text, out total_hours);
            
            Models.Subject subject = new Models.Subject()
            {
                SubjectName = subject_name_TextBox.Text,
                SemesterNum = semester_num,
                Hours = hours,
                PracticHoursAmmount = practic_hours_ammount,
                LabAmount = lab_amount,
                Attestation = attestation,
                Consultation = consultation,
                ConsultationHoursAmmount = consultation_hours_ammount,
                TotalHours = total_hours
            };
            db.Subjects.Add(subject);
            db.SaveChanges();
        }
    }
}