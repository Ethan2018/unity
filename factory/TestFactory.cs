using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestFactory
{
    public TestFactory()
    {
        Initial();
    }

    Sprite[] allSprite;
    Transform parents;
    /// <summary>
    /// 加载资源
    /// </summary>
    public void Initial()
    {
        allSprite = Resources.LoadAll<Sprite>("MutiSprite");
        parents = GameObject.FindGameObjectWithTag("MainCanvas").transform;
    }
    /// <summary>
    /// 动态创建image
    /// </summary>
    /// <returns></returns>
    public GameObject CreateImage(int index, Vector3 postion)
    {
        //在内存中创建GameObject
        GameObject tmpObj = new GameObject();
        tmpObj.name = index.ToString();
        //设置parents
        tmpObj.transform.SetParent(parents, false);
        //tmpObj.transform.SetAsLastSibling();
        if(index > 2)
        {
            tmpObj.transform.SetSiblingIndex(2);
        }
        tmpObj.transform.localPosition = postion;
        //动态加载image
        Image tmpImage = tmpObj.AddComponent<Image>();
        index = index % allSprite.Length;
        tmpImage.sprite = allSprite[index];
        return tmpObj;
    }
}
