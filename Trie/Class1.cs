using System.Diagnostics;
using System.Net;

namespace Backend;
public class Trie
{
    public Trie()
    {
        //DownloadDictionary();
    }

    //private async void DownloadDictionary()
    //{
    //    List<string> dict = new List<string>();
    //    try
    //    {
    //        var url = "https://www.mit.edu/~ecprice/wordlist.10000";
    //        HttpClient client = new HttpClient();

    //        using (HttpResponseMessage response = await client.GetAsync(url))
    //        {
    //            using (HttpContent content = response.Content)
    //            {
    //                var text = await content.ReadAsStringAsync();
    //                dict = text.Split('\n').ToList<string>();
    //            }
    //        }

    //    }
    //    catch (Exception ex)
    //    {
    //        Debug.WriteLine(ex.Message);
    //    }
    //}

    public void InitializeTree(string path)
    {

    }

    private Dictionary<char, string[]> _keyboard = new Dictionary<char, string[]>
    {
        {'2', new string[] {"a", "b", "c"} },
        {'3', new string[] {"d", "e", "f"} },
        {'4', new string[] {"g", "h", "i"} },
        {'5', new string[] {"j", "k", "l"} },
        {'6', new string[] {"m", "n", "o"} },
        {'7', new string[] {"p", "q", "r", "s"} },
        {'8', new string[] {"t", "u", "v"} },
        {'9', new string[] {"w", "x", "y", "z"} }
    };

    


}

