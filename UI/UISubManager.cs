using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UISubManager : MonoBehaviour {

    Dictionary<string, Transform> allChildren;
    void Awake()
    {
        UIBase tmpBase = transform.GetComponentInParent<UIBase>();
        UIManager.Instance.RegistGameObject(tmpBase.name, transform.name, gameObject); //将cell注册到UIManager
        allChildren = new Dictionary<string, Transform>();
        //将所有的子控件存到allChildren
        Transform[] tmpChildren = transform.GetComponentsInChildren<Transform>();
        for (int i = 0; i < tmpChildren.Length; i++)
        {
            if (tmpChildren[i].name.EndsWith("_S"))
            {
                allChildren.Add(tmpChildren[i].name, tmpChildren[i]);
            }
        }
    }

    //根据名字获取子控件
    public Transform GetChildrenTransform(string wedgetName)
    {
        return allChildren[wedgetName];
    }

    //提供销毁接口
    void OnDestroy()
    {
        if (allChildren != null)
        {
            allChildren.Clear();
            allChildren = null;
        }
    }

    public void AddButtonListener(string wedgetName, UnityAction action)
    {
        //根据名字找到子控件的transform
        Transform tmpTransform = GetChildrenTransform(wedgetName);
        //从子控件身上获取Button组件
        Button tmpBtn = tmpTransform.GetComponent<Button>();
        if (tmpBtn != null)
        {
            tmpBtn.onClick.AddListener(action);
        }
    }



    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
