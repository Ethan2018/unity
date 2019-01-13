using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WWWItem
{
    public virtual void BeginDownload(){}
    public virtual void DownloadFinish(WWW www) { } //只做抽象
    public virtual void DownloadError(WWWItem tmpItem) { }
    private string url;
    public string URL
    {
        get
        {
            return url;
        }
        set
        {
            url = value;
        }
    }
    public IEnumerator Download()
    {
        BeginDownload();
        WWW www = new WWW(URL);
        yield return www;
        if(string.IsNullOrEmpty(www.error))
        {
            DownloadFinish(www);
        }
        else
        {
            DownloadError(this);
        }
    }
}

