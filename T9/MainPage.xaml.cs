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

            if(current_button == Btn_1)
            {
                res = "";
            }
            else if (current_button == Btn_2)
            {
                res = calculateLetter('a', 'b', 'c');
                Btn_2.Text = "ABC";
            }
            else if (current_button == Btn_3)
            {
                res = calculateLetter('d', 'e', 'f');
                Btn_3.Text = "DEF";
            }
            else if (current_button == Btn_4)
            {
                res = calculateLetter('g', 'h', 'i');
                Btn_4.Text = "GHI";
            }
            else if (current_button == Btn_5)
            {
                res = calculateLetter('j', 'k', 'l');
                Btn_5.Text = "JKL";
            }
            else if (current_button == Btn_6)
            {
                res = calculateLetter('m', 'n', 'o');
                Btn_6.Text = "MNO";
            }
            else if (current_button == Btn_7)
            {
                res = calculateLetter('p', 'q', 'r', 's');
                Btn_7.Text = "PQRS";
            }
            else if (current_button == Btn_8)
            {
                res = calculateLetter('t', 'u', 'v');
                Btn_8.Text = "TUV";
            }
            else if(current_button == Btn_9)
            {
                res = calculateLetter('w', 'x', 'y', 'z');
                Btn_9.Text = "WXYZ";
            }
            else
            {
                res = "";
            }
            
            
            label1.Text = clicks.ToString();

            editor1.Text += res;
            clicks = 0;
        }
    }

    

    private void ButtonClicked(Button button, char a, char b, char c)
    {
        if (sw.IsRunning) //kolejne klikniecie
        {
            if (sw.ElapsedMilliseconds > 1000) //KONIEC
            {
                sw.Stop();
                tr.Stop();
                var res = calculateLetter(a, b, c);
                editor1.Text += res;
                current_button = button;
                clicks = 0;
                button.Text = string.Join(a, b, c).ToUpper();
                label1.Text = clicks.ToString();
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
        else //pierewsze klikniecie 
        {
            current_button = button;
            tr.Stop();
            sw.Restart();
            tr.Start();
            clicks++;

        }
        setButtonText(button, a, b, c);
        label1.Text = clicks.ToString();
    }

    private void ButtonClicked(Button button, char a, char b, char c, char d)
    {
        if (sw.IsRunning) //kolejne klikniecie
        {
            if (sw.ElapsedMilliseconds > 1000) //KONIEC
            {
                sw.Stop();
                tr.Stop();
                var res = calculateLetter(a, b, c, d);
                editor1.Text += res;
                current_button = button;
                clicks = 0;
                button.Text = string.Join(a, b, c, d).ToUpper();
                label1.Text = clicks.ToString();
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
        else //pierewsze klikniecie 
        {
            current_button = button;
            tr.Stop();
            sw.Restart();
            tr.Start();
            clicks++;

        }
        setButtonText(button, a, b, c, d);
        label1.Text = clicks.ToString();
    }

    private void setButtonText(Button button, char a, char b, char c)
    {
        var temp = clicks % 3;
        if (temp == 1) button.Text = a.ToString();
        else if (temp == 2) button.Text = b.ToString();
        else if (temp == 0) button.Text = c.ToString();
    }

    private void setButtonText(Button button, char a, char b, char c, char d)
    {
        var temp = clicks % 4;
        if (temp == 1) button.Text = a.ToString();
        else if (temp == 2) button.Text = b.ToString();
        else if (temp == 3) button.Text = c.ToString();
        else if (temp == 0) button.Text = d.ToString();
    }

    private string calculateLetter(char a, char b, char c)
    {
        var cl = clicks % 3;
        if (cl == 1) return a.ToString();
        if (cl == 2) return b.ToString();
        return c.ToString();
    }

    private string calculateLetter(char a, char b, char c, char d)
    {
        var cl = clicks % 4;
        if (cl == 1) return a.ToString();
        if (cl == 2) return b.ToString();
        if (cl == 3) return c.ToString();
        return d.ToString();
    }

    void Btn_1_Clicked(System.Object sender, System.EventArgs e)
    {
        editor1.Text += " ";
    }

    void Btn_2_Clicked(System.Object sender, System.EventArgs e)
    {
        ButtonClicked(Btn_2, 'a', 'b', 'c');
    }

    void Btn_3_Clicked(System.Object sender, System.EventArgs e)
    {
        ButtonClicked(Btn_3, 'd', 'e', 'f');
    }

    void Btn_4_Clicked(System.Object sender, System.EventArgs e)
    {
        ButtonClicked(Btn_4, 'g', 'h', 'i');
    }

    void Btn_5_Clicked(System.Object sender, System.EventArgs e)
    {
        ButtonClicked(Btn_5, 'j', 'k', 'l');
    }

    void Btn_6_Clicked(System.Object sender, System.EventArgs e)
    {
        ButtonClicked(Btn_6, 'm', 'n', 'o');
    }

    void Btn_7_Clicked(System.Object sender, System.EventArgs e)
    {
        ButtonClicked(Btn_7, 'p', 'q', 'r', 's');
    }

    void Btn_8_Clicked(System.Object sender, System.EventArgs e)
    {
        ButtonClicked(Btn_8, 't', 'u', 'v');
    }

    void Btn_9_Clicked(System.Object sender, System.EventArgs e)
    {
        ButtonClicked(Btn_9, 'w', 'x', 'y', 'z');
    }

    void editor1_TextChanged(System.Object sender, Microsoft.Maui.Controls.TextChangedEventArgs e)
    {

    }
}


