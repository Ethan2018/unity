using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseAudio : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.A))
        {
            AudioManager.Instance.Play("UIMusic");
        }
        if(Input.GetKeyDown(KeyCode.B))
        {
            AudioManager.Instance.Stop("UIMusic");
        }

    }
}
