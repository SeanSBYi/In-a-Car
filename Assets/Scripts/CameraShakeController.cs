using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraShakeController : MonoBehaviour {

    // Transform of the camera to shake. Grabs the gameObject's transform
    // if null.
    public Transform camTransform;

    // How long the object should shake for.
    public float shake = 0f;

    // Amplitude of the shake. A larger value shakes the camera harder.
    public float shakeAmount = 0.05f;
    public float decreaseFactor = 1.0f;

    Vector3 originalPos;

    private Button myButton;
    private bool bStart;
    private bool bEnd;

    void Awake()
    {
        myButton = GetComponent<Button>(); // <-- you get access to the button component here

        myButton.onClick.AddListener(() => { myFunctionForOnClickEvent(); });
    }
    
        
    void myFunctionForOnClickEvent()
    {
        bStart = true;
        shake = 1.0f;

        if (camTransform == null)
        {
            camTransform = GetComponent(typeof(Transform)) as Transform;
        }
        originalPos = camTransform.localPosition;
    }

    void Update()
    {
        if (shake > 0 && bStart == true)
        {
            camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;

            shake -= Time.deltaTime * decreaseFactor;
            bEnd = true;
        }
        else
        {
            shake = 0f;
            if(bEnd == true)
            {
                camTransform.localPosition = originalPos;
                bEnd = false;
                bStart = false;
            }            
        }
    }
}



