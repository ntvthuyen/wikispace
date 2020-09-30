using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * "batchcomplete": true,
    "warnings": {
        "extracts": {
            "warnings": "HTML may be malformed and/or unbalanced and may omit inline images. Use at your own risk. Known problems are listed at https://www.mediawiki.org/wiki/Special:MyLanguage/Extension:TextExtracts#Caveats."
        }
    },
    "query": {
        "pages": [
            {
                "pageid": 29812,
                "ns": 0,
                "title": "The Beatles",
                "extract": 
 */
public class PageContent
{
    public bool batchcomplete { get; set; }
    public object warnings { get; set; }
    public Dictionary<string,List<Dictionary<string, string>>> query { get; set; }
}
