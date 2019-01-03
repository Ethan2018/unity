using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour {

    Animation animal;
	// Use this for initialization
	void Start () {
        animal = GetComponent<Animation>();
        animal.Play("BigAttack");
	}

    public void PlayBigAttack()
    {
        animal.Play("BigAttack");
        timeCount = 0;
    }
    float timeCount = 0;
	// Update is called once per frame
	void Update () {
        //timeCount += Time.deltaTime;
        //if(timeCount > 0.5f)
        //{
        //    timeCount = 0;
        //    //do something

        //}

        if(!animal.isPlaying)
        {
            //do something
        }

	}
}
