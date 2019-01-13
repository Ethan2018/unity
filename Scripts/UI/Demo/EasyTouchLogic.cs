using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EasyTouchDemoLogic
{

    public EasyTouchDemoLogic()
    {

    }
    public EasyTouchDemoLogic(GameObject tmpTarget, GameObject tmpDown, Transform tmpOwner)
    {
        this.target = tmpTarget;
        this.downImage = tmpDown;
        this.owner = tmpOwner;
    }

    public float radius = 100;
    public float speed = 6;
    private GameObject target;
    public GameObject Target
    {
        set
        {
            target = value;
        }
    }
    private GameObject downImage;
    public GameObject DownImage
    {
        set
        {
            target = value;
        }
    }
    private Transform owner;
    public Transform Owner
    {
        set
        {
            owner = value;
        }
    }

    public void OnDrag(BaseEventData eventData)
    {

        PointerEventData tmpData = (PointerEventData)eventData;
        Vector2 deltaPos = tmpData.position - (Vector2)downImage.transform.position;
        if (deltaPos.magnitude < radius)
        {
            //小于半径可以任意移动
            owner.position = tmpData.position;
        }
        else
        {
            //                          初始化的世界位置
            owner.position = (Vector2)downImage.transform.position + deltaPos.normalized * radius;


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

    public void Update()
    {
        downImage.transform.position = Vector3.Lerp(downImage.transform.position, owner.position, Time.deltaTime * speed);
    }
}
