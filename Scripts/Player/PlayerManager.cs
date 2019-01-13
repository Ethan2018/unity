using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    public static PlayerManager Instance;
    public Transform GetPlayer
    {
        get
        {
            return transform;
        }
    }
    private void Awake()
    {
        Instance = this;
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
