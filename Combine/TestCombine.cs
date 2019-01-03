using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankBase
{
    public virtual void WalkFront()
    {

    }
    public virtual void WalkBack()
    {

    }
}
public class Bullet : TankBase
{
    public override void WalkFront()
    {
        base.WalkFront();
    }
    public override void WalkBack()
    {
        base.WalkBack();
    }
}
public class TankWheel : TankBase
{
    public override void WalkFront()
    {
        base.WalkFront();
    }
    public override void WalkBack()
    {
        base.WalkBack();
    }
}

public class TankEngine : TankBase
{

}
public class TestCom : MonoBehaviour {

    List<TankBase> tank;
	// Use this for initialization
	void Start () {
        tank = new List<TankBase>();
        Bullet bullet = new Bullet();
        tank.Add(bullet);
        TankEngine engine = new TankEngine();
        tank.Add(engine);
        TankWheel wheel = new TankWheel();
        tank.Add(wheel);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.W))
        {
            for(int i = 0; i < tank.Count; i++)
            {
                tank[i].WalkFront();
            }
        }
        if (Input.GetKey(KeyCode.S))
        {
            for (int i = 0; i < tank.Count; i++)
            {
                tank[i].WalkBack();
            }
        }
    }
}
