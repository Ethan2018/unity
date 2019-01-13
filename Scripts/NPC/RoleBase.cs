using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class RoleBase : MonoBehaviour {

    FSMManager fsmManager;
    CharacterController character;

    public enum AnimationEnum
    {
        Idle,
        Walk,
        Run,
        Attack,
        Jump,
        Max
    }

    public virtual void SimpleMove(Vector3 speed)
    {
        character.SimpleMove(speed);
    }
    public virtual void Initial()
    {
        fsmManager = new FSMManager((int)AnimationEnum.Max);
        character = transform.GetComponent<CharacterController>();
    }

    public virtual void ChangeState(sbyte state)
    {
        fsmManager.ChangeState(state);
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
