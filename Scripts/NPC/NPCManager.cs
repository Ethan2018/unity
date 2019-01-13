using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NPCManagerModel
{
    private float forwardDistance = 10;
    private float rightDistance = 5;
    private float bigAttackReduce = 50;

    public float ForwardDistance
    {
        get
        {
            return forwardDistance;
        }

        set
        {
            forwardDistance = value;
        }
    }

    public float RightDistance
    {
        get
        {
            return rightDistance;
        }

        set
        {
            rightDistance = value;
        }
    }

    public float BigAttackReduce
    {
        get
        {
            return bigAttackReduce;
        }

        set
        {
            bigAttackReduce = value;
        }
    }
}



public class NPCManager : MonoBehaviour {

    public static NPCManager Instance;
    private Transform player;
    public Transform Player
    {
        get
        {
            if (player == null)
            {
                player = GameObject.FindGameObjectWithTag("Player").transform;
            }
            return player;
        }
    }

    NPCManagerModel npcManagerModel;
    void Awake()
    {
        Instance = this;
        allNPC = new List<NPCCell>();
        npcManagerModel = new NPCManagerModel();
    }

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



    public void AttackedByPlayer()
    {
        for (int i = 0; i < allNPC.Count; i++)
        {
            NPCCell tmpCell = allNPC[i];
            if (RectAttackJudge(Player, tmpCell.transform, npcManagerModel.ForwardDistance, npcManagerModel.RightDistance))
            {
                tmpCell.ReduceBlood(npcManagerModel.BigAttackReduce);
            }
        }
    }





    List<NPCCell> allNPC;
    /// <summary>
    /// 
    /// </summary>
    /// <param name="path"></param>
    /// <param name="npcParent"></param>
    /// <returns></returns>
    public GameObject FactoryNPC(string path, Transform npcParent)
    {
        Object tmpObj = Resources.Load(path);
        GameObject tmpNPC = GameObject.Instantiate(tmpObj) as GameObject;
        tmpNPC.transform.SetParent(npcParent, false);
        NPCCell tmpCell = tmpNPC.AddComponent<NPCCell>();//挂脚本
        allNPC.Add(tmpCell);
        return tmpNPC;

    }

    // Use this for initialization
    void Start () {
		
	}
	

    public void AIFollowPlayer()
    {
        for (int i = 0; i < allNPC.Count; i++)
        {
            NPCCell tmpCell = allNPC[i];
            tmpCell.AIAttack();
        }
    }
	// Update is called once per frame
	void Update () {
        AIFollowPlayer();

    }
}
