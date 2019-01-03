using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleBase
{
    public Transform ower;
    public float bloodCount;
    public virtual void ReduceBlood(float reduce)
    {
        bloodCount -= reduce;
    }
}
public class MiddleNPC : MiddleBase
{
    public override void ReduceBlood(float reduce)
    {
        bloodCount -= reduce * 3;
    }
}
public class MiddlePlayer : MiddleBase
{

}
public class TestInterMediator : MonoBehaviour {

    public void CaculatedBlood(MiddleBase attacker, MiddleBase attacked)
    {
        //Vector3 deltaPos = attacker.ower.position - attacked.ower.position;
        //deltaPos.magnitude    
        if(Vector3.Distance(attacker.ower.position, attacked.ower.position) < 10)
        {
            attacked.ReduceBlood(10);
        }
        
    }
	// Use this for initialization
	void Start () {
        MiddleNPC tmpNPC = new MiddleNPC();
        MiddlePlayer tmpPlayer = new MiddlePlayer();
        CaculatedBlood(tmpNPC, tmpPlayer);
        CaculatedBlood(tmpPlayer, tmpNPC);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
