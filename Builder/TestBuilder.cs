using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuilderBoss
{
    private static BuilderBoss instance;
    public static BuilderBoss Instance
    {
        get
        {
            if(instance == null)
            {
                instance = new BuilderBoss();
            }
            return instance;
        }
    }
    ProjectLeader[] leaders;
    public void MakeMoney()
    {

    }

    public void MakeGame()
    {
        MakeMoney();
        for(int i = 0; i < leaders.Length; i++)
        {
            leaders[i].RecvCommand();
        }
    }
}

public class ProjectLeader
{
    BuilderEnginner[] enginners;

    public void RecvCommand()
    {
        JoinWorker();
    }
    public void JoinWorker()
    {
        for (int i = 0; i < enginners.Length; i++)
        {
            enginners[i].WriteCode();
        }
    }

}

public class BuilderEnginner
{
    public void WriteCode()
    {
        
    }
}

public class TestBuilder : MonoBehaviour {

	// Use this for initialization
	void Start () {
        BuilderBoss.Instance.MakeGame();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
