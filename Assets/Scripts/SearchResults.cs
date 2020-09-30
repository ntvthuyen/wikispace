using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchResults
{
    public string batchcomplete {get; set;}
    public Dictionary<string, string> Continue {get; set;}
    public Query query {get; set;} 
}
public class Query{
    public Dictionary<string, object> searchinfo;
    public List<Dictionary<string, object>> search;
}