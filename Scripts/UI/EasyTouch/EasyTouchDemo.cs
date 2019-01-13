using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//类默认的权限是private
public class EasyTouchDemo : MonoBehaviour, IDragHandler {
    //接口默认权限是public 实现也必须是public
    public void OnDrag(PointerEventData eventData)
    {
        //相对位置
        Vector2 deltaPos = eventData.position - originPos;
        if (deltaPos.magnitude < radius)
        {
            //小于半径可以任意移动
            transform.position = eventData.position;
        }
        else
        {
            //                          初始化的世界位置
            transform.position = originPos + deltaPos.normalized*radius;


            float myAngle = Mathf.Atan2(deltaPos.y, deltaPos.x) * Mathf.Rad2Deg;



            if (target != null)
            {
                //不能修饰的值 用中间变量接收然后赋值回去
                Vector3 tmpAngle = target.transform.localEulerAngles;
                tmpAngle.y = 90 - myAngle;
                target.transform.localEulerAngles = tmpAngle;
            }
        
        }
    }


    Vector2 originPos; //值类型 重新分配了一块空间 要是引用类型就无法记录
    public float radius = 100;

    public GameObject target;
    public GameObject downImage;

    // Use this for initialization
    void Start () {
        originPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
       

    }
}
