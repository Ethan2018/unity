using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TestSingleTwo
{
    private static TestSingleTwo instance;
    public static TestSingleTwo Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new TestSingleTwo();  
            }
            return instance;
        }
    }
    public void ShowMe()
    {

    }
}


public class TestSingle : MonoBehaviour { //只能挂 不能new

    // Use this for initialization

    public static TestSingle Instance; //全局变量 用在组织框架的管理者
    private void Awake()
    {
        Instance = this;
    }
    void Start () {

        TestSingleTwo.Instance.ShowMe();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
