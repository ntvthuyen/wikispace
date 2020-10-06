using System.Collections;
using System.Collections.Generic;
using System.Security;
using UnityEngine;

public class ImageList
{

    public struct QueryObject
    {
        public struct Pages {
            public string pageId { get; set; }
            public string ns { get; set; }
            public string title { get; set; }
            public List<Dictionary<string, string>> images { get; set; }
        }
        public List<Pages> pages; 
    }
    public Dictionary<string, object> _continue { get; set; }
    public QueryObject query { get; set; }
}
