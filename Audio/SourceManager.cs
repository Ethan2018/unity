using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SourceManager  {

    public SourceManager(GameObject tmpOwner)
    {
        owner = tmpOwner;
        Initial();
    }

    List<AudioSource> allSources;
    GameObject owner;
    /// <summary>
    /// 
    /// </summary>
    public void Initial()
    {
        allSources = new List<AudioSource>();
        for(int i = 0; i < 3; i++)
        {
            AudioSource tmpSource = owner.AddComponent<AudioSource>(); //对象身上挂载组件(功能)
            allSources.Add(tmpSource);
        }
    }
    public AudioSource GetFreeAudio()
    {
        for(int i = 0; i < allSources.Count; i++)
        {
            if(!allSources[i].isPlaying)
            {
                return allSources[i];
            }
        }
        AudioSource tmpSource = owner.AddComponent<AudioSource>();
        allSources.Add(tmpSource);
        return tmpSource;
    }

    public void Stop(string audioName)
    {
        for (int i = 0; i < allSources.Count; i++)
        {
            if(allSources[i].isPlaying && allSources[i].clip.name.Equals(audioName))
            {
                allSources[i].Stop();
            }
        }
    }


    /// <summary>
    /// 释放多余的AudioSource
    /// </summary>
    public void ReleaseFreeAudio()
    {
        int tmpCount = 0;
        List<AudioSource> tmpSources = new List<AudioSource>(); //将要删的东西存起来(删数组的东西用这种方式)
        for (int i = 0; i < allSources.Count; i++)
        {
            if(!allSources[i].isPlaying)
            {
                tmpCount++;
                if (tmpCount > 3) //遍历时不能删 //System.GC.Collect();
                {
                    //allSources.RemoveAt(i);
                    tmpSources.Add(allSources[i]);
                }
            }
        }
        for (int i = 0; i < tmpSources.Count; i++)
        {
            AudioSource tmpSource = tmpSources[i];
            allSources.Remove(tmpSource);
            //场景中移除组件
            GameObject.Destroy(tmpSource);
        }
        tmpSources.Clear();
        tmpSources = null;
    }
}
