using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcControl : MonoBehaviour {//挂载

    void OnAnimatorMove()
    {
        characterController.Move(animator.deltaPosition);//动画片段的位移
    }

    CharacterController characterController;
    Animator animator;
    // Use this for initialization
    void Start () {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

	}
}
