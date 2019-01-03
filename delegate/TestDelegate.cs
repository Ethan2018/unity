using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HusBand
{
    Wife myWife;
    public void AddMoney()
    {
        myWife.BorrowMoney();
    }
    public void Notice()
    {
        Debug.Log("xxxxxxxxx");
    }
    public void NoticeTwo()
    {
        Debug.Log("xxxxxxxxx");
    }
}

public class Wife
{
    public delegate void WifeSister();

    public WifeSister wifeSister;
    public void BorrowMoney()
    {

    }
    public void SayBadWord()
    {
        wifeSister();
    }
}
public class TestDelegate : MonoBehaviour {

	// Use this for initialization
	void Start () {
        HusBand tmpHusband = new HusBand();

        Wife tmpWife = new Wife();
        //多播
        tmpWife.wifeSister += tmpHusband.Notice;
        tmpWife.wifeSister += tmpHusband.NoticeTwo;
        tmpWife.SayBadWord();

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
