using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraDarkenController : MonoBehaviour {

    private Button myButton;

    public float darken = 0f;

    private bool bStart;
    private bool bOnce;
    
    void Awake()
    {
        myButton = GetComponent<Button>(); // <-- you get access to the button component here

        myButton.onClick.AddListener(() => { myFunctionForOnClickEvent(); });
    }


    void myFunctionForOnClickEvent()
    {
        bOnce = true;
        bStart = true;
       
        darken = 1.0f;

        GameObject.Find("Canvas/BlackScreen").GetComponent<Image>().color = new Color(0, 0, 0, 0);
    }

    // Update is called once per frame
    void Update () {
        if(bOnce == true)
        {
            // set color of the panel - black
            GameObject.Find("Canvas/BlackScreen").GetComponent<Image>().color = new Color(0, 0, 0, 255);
            bOnce = false;
        }

        if (darken > 0 && bStart == true)
        {
            darken -= 0.01f;            
        }
        else
        {
            if (bStart == true)
            {
                bStart = false;
                GameObject.Find("Canvas/BlackScreen").GetComponent<Image>().color = new Color(0, 0, 0, 0);
            }
        }

    }
}
