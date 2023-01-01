using System.Diagnostics;
using Backend;

namespace T9;

public partial class MainPage : ContentPage
{
    int count = 0;
    private Trie _trie;
    private readonly Stopwatch sw;
    private readonly IDispatcherTimer tr;
    private const string _URL = "https://toczekmj.github.io/wordlist.html";
    private int _clicks = 0;
    private Button _currentButton;
    private List<string> _dict;

    public MainPage()
    {
        InitializeComponent();
        InitializeTrie();
        sw = new Stopwatch();
        tr = Application.Current.Dispatcher.CreateTimer();
        tr.Interval = TimeSpan.FromMilliseconds(10);
        tr.Tick += (s, e) => CheckForLastLetter();
    }

    private async void InitializeTrie()
    {
        _trie = new Trie();
        await using var stream = await FileSystem.OpenAppPackageFileAsync("wordlist.txt");
        using var reader = new StreamReader(stream);
        var s = await reader.ReadToEndAsync();
        _dict = s.Split('\n').ToList();
        _trie.AddCollection(_dict);

    }

    private void CheckForLastLetter()
    {
        if (sw.IsRunning && sw.ElapsedMilliseconds > 1300)
        {
            sw.Stop();
            tr.Stop();
            string res;

            if (_currentButton == Btn_2)
            {
                res = CalculateLetter('a', 'b', 'c');
                Btn_2.Text = " (2) ABC";
            }
            else if (_currentButton == Btn_3)
            {
                res = CalculateLetter('d', 'e', 'f');
                Btn_3.Text = " (3) DEF";
            }
            else if (_currentButton == Btn_4)
            {
                res = CalculateLetter('g', 'h', 'i');
                Btn_4.Text = " (4) GHI";
            }
            else if (_currentButton == Btn_5)
            {
                res = CalculateLetter('j', 'k', 'l');
                Btn_5.Text = " (5) JKL";
            }
            else if (_currentButton == Btn_6)
            {
                res = CalculateLetter('m', 'n', 'o');
                Btn_6.Text = " (6) MNO";
            }
            else if (_currentButton == Btn_7)
            {
                res = CalculateLetter('p', 'q', 'r', 's');
                Btn_7.Text = " (7) PQRS";
            }
            else if (_currentButton == Btn_8)
            {
                res = CalculateLetter('t', 'u', 'v');
                Btn_8.Text = " (8) TUV";
            }
            else if (_currentButton == Btn_9)
            {
                res = CalculateLetter('w', 'x', 'y', 'z');
                Btn_9.Text = " (9) WXYZ";
            }
            else
            {
                res = "";
            }

            editor1.Text += res;
            _clicks = 0;
        }
    }


    private void ButtonClicked(Button button, char a, char b, char c)
    {
        if (sw.IsRunning)
        {
            if (sw.ElapsedMilliseconds > 1000)
            {
                sw.Stop();
                tr.Stop();
                var res = CalculateLetter(a, b, c);
                editor1.Text += res;
                _currentButton = button;
                _clicks = 0;
                button.Text = string.Join(a, b, c).ToUpper();
                return;
            }
            else
            {
                _clicks++;

                tr.Stop();
                sw.Restart();
                tr.Start();
            }
        }
        else
        {
            _currentButton = button;
            tr.Stop();
            sw.Restart();
            tr.Start();
            _clicks++;
        }

        SetButtonText(button, a, b, c);
    }

    private void ButtonClicked(Button button, char a, char b, char c, char d)
    {
        if (sw.IsRunning)
        {
            if (sw.ElapsedMilliseconds > 1000)
            {
                sw.Stop();
                tr.Stop();
                var res = CalculateLetter(a, b, c, d);
                editor1.Text += res;
                _currentButton = button;
                _clicks = 0;
                button.Text = string.Join(a, b, c, d).ToUpper();
                return;
            }

            _clicks++;
            tr.Stop();
            sw.Restart();
            tr.Start();
        }
        else
        {
            _currentButton = button;
            tr.Stop();
            sw.Restart();
            tr.Start();
            _clicks++;
        }

        SetButtonText(button, a, b, c, d);
    }

    private void SetButtonText(Button button, char a, char b, char c)
    {
        var temp = _clicks % 3;
        button.Text = temp switch
        {
            1 => a.ToString(),
            2 => b.ToString(),
            0 => c.ToString(),
            _ => button.Text
        };
    }

    private void SetButtonText(Button button, char a, char b, char c, char d)
    {
        var temp = _clicks % 4;
        button.Text = temp switch
        {
            1 => a.ToString(),
            2 => b.ToString(),
            3 => c.ToString(),
            0 => d.ToString(),
            _ => button.Text
        };
    }

    private string CalculateLetter(char a, char b, char c)
    {
        var cl = _clicks % 3;
        return cl switch
        {
            1 => a.ToString(),
            2 => b.ToString(),
            _ => c.ToString(),
        };
    }

    private string CalculateLetter(char a, char b, char c, char d)
    {
        var cl = _clicks % 4;
        return cl switch
        {
            1 => a.ToString(),
            2 => b.ToString(),
            3 => c.ToString(),
            _ => d.ToString(),
        };
    }

    private void Btn_1_Clicked(System.Object sender, System.EventArgs e)
    {
        editor1.Text += "1";
    }

    private void Btn_2_Clicked(System.Object sender, System.EventArgs e)
    {
        ButtonClicked(Btn_2, 'a', 'b', 'c');
    }

    private void Btn_3_Clicked(System.Object sender, System.EventArgs e)
    {
        ButtonClicked(Btn_3, 'd', 'e', 'f');
    }

    private void Btn_4_Clicked(System.Object sender, System.EventArgs e)
    {
        ButtonClicked(Btn_4, 'g', 'h', 'i');
    }

    private void Btn_5_Clicked(System.Object sender, System.EventArgs e)
    {
        ButtonClicked(Btn_5, 'j', 'k', 'l');
    }

    private void Btn_6_Clicked(System.Object sender, System.EventArgs e)
    {
        ButtonClicked(Btn_6, 'm', 'n', 'o');
    }

    private void Btn_7_Clicked(System.Object sender, System.EventArgs e)
    {
        ButtonClicked(Btn_7, 'p', 'q', 'r', 's');
    }

    private void Btn_8_Clicked(System.Object sender, System.EventArgs e)
    {
        ButtonClicked(Btn_8, 't', 'u', 'v');
    }

    private void Btn_9_Clicked(System.Object sender, System.EventArgs e)
    {
        ButtonClicked(Btn_9, 'w', 'x', 'y', 'z');
    }

    void Btn_10_Clicked(System.Object sender, System.EventArgs e)
    {
        editor1.Text += "*";
    }

    private void Btn_0_Clicked(System.Object sender, System.EventArgs e)
    {
        //ButtonClicked(Btn_0, " ", "0");
       

    }

    void Btn_11_Clicked(System.Object sender, System.EventArgs e)
    {
        editor1.Text += "#";
    }

    private async void editor1_TextChanged(System.Object sender, Microsoft.Maui.Controls.TextChangedEventArgs e)
    {
        Console.WriteLine($"Text changed: {editor1.Text}");
        if(string.IsNullOrEmpty(editor1.Text))
            return;
        
        
        var lastword = editor1.Text.Split(' ').Last();
        var suggestions = _trie.GetSuggestions(lastword);
        triePreview.Text = "";
        foreach (var word in suggestions)
        {
            triePreview.Text += $"{word}\n";
        }
        Console.WriteLine();

    }
}