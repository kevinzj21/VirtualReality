using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class Teleport : MonoBehaviour
{
    public GameObject teleport;
    public GameObject test;
    public GameObject cameraRig;
    public SteamVR_Action_Boolean Tele;
    public SteamVR_Input_Sources handType;
    private Vector3 newPos;
    // Start is called before the first frame update
    void Start()
    {
        Tele.AddOnChangeListener(OnTeleChange, handType);
        

    }


    private void OnTeleChange(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource, bool newState)
    {
        if (newState)
        {
            if (teleport.activeSelf == true)
            {
                SteamVR_Fade.View(Color.black, 0f);
                newPos = teleport.transform.position;
                newPos.y = cameraRig.transform.position.y;
                cameraRig.transform.position = newPos;
                SteamVR_Fade.View(Color.clear, 1f);
            }

        }
        
        
        
    }
    
}
