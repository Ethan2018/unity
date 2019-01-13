using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WWWTxt : WWWItem {

    public WWWTxt(string url)
    {
        Initial(url);
    }
    public void Initial(string url)
    {
        if(Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer)
        {
            this.URL = "file:///" + url;
        }
        else if (Application.platform == RuntimePlatform.Android)
        {
            this.URL = "jar:file://" + url;
        }
        else
        {
            this.URL = "file://" + url;
        }
    }
    public override void BeginDownload()
    {
        Debug.Log("");
    }
    public override void DownloadFinish(WWW www)
    {
        Debug.Log("");
        //解析 解压
    }
    public override void DownloadError(WWWItem tmpItem)
    {
        WWWHelper.Instance.AddTask(tmpItem);
    }
}
