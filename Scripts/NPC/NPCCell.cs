using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NPCModel
{
    float bloodCount;

    public float BloodCount
    {
        get
        {
            return bloodCount;
        }

        set
        {
            bloodCount = value;
        }
    }

    public float FollowDistance
    {
        get
        {
            return followDistance;
        }

        set
        {
            followDistance = value;
        }
    }

    public float AttackDistance
    {
        get
        {
            return attackDistance;
        }

        set
        {
            attackDistance = value;
        }
    }

    public float MoveSpeed
    {
        get
        {
            return moveSpeed;
        }

        set
        {
            moveSpeed = value;
        }
    }

    float followDistance = 10;
    float attackDistance = 5;
    float moveSpeed = 2;

}
public class NPCCell : RoleBase {

    NPCModel npcData;


    void Awake()
    {
        Initial();
    }

    public override void Initial()
    {
        base.Initial();
        npcData = new NPCModel();
    }
    public void ReduceBlood(float reduce)
    {
        npcData.BloodCount -= reduce;
    }

	public void AIAttack()
    {
        Vector3 deltaA = NPCManager.Instance.Player.position - transform.position;
        if (deltaA.magnitude < npcData.FollowDistance)
        {
            if (deltaA.magnitude < npcData.AttackDistance)
            {
                ChangeState((sbyte)AnimationEnum.Attack);
            }
            else
            {
                SimpleMove(deltaA.normalized * npcData.MoveSpeed);
            }
        }
    }
}
