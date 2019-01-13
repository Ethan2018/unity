using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerIdle : FSMBase
{
    Animator animator;
    public PlayerIdle(Animator tmpAnimator)
    {
        animator = tmpAnimator;
    }
    public override void OnEnter()
    {
        animator.SetInteger("Index", 1);
    }
}


public class PlayerWalk : FSMBase
{
    Animator animator;
    public PlayerWalk(Animator tmpAnimator)
    {
        animator = tmpAnimator;
    }
    public override void OnEnter()
    {
        animator.SetInteger("Index", 2);
    }
}

public class PlayerRun: FSMBase
{
    Animator animator;
    public PlayerRun(Animator tmpAnimator)
    {
        animator = tmpAnimator;
    }
    public override void OnEnter()
    {
        animator.SetInteger("Index", 3);
    }
    public override void OnStay()
    {
        base.OnStay();
    }

}

public class PlayerAttack: FSMBase
{
    Animator animator;
    OrcPlayerCtrl myCtrl;
    public PlayerAttack(Animator tmpAnimator, OrcPlayerCtrl ctrl)
    {
        animator = tmpAnimator;
        myCtrl = ctrl;
    }
    public override void OnEnter()
    {
        animator.SetInteger("Index", 4);
        isPlayParticle = false;
        timeCount = 0;
    }


    public override void OnExit()
    {
        isPlayParticle = false;
        timeCount = 0;
    }


    float timeCount = 0;
    bool isPlayParticle = false;
    public override void OnStay()
    {
        timeCount += Time.deltaTime;
        if (timeCount > 0.15f && !isPlayParticle)
        {
            Debug.Log("play particle effect");
        }
        else if (timeCount > 1.0f)
        {
            myCtrl.ChangeState((sbyte)OrcPlayerCtrl.AnimationEnum.Idle);
        }
    }
}

public class PlayerJump : FSMBase
{
    Animator animator;
    public PlayerJump(Animator tmpAnimator)
    {
        animator = tmpAnimator;
    }
    public override void OnEnter()
    {
        animator.SetInteger("Index", 5);
    }
}


public class OrcPlayerCtrl : MonoBehaviour {


    FSMManager fSMManager;
    public enum AnimationEnum
    {
        Idle,
        Walk,
        Run,
        Attack,
        Jump,
        Max
    }


    public void ChangeState(sbyte state)
    {
        fSMManager.ChangeState(state);
    }

    OrcPlayerModle playerModle;
	// Use this for initialization
	void Start () {
        playerModle = new OrcPlayerModle();
        fSMManager = new FSMManager((int)AnimationEnum.Max);
        Animator animator = GetComponent<Animator>();
        PlayerIdle tmpIdle = new PlayerIdle(animator);
        fSMManager.AddState(tmpIdle);
        PlayerWalk tmpWalk = new PlayerWalk(animator);
        fSMManager.AddState(tmpWalk);
        PlayerRun tmpRun = new PlayerRun(animator);
        fSMManager.AddState(tmpRun);
        PlayerAttack tmpAttack= new PlayerAttack(animator, this);
        fSMManager.AddState(tmpAttack);
        PlayerJump tmpJump = new PlayerJump(animator);
        fSMManager.AddState(tmpJump);
    }
	
	// Update is called once per frame
	void Update () {
        fSMManager.Stay();
        if (Input.GetKeyDown(KeyCode.A))
        {
            fSMManager.ChangeState((int)AnimationEnum.Walk);
        }
	}
}
