using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TestFacade : MonoBehaviour {

    public GameObject redObj;
    public GameObject greenObj;
    public void ShowRedLighting()
    {
        redObj.SetActive(true);
        greenObj.SetActive(false);
    }
    public void ShowGreenLighting()
    {
        redObj.SetActive(false);
        greenObj.SetActive(true);
    }
    bool isReding = true;
    public void OnClick()
    {
        isReding = !isReding;
        if(isReding)
        {
            ShowRedLighting();
        }
        else
        {
            ShowGreenLighting();
        }
    }
	// Use this for initialization
	void Start () {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(OnClick);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
