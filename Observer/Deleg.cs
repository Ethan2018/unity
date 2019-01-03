using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class Deleg : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Button btn = transform.GetComponent<Button>();
        //分配的空间在堆上
        btn.onClick.AddListener(new UnityAction(OnClick));    //指向方法的指针
        //分配的空间在栈上
        btn.onClick.AddListener(OnClick);

    }
    public void OnClick()
    {
        Debug.Log("On Click");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
