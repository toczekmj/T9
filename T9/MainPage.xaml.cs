using System.Diagnostics;
using Backend;

namespace T9;

public partial class MainPage : ContentPage
{
    int count = 0;
    private Trie _trie;
    private readonly Stopwatch sw;
    private readonly IDispatcherTimer tr;
    private int clicks = 0;
    private Button current_button;

    public MainPage()
    {
        InitializeComponent();
        sw = new Stopwatch();
        tr = Application.Current.Dispatcher.CreateTimer();
        tr.Interval = TimeSpan.FromMilliseconds(10);
        tr.Tick += (s, e) => CheckForLastLetter();
    }

    private void CheckForLastLetter()
    {
        if (sw.IsRunning && sw.ElapsedMilliseconds > 1300)
        {
            sw.Stop();
            tr.Stop();
            string res;

            if (current_button == Btn_2)
            {
                res = CalculateLetter('a', 'b', 'c', '2');
                Btn_2.Text = "ABC";
            }
            else if (current_button == Btn_3)
            {
                res = CalculateLetter('d', 'e', 'f', '3');
                Btn_3.Text = "DEF";
            }
            else if (current_button == Btn_4)
            {
                res = CalculateLetter('g', 'h', 'i', '4');
                Btn_4.Text = "GHI";
            }
            else if (current_button == Btn_5)
            {
                res = CalculateLetter('j', 'k', 'l', '5');
                Btn_5.Text = "JKL";
            }
            else if (current_button == Btn_6)
            {
                res = CalculateLetter('m', 'n', 'o', '6');
                Btn_6.Text = "MNO";
            }
            else if (current_button == Btn_7)
            {
                res = CalculateLetter('p', 'q', 'r', 's', '7');
                Btn_7.Text = "PQRS";
            }
            else if (current_button == Btn_8)
            {
                res = CalculateLetter('t', 'u', 'v', '8');
                Btn_8.Text = "TUV";
            }
            else if (current_button == Btn_9)
            {
                res = CalculateLetter('w', 'x', 'y', 'z', '9');
                Btn_9.Text = "WXYZ";
            }
            else
            {
                res = "";
            }

            editor1.Text += res;
            clicks = 0;
        }
    }


    private void ButtonClicked(Button button, char a, char b, char c, char n)
    {
        if (sw.IsRunning)
        {
            if (sw.ElapsedMilliseconds > 1000)
            {
                sw.Stop();
                tr.Stop();
                var res = CalculateLetter(a, b, c, n);
                editor1.Text += res;
                current_button = button;
                clicks = 0;
                button.Text = $" ({Convert.ToInt32(n)}) " + string.Join(a, b, c).ToUpper();
                return;
            }
            else
            {
                clicks++;

                tr.Stop();
                sw.Restart();
                tr.Start();
            }
        }
        else
        {
            current_button = button;
            tr.Stop();
            sw.Restart();
            tr.Start();
            clicks++;
        }

        SetButtonText(button, a, b, c, n);
    }

    private void ButtonClicked(Button button, char a, char b, char c, char d, char n)
    {
        if (sw.IsRunning)
        {
            if (sw.ElapsedMilliseconds > 1000)
            {
                sw.Stop();
                tr.Stop();
                var res = CalculateLetter(a, b, c, d, n);
                editor1.Text += res;
                current_button = button;
                clicks = 0;
                button.Text = $" ({Convert.ToInt32(n)}) " + string.Join(a, b, c, d).ToUpper();
                return;
            }

            clicks++;
            tr.Stop();
            sw.Restart();
            tr.Start();
        }
        else
        {
            current_button = button;
            tr.Stop();
            sw.Restart();
            tr.Start();
            clicks++;
        }

        SetButtonText(button, a, b, c, d, n);
    }

    private void SetButtonText(Button button, char a, char b, char c, char n)
    {
        var temp = clicks % 7;
        button.Text = temp switch
        {
            1 => a.ToString(),
            2 => b.ToString(),
            3 => c.ToString(),
            4 => a.ToString().ToUpper(),
            5 => b.ToString().ToUpper(),
            6 => c.ToString().ToUpper(),
            0 => n.ToString(),
            _ => button.Text
        };
    }

    private void SetButtonText(Button button, char a, char b, char c, char d, char n)
    {
        var temp = clicks % 9;
        button.Text = temp switch
        {
            1 => a.ToString(),
            2 => b.ToString(),
            3 => c.ToString(),
            4 => d.ToString(),
            5 => a.ToString().ToUpper(),
            6 => b.ToString().ToUpper(),
            7 => c.ToString().ToUpper(),
            8 => d.ToString().ToUpper(),
            0 => n.ToString(),
            _ => button.Text
        };
    }

    private string CalculateLetter(char a, char b, char c, char n)
    {
        var cl = clicks % 7;
        return cl switch
        {
            1 => a.ToString(),
            2 => b.ToString(),
            3 => c.ToString(),
            4 => a.ToString().ToUpper(),
            5 => b.ToString().ToUpper(),
            6 => c.ToString().ToUpper(),
            _ => n.ToString(),
        };
    }

    private string CalculateLetter(char a, char b, char c, char d, char n)
    {
        var cl = clicks % 9;
        return cl switch
        {
            1 => a.ToString(),
            2 => b.ToString(),
            3 => c.ToString(),
            4 => d.ToString(),
            5 => a.ToString().ToUpper(),
            6 => b.ToString().ToUpper(),
            7 => c.ToString().ToUpper(),
            8 => d.ToString().ToUpper(),
            _ => n.ToString()
        };
    }

    private void Btn_1_Clicked(System.Object sender, System.EventArgs e)
    {
        editor1.Text += "1";
    }

    private void Btn_2_Clicked(System.Object sender, System.EventArgs e)
    {
        ButtonClicked(Btn_2, 'a', 'b', 'c', '2');
    }

    private void Btn_3_Clicked(System.Object sender, System.EventArgs e)
    {
        ButtonClicked(Btn_3, 'd', 'e', 'f', '3');
    }

    private void Btn_4_Clicked(System.Object sender, System.EventArgs e)
    {
        ButtonClicked(Btn_4, 'g', 'h', 'i', '4');
    }

    private void Btn_5_Clicked(System.Object sender, System.EventArgs e)
    {
        ButtonClicked(Btn_5, 'j', 'k', 'l', '5');
    }

    private void Btn_6_Clicked(System.Object sender, System.EventArgs e)
    {
        ButtonClicked(Btn_6, 'm', 'n', 'o', '6');
    }

    private void Btn_7_Clicked(System.Object sender, System.EventArgs e)
    {
        ButtonClicked(Btn_7, 'p', 'q', 'r', 's', '7');
    }

    private void Btn_8_Clicked(System.Object sender, System.EventArgs e)
    {
        ButtonClicked(Btn_8, 't', 'u', 'v', '8');
    }

    private void Btn_9_Clicked(System.Object sender, System.EventArgs e)
    {
        ButtonClicked(Btn_9, 'w', 'x', 'y', 'z', '9');
    }

    void Btn_10_Clicked(System.Object sender, System.EventArgs e)
    {
        editor1.Text += "*";
    }

    void Btn_0_Clicked(System.Object sender, System.EventArgs e)
    {
        //ButtonClicked(Btn_0, " ", "0");
    }

    void Btn_11_Clicked(System.Object sender, System.EventArgs e)
    {
        editor1.Text += "#";
    }


    private void editor1_TextChanged(System.Object sender, Microsoft.Maui.Controls.TextChangedEventArgs e)
    {
    }
}