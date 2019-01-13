using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WWWHelper : MonoBehaviour {

    public static WWWHelper Instance;
    Queue<WWWItem> allTask;
	// Use this for initialization
	void Start () {
        Instance = this;
        allTask = new Queue<WWWItem>();
	}
    bool IsDownloadingFinish = true;
	public void AddTask(WWWItem item)
    {
        allTask.Enqueue(item);
        if(allTask.Count == 1 && IsDownloadingFinish)
        {
            IsDownloadingFinish = false;
            StartCoroutine(DownloadItem());
        }
    }
    public IEnumerator DownloadItem()
    {
        while(allTask.Count > 0)
        {
            WWWItem item = allTask.Dequeue();
            //相当于for循环套用for循环
            yield return item.Download();
        }
        IsDownloadingFinish = true;
    }
	// Update is called once per frame
	void Update () {
		
	}
}
