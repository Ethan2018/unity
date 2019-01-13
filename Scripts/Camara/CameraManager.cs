using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {

    private Transform target;
	// Use this for initialization
	void Start () {
        target = PlayerManager.Instance.GetPlayer;
	}
    //保持的距离
    public Vector3 distance = new Vector3(0.14f, 3.4f, -3.04f);
    public float smoothTime = 0.5f;
    //跟随速度
    private Vector3 velicity = Vector3.one;
	// Update is called once per frame
	void LateUpdate () {
        transform.position = Vector3.SmoothDamp(transform.position, target.position + distance, ref velicity, smoothTime);
	}
}
