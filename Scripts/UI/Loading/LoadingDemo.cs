using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LoadingDemoModel
{
    private string userName;
    public string UserName
    {
        get
        {
            return userName;
        }
        set
        {
            userName = value;
        }
    }
    private string passWord;
    public string PassWord
    {
        get
        {
            return passWord;
        }
        set
        {
            passWord = value;
        }
    }
}

public class LoadingDemoLogic
{
    LoadingDemoModel loadModel;
    LoadingDemo loadingDemo;


    public LoadingDemoLogic(LoadingDemoModel model, LoadingDemo demo)
    {
        loadModel = model;

        loadingDemo = demo;
    }
    public void GetUserName(string data)
    {
        loadModel.UserName = data;
        Debug.Log(data);
    }
    public void GetPassWord(string data)
    {
        loadModel.PassWord = data;
    }

    public void LoadingClick()
    {
        Debug.Log("loading click");
        //从网络请求用户名和密码是否正确
        //从本地数据查询
    }
    public void RegistClick()
    {
        ////弹出注册界面
        //Object tmpObj = Resources.Load("UI/Regist/Regist");
        ////实例化panel到场景
        //GameObject registPanel = GameObject.Instantiate(tmpObj) as GameObject;
        //registPanel.name = registPanel.name.Replace("(Clone)", "");


        //Transform mainCanvas = loadingDemo.GetCanvas();
        ////设置父类
        //registPanel.transform.SetParent(mainCanvas, false);


        GameObject registPanel = loadingDemo.InitialPanel("UI/Regist/Regist");
        //给注册panel添加控制层
        registPanel.AddComponent<RegistDemo>();
        //登陆界面隐藏
        loadingDemo.HideSelf();
    }
}



//事件绑定层
public class LoadingDemo : UIBase {

    LoadingDemoModel loadingModel;
    LoadingDemoLogic loadingLogic;


    public void HideSelf()
    {
        GameObject root = GetWidget("Root_N");
        root.SetActive(false);
    }




    public void BindEvent()
    {
        AddInputFieldListener("UserName_N", new UnityAction<string>(loadingLogic.GetUserName));
        AddInputFieldListener("PassWord_N", new UnityAction<string>(loadingLogic.GetUserName));
        AddButtonListener("Loading_N", new UnityAction(loadingLogic.LoadingClick));
        AddButtonListener("Regist_N", new UnityAction(loadingLogic.RegistClick));
    }


	// Use this for initialization
	void Start () {
        loadingModel = new LoadingDemoModel();
        loadingLogic = new LoadingDemoLogic(loadingModel, this);
        BindEvent();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
