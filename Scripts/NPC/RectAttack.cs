using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RectAttack : MonoBehaviour {


    public bool RectAttackJudge(Transform attacker, Transform attacked, float forwardDis, float rightDis)
    {
        Vector3 deltaA = attacked.position - attacker.position;
        float forwardShadow = Vector3.Dot(attacker.forward, deltaA);
        if (forwardShadow > 0 && forwardShadow <= forwardDis)
        {
            if (Mathf.Abs(Vector3.Dot(attacker.right, deltaA)) < rightDis)
            {
                return true;
            }
        }
        return false;
    }
    //NPC坐标系先变换到Player坐标系



    public bool UmbrellaAttack(Transform attacker, Transform attacked, float angle, float radius)
    {
        Vector3 deltaA = attacked.position - attacker.position;
        float tmpAngle = Mathf.Acos(Vector3.Dot(deltaA.normalized, attacker.forward)) * Mathf.Rad2Deg;
        if (tmpAngle < angle * 0.5f && deltaA.magnitude < radius)
        {
            return true;
        }
        return false;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
