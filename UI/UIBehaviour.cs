using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class UIBehaviour : MonoBehaviour {

    void Awake()
    {
        UIBase tmpBase = transform.GetComponentInParent<UIBase>();
        //将自己注册到UIManager中去
        UIManager.Instance.RegistGameObject(tmpBase.name, transform.name, gameObject);
    }

    public void AddButtonListener(UnityAction action)
    {
        Button tmpBtn = transform.GetComponent<Button>();
        if (tmpBtn != null)
        {
            tmpBtn.onClick.AddListener(action);
        }
    }
    public void AddSliderListener(UnityAction<float> action)
    {
        Slider tmpSlider = transform.GetComponent<Slider>();
        if (tmpSlider != null)
        {
            tmpSlider.onValueChanged.AddListener(action);
        }
    }

    public void AddInputFieldEndEditListener(UnityAction<string> action)
    {
        InputField tmpInputField = transform.GetComponent<InputField>();
        if (tmpInputField != null)
        {
            tmpInputField.onEndEdit.AddListener(action);
        }
    }

    public void AddInputFieldValueChangedListener(UnityAction<string> action)
    {
        InputField tmpInputField = transform.GetComponent<InputField>();
        if (tmpInputField != null)
        {
            tmpInputField.onValueChanged.AddListener(action);
        }
    }

    public void TextChanged(string content)
    {
        Text tmpText = transform.GetComponent<Text>();
        if (tmpText != null)
        {
            tmpText.text = content;
        }
    }
    public void ImageChanged(Sprite content)
    {
        Image tmpImage = transform.GetComponent<Image>();
        if (tmpImage != null)
        {
            tmpImage.sprite = content;
        }
    }


    public Image GetImage()
    {
        Image tmpImage = transform.GetComponent<Image>();
        return tmpImage;
    }
    /// <summary>
    /// 动态添加接口事件
    /// </summary>
    public void AddDragInterface(UnityAction<BaseEventData> action)
    {
        //获取事件系统
        EventTrigger trigger = gameObject.GetComponent<EventTrigger>();
        if (trigger == null)
        {
            trigger = gameObject.AddComponent<EventTrigger>(); //动态添加
        }
        //事件实体
        EventTrigger.Entry entry = new EventTrigger.Entry();
        //事件类型
        entry.eventID = EventTriggerType.Drag; //接口事件
        //代理
        entry.callback = new EventTrigger.TriggerEvent();
        //添加回调函数
        entry.callback.AddListener(action);
        //将事件添加到监听队列中
        trigger.triggers.Add(entry);
    }
    //public void OnBeginDrag() { }
    public void AddPointerClick(UnityAction<BaseEventData> action) {
        EventTrigger trigger = gameObject.GetComponent<EventTrigger>();
        if (trigger == null)
        {
            trigger = gameObject.AddComponent<EventTrigger>(); //动态添加
        }
        //事件实体
        EventTrigger.Entry entry = new EventTrigger.Entry();
        //事件类型
        entry.eventID = EventTriggerType.PointerClick; //接口事件
        //代理
        entry.callback = new EventTrigger.TriggerEvent();
        //添加回调函数
        entry.callback.AddListener(action);
        //将事件添加到监听队列中
        trigger.triggers.Add(entry);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
