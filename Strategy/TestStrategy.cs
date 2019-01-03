using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbsBase
{
    public float payMoney;
    public virtual void CaculateTax()
    {

    }
}
public class AbsPerson : AbsBase
{
    public override void CaculateTax()
    {
        payMoney *= 0.08f;
    }
}
public class AbsCompany : AbsBase
{
    public override void CaculateTax()
    {
        payMoney *= 0.12f;
    }
}
public class TestStrategy : MonoBehaviour {

    public void CaculateTax(AbsBase tmpBase)
    {
        tmpBase.CaculateTax();
    }
	// Use this for initialization
	void Start () {
        AbsPerson tmpPerson = new AbsPerson();
        CaculateTax(tmpPerson);
        AbsCompany tmpCompany = new AbsCompany();
        CaculateTax(tmpCompany);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
