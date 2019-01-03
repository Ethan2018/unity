using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseFactory : MonoBehaviour {


    TestFactory myFactory;
	// Use this for initialization
	void Start () {
        myFactory = new TestFactory();
	}
    int tmpCount = 0;
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space))
        {
            tmpCount++;
            myFactory.CreateImage(tmpCount, Vector3.one * tmpCount * 50);
        }
	}
}
