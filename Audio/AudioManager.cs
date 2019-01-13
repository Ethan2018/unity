using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public static AudioManager Instance;

    SourceManager sourceManager;
    ClipManager clipManager;
	// Use this for initialization
	void Start () {
        Instance = this;
        sourceManager = new SourceManager(gameObject); //挂载在谁身上就把谁传递进去
        clipManager = new ClipManager();
	}
	
    public void Play(string audioName)
    {
        //拿一个空闲的AudioSource
        AudioSource tmpSource = sourceManager.GetFreeAudio();
        //找到clip
        SingleClip tmpClips = clipManager.FindClipByName(audioName);

        if(tmpClips != null)
        {
            //两个结合
            tmpClips.Play(tmpSource);
        }
       
    }

    public void Stop(string audioName)
    {
        sourceManager.Stop(audioName);
    }
	// Update is called once per frame
	void Update () {
		
	}
}
