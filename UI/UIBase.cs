using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class UIBase : MonoBehaviour {

     void Awake()
    {
        //panel身上用到的子控件上加UIBehaviour
        Transform[] allChildren = transform.GetComponentsInChildren<Transform>();
        for (int i = 0; i < allChildren.Length; i++)
        {
            if (allChildren[i].name.EndsWith("_N"))
            {
                allChildren[i].gameObject.AddComponent<UIBehaviour>();
            }
            if (allChildren[i].name.EndsWith("_C"))
            {
                allChildren[i].gameObject.AddComponent<UISubManager>();
            }
        }
    }

    public void AddButtonListener(string cellName, string widgetName, UnityAction action)
    {
        UISubManager tmpSub = GetSubManager(cellName);
        if (tmpSub != null)
        {
            tmpSub.AddButtonListener(widgetName, action);
        }
    }
    
    public UISubManager GetSubManager(string cellName)
    {
        GameObject tmpObj = GetWidget(cellName);
        if (tmpObj != null)
        {
            return tmpObj.GetComponent<UISubManager>();
        }
        return null;
    }


    public GameObject GetWidget(string widgetName)
    {
        return UIManager.Instance.GetGameObject(transform.name, widgetName);
    }
    public UIBehaviour GetBehaviour(string widgetName)
    {
        GameObject tmpObj = GetWidget(widgetName);
        if (tmpObj != null)
        {
            return tmpObj.GetComponent<UIBehaviour>();
        }
        return null;
    }

    public void AddButtonListener(string widgetName, UnityAction action)
    {
        UIBehaviour tmpBehaviour = GetBehaviour(widgetName);
        if (tmpBehaviour != null)
        {
            tmpBehaviour.AddButtonListener(action);
        }
    }


    public void AddInputFieldListener(string widgetName, UnityAction<string> action)
    {
        UIBehaviour tmpBehaviour = GetBehaviour(widgetName);
        if (tmpBehaviour != null)
        {
            tmpBehaviour.AddInputFieldEndEditListener(action);
        }
    }


    public void TextChanged(string widgetName, string content)
    {
        UIBehaviour tmpBehaviour = GetBehaviour(widgetName);
        if (tmpBehaviour != null)
        {
            tmpBehaviour.TextChanged(content);
        }
    }

    public void AddDrag(string widgetName, UnityAction<BaseEventData> action)
    {
        UIBehaviour tmpBehaviour = GetBehaviour(widgetName);
        if (tmpBehaviour != null)
        {
            tmpBehaviour.AddDragInterface(action);
        }
    }
    public void AddPointerClick(string widgetName, UnityAction<BaseEventData> action)
    {
        UIBehaviour tmpBehaviour = GetBehaviour(widgetName);
        if (tmpBehaviour != null)
        {
            tmpBehaviour.AddPointerClick(action);
        }
    }

    public Image GetImage(string widgetName)
    {
        UIBehaviour tmpBehaviour = GetBehaviour(widgetName);
        if (tmpBehaviour != null)
        {
            tmpBehaviour.GetImage();
        }
        return null;
    }


    void OnDestroy()
    {
        UIManager.Instance.UnRegistPanel(transform.name);
    }

    #region 获取Canvas

    public Transform GetCanvas()
    {
        return UIManager.Instance.MainCanvas;
    }
    #endregion


    public GameObject InitialPanel(string panelPath)
    {
        //弹出注册界面
        Object tmpObj = Resources.Load(panelPath);
        //实例化panel到场景
        GameObject panelObj = GameObject.Instantiate(tmpObj) as GameObject;
        panelObj.name = panelObj.name.Replace("(Clone)", "");


        Transform mainCanvas = GetCanvas();
        //设置父类
        panelObj.transform.SetParent(mainCanvas, false);
        return panelObj;
    }


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
