using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerCam : MonoBehaviour
{
    public float sensX;
    public float sensY;

    public Transform orientation;
    public Transform camHolder;

    float xRotation;
    float yRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    //simpel weg zorgt dit ervoor dat wanneer men hun muis beweegt dat de camera mee gaat, ook geb ik gelijk een public float ervoor ghemaakt zodat in unity de sensitivity
    //ofwel desnelheid van het "kijken" kan worden verandert in unity zelf.
    private void Update() 
    {
        // get mouse input
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        yRotation += mouseX;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // rotate cam and orientation
        camHolder.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }



    // verandert de camera met een beetje shake en de FOV vergroten in samenwerking met de "DOTween" unity asset (dit is veel te xomplex voor mij om zelf te programmeren.
    // dit wordt gebruikt met wall running en dashen. Het vergoot de FOV en implementeert mooie camera shake
    public void DoFov(float endValue)
    {
        GetComponent<Camera>().DOFieldOfView(endValue, 0.25f);
    }

    public void DoTilt(float zTilt)
    {
        transform.DOLocalRotate(new Vector3(0, 0, zTilt), 0.25f);
    }
}