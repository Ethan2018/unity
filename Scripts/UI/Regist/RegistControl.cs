using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegistModel
{
    public string password;
    public string useName;
}

public class RegistLogic
{

}
public class RegistControl : UIBase {

    RegistModel registModel;
    RegistLogic registLogic;
    // Use this for initialization
    void Start () {
        registModel = new RegistModel();
        registLogic = new RegistLogic();

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
