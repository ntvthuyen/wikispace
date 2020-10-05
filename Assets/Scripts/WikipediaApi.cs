using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.IO;
using TMPro;
using Newtonsoft.Json;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;
using Coffee.UIEffects;

public class WikipediaApi : MonoBehaviour
{
    public SearchResults searchResults;
    public PageContent pageContent;
    public List<TextMeshPro> texts;
    const string APIUrl = "https://en.wikipedia.org/w/api.php";

    const string ParseAction = "?action=query&format=json&prop=extracts&formatversion=2&titles=";

    const string GetImage = "?action=query&format=json&prop=images&formatversion=2&titles=";
    
    const string SearchAction = "?action=query&format=json&list=search&srsearch=";
    static public string Search(string keywords)
    {
        string html = string.Empty;
        string url = APIUrl + SearchAction + keywords;
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        request.AutomaticDecompression = DecompressionMethods.GZip;

        using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
        using (Stream stream = response.GetResponseStream())
        using (StreamReader reader = new StreamReader(stream))
        {
            html = reader.ReadToEnd();
        }

        return html;
    }
    static public string PageContent(string title)
    {
        string html = string.Empty;
        string url = APIUrl + ParseAction + title;
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        request.AutomaticDecompression = DecompressionMethods.GZip;

        using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
        using (Stream stream = response.GetResponseStream())
        using (StreamReader reader = new StreamReader(stream))
        {
            html = reader.ReadToEnd();
        }
        return html;
    }
    static public IEnumerator ShowResults(string query, List<Text> texts, List<GameObject> buttons)
    {
        foreach (var button in buttons) {
            button.SetActive(false);
        }
        string json = Search(query);
        Debug.Log(json);
        var values = JsonConvert.DeserializeObject<SearchResults>(json);
        int i = 0;
        foreach(var result in values.query.search){
            buttons[i].SetActive(true);
            texts[i].text = (string)result["title"];
            buttons[i].GetComponent<UIDissolve>().Play();
            ++i;
            yield return new WaitForSeconds(1);
        }
    }
}
