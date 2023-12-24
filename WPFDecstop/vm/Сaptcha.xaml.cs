using System;
using System.Diagnostics;
using System.Net.Mime;
using System.Windows;
using WPFDecstop.data.captcha;

namespace WPFDecstop.vm;

public partial class Сaptcha : Window
{
    GetCorginatesNumbers getCorginatesNumbers = new GetCorginatesNumbers();
    private string capt = "";
    private int countNotAttemps=0;
    public Сaptcha()
    {
        InitializeComponent();
        genCapt();
        genbackground();
    }
    private void Button_Click(object sender, RoutedEventArgs e)
    {
        genCapt();
        genbackground();
    }
    private void Button_Click_1(object sender, RoutedEventArgs e)
    {
        if(Text.Text == capt)
        {
            TextResult.Text = "Ok";
        }
        else
        {
            countNotAttemps++;
            genCapt();
            genbackground();
            if (countNotAttemps == 3)
                Process.GetCurrentProcess().Kill();
        }
    }
    private void genCapt()
    {
        Random random = new Random();

        one.Points.Clear();
        two.Points.Clear();
        three.Points.Clear();
        four.Points.Clear();
        capt = "";
        var oneRandom = random.Next(9);
        var twoRandom = random.Next(9);
        var threeRandom = random.Next(9);
        var fourRandom = random.Next(9);
        capt += oneRandom;
        capt += twoRandom;
        capt += threeRandom;
        capt += fourRandom;
        foreach (var t in getCorginatesNumbers.getCorginatesNumbers(oneRandom))
        {
            one.Points.Add(t);
        }
        foreach (var t in getCorginatesNumbers.getCorginatesNumbers(twoRandom))
        {
            two.Points.Add(t);
        }
        foreach (var t in getCorginatesNumbers.getCorginatesNumbers(threeRandom))
        {
            three.Points.Add(t);
        }
        foreach (var t in getCorginatesNumbers.getCorginatesNumbers(fourRandom))
        {
            four.Points.Add(t);
        }
    }
    private void genbackground()
    {
        Random random = new Random();
        onef.Points.Clear();
        twof.Points.Clear();
        threef.Points.Clear();
        fourf.Points.Clear();
        var oneRandom = random.Next(3);
        var twoRandom = random.Next(3);
        var threeRandom = random.Next(3);
        var fourRandom = random.Next(3);
        foreach (var t in getCorginatesNumbers.getCorginatesbackground(oneRandom))
        {
            onef.Points.Add(t);
        }
        foreach (var t in getCorginatesNumbers.getCorginatesbackground(twoRandom))
        {
            twof.Points.Add(t);
        }
        foreach (var t in getCorginatesNumbers.getCorginatesbackground(threeRandom))
        {
            threef.Points.Add(t);
        }
        foreach (var t in getCorginatesNumbers.getCorginatesbackground(fourRandom))
        {
            fourf.Points.Add(t);
        }
    }
}