using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestWWW : MonoBehaviour {

    public IEnumerator SendGet(string url)
    {
        //for(int i = 0; i < 1000; i++)
        //{
        //    yield return new WaitForSeconds(0.2f);
        //}
        WWW www = new WWW(url);
        yield return www;  //协程 将任务分片
        //判断下载是否有错误
        if(string.IsNullOrEmpty(www.error))
        {
            Debug.Log("finish==" + www.text);
        }
    }

    public IEnumerator SendPost(string url, WWWForm form)
    {
        WWW www = new WWW(url, form);
        yield return www; 
        if (string.IsNullOrEmpty(www.error))
        {
            Debug.Log("finish==" + www.text);
        }
    }


    public IEnumerator DownloadLocalFile(string url)
    {
        WWW www = new WWW(url);
        yield return www; 
        if (string.IsNullOrEmpty(www.error))
        {
            Debug.Log("finish==" + www.text);
        }

    }
    /// <summary>
    /// 根据不同的平台加前缀
    /// </summary>
    /// <param name="url"></param>
    /// <returns></returns>
    public string InitialUrl(string url)
    {
        if(Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer)
        {
            url = "file:///" + url;
        }
        else if (Application.platform == RuntimePlatform.Android)
        {
            url = "jar:file://" + url;
        }
        else
        {
            url = "file://" + url;
        }
        return url;
    }
    // Use this for initialization
    void Start () {
        //string url = "http://kun.show.ghostry.cn/?int=5";
        //StartCoroutine(SendGet(url)); //启动协程

        //string url = "http://kun.show.ghostry.cn/";
        //WWWForm tmpForm = new WWWForm();
        //tmpForm.AddField("int", 5); //参数 值
        //StartCoroutine(SendPost(url, tmpForm));

        string url = Application.dataPath + "/WWW/TestWWW.cs"; //下载本地资源   访问工程文件
        //iOS: File//    Andriod: Jar:file//    PC: File:///
        Debug.Log("11111=" + url);
        url = InitialUrl(url);
        Debug.Log("2222=" + url);
        StartCoroutine(DownloadLocalFile(url));


        //Application.persistentDataPath andriod: SD卡  IOS: Document PC: C:\Users\用户名\AppData 用文件系统可读可写 (File StreamReader StreamWriter)
        //Application.streamingAssetsPath 打包到真机 apk包（zip包）只能用www读 不能写
    }
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.A))
        {
            string url = Application.dataPath + "/WWW/TestWWW.cs";
            WWWTxt tmpText = new WWWTxt(url);
            WWWHelper.Instance.AddTask(tmpText);
        }
	}
}
