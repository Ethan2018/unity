using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BigAttackUILogic
{
    public BigAttackUILogic(Image tmpUpImage)
    {
        upImage = tmpUpImage;
    }
    public void OnClick(BaseEventData tmpData)
    {
        if (!IsClick)
        {
            timeCount = allCount;
            IsClick = true;
        }
       
    }
    float allCount = 3;
    float timeCount;
    Image upImage;
    bool IsClick = false;
    public void Update()
    {
        if (IsClick)
        {
            timeCount -= Time.deltaTime;
            upImage.fillAmount = timeCount / allCount;
            if (timeCount < 0)
            {
                IsClick = false;
            }
        }
    }
}

public class PlayerSkillCtrl : UIBase {

    EasyTouchDemoLogic easyTouchDemoLogic;
    
    public void BindEasyTouchEvent()
    {
        GameObject player = PlayerManager.Instance.GetPlayer.gameObject;
        GameObject downImage = GetWidget("DownImage_N");
        GameObject tmpOwner = GetWidget("DragImage_N");
        easyTouchDemoLogic = new EasyTouchDemoLogic(player, downImage, tmpOwner.transform);
        AddDrag("DragImage_N", easyTouchDemoLogic.OnDrag);
    }


    BigAttackUILogic bigAttackUILogic;
    public void BindBigAttackEvent()
    {
        Image tmpImage = GetImage("BigAttackOneUp_N");
        bigAttackUILogic = new BigAttackUILogic(tmpImage);
        AddPointerClick("BigAttackOne_N", bigAttackUILogic.OnClick);
    }



    // Use this for initialization
    void Start () {
        BindEasyTouchEvent();
        BindBigAttackEvent();
    }
	
	// Update is called once per frame
	void Update () {
        if (easyTouchDemoLogic != null)
        {
            easyTouchDemoLogic.Update();
        }
        if (bigAttackUILogic != null)
        {
            bigAttackUILogic.Update();
        }
    }
}
