using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LoadingControl : UIBase {

    public void OnClick()
    {

    }

    /// <summary>
    /// UnityAction public delegate void UnityAction<T0>(T0 arg0);   代理只关注返回值   参数
    /// </summary>
    /// <param name="eventData"></param>
    public void Drag(BaseEventData eventData)
    {
        PointerEventData tmpEventData = (PointerEventData)eventData; //, IDragHandler
        transform.position = tmpEventData.position;
    }

    // Use this for initialization
    void Start () {
        AddButtonListener("Button_N", OnClick);
        TextChanged("Text_N", "");

        AddDrag("", Drag);
        AddButtonListener("Cell_C", "Button_S", OnClick);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
