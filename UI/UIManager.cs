using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {

    public static UIManager Instance; //模块的入口才能时单例

    //将Canvas存放在UIManager 只查找一次
    public Transform mainCanvas;
    public Transform MainCanvas
    {
        get
        {
            return mainCanvas;
        }
    }

    /// <summary>
    ///             panel                    控件的名字                                      树形结构
    /// </summary>
    Dictionary<string, Dictionary<string, GameObject>> allWidget;//以panel为单位保存

    public void RegistGameObject(string panelName, string widgetName, GameObject obj)
    {
        if (!allWidget.ContainsKey(panelName))
        {
            allWidget[panelName] = new Dictionary<string, GameObject>();
        }
        allWidget[panelName].Add(widgetName, obj);
    }
    /// <summary>
    /// 获取某一个panel下的子控件
    /// </summary>
    /// <param name="panelName"></param>
    /// <param name="widgetName"></param>
    /// <returns></returns>
    public GameObject GetGameObject(string panelName, string widgetName)
    {
        if (allWidget.ContainsKey(panelName))
        {
            return allWidget[panelName][widgetName];
        }
        return null;
    }

    #region destroy
    public void UnRegistGameObject(string panelName, string widgetName)
    {
        if (allWidget.ContainsKey(panelName))
        {
            if (allWidget[panelName].ContainsKey(widgetName)) 
            {
                allWidget[panelName].Remove(widgetName);
            }
        }
    }

    public void UnRegistPanel(string panelName)
    {
        if (allWidget.ContainsKey(panelName))
        {
            allWidget[panelName].Clear();
            allWidget[panelName] = null;
        }
    }
    #endregion
    void Awake()
    {
        Instance = this;
        allWidget = new Dictionary<string, Dictionary<string, GameObject>>();

        mainCanvas = GameObject.FindGameObjectWithTag("MainCanvas").transform;
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
