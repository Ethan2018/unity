using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittleMap : MonoBehaviour {

    public Transform player;
    public Terrain terrain;
    RectTransform parentRect;
    // Use this for initialization
    void Start () {
        parentRect = transform.parent.GetComponent<RectTransform>();
    }

    float tmpRateX;
    float tmpRateY;
    Vector2 result = Vector2.zero;
    Vector3 deltaPos;

    float timeCount = 0;
    // Update is called once per frame
    void Update () {
        timeCount += Time.deltaTime;
        if (timeCount > 0.5f)
        {
            timeCount = 0;
            deltaPos = player.position - terrain.transform.position;
            tmpRateX = deltaPos.x / terrain.terrainData.size.x;
            tmpRateY = deltaPos.z / terrain.terrainData.size.z;


            result.x = parentRect.sizeDelta.x * tmpRateX;
            result.y = parentRect.sizeDelta.y * tmpRateY;
            transform.localPosition = result;   //相对于父类的
        }
    }
}
