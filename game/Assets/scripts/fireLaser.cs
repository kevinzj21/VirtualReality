using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class fireLaser : MonoBehaviour
{
    public float laserLength = 4.0f;
    public GameObject teleport;
    private LineRenderer laser = null;
   
    private void Awake()
    {
        laser = GetComponent<LineRenderer>();
        
    }


    private void Update()
    {
        RaycastHit Hit;
        Ray ray = new Ray(transform.position, transform.forward);

        if (Physics.Raycast(ray, out Hit, laserLength))
        {
            if (Hit.collider.CompareTag("Ground"))
            {
                teleport.SetActive(true);
                laser.SetPosition(0, transform.position);
                laser.SetPosition(1, Endlaser());
                teleport.transform.position = Hit.point;

            }
        }
        else 
        {
            laser.SetPosition(0, transform.position);
            laser.SetPosition(1, transform.position);
            teleport.SetActive(false);
        }

    }

    private Vector3 Endlaser() 
    {
        RaycastHit hit = CreateForward();
        Vector3 endPosition = Default();
        if (hit.collider) 
        {
            endPosition = hit.point;
        }

        return endPosition;
    }

    private RaycastHit CreateForward() 
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, transform.forward);
        Physics.Raycast(ray, out hit, laserLength);
        return hit;
    }

    private Vector3 Default() 
    {
        return transform.position + (transform.forward * laserLength);
    }


}
