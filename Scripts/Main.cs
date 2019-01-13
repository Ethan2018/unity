using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour {


    //public static Main Instance;

    //public UIManager uIManager;
    /// <summary>
    /// 启动组织框架
    /// </summary>
    private void Awake()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.AddComponent<PlayerManager>();
        Camera.main.gameObject.AddComponent<UIManager>();
        //Instance = this;
        gameObject.AddComponent<UIManager>();
        gameObject.AddComponent<WWWHelper>();
        gameObject.AddComponent<AudioManager>();
        gameObject.AddComponent<NPCManager>();
        
        //跨场景也不能销毁
        DontDestroyOnLoad(gameObject);
    }
    // Use this for initialization
    void Start () {
		//Main.Instance.uIManager.
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
