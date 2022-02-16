/*
 * Created by: Qadeem Qureshi
 * Date Created: 2/09/2022
 * 
 * Last Edited by: Qadeem Qureshi
 * Last Edited: Feb 09, 2022
 * 
 * Description: Controls the Slingshot 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : MonoBehaviour
{
    public GameObject launchPoint;
    public GameObject projectile;
    public Vector3 startingPoint;
    public float velocityMult = 8f;

    private void Awake()
    {
        launchPoint.SetActive(false);
    }

    private void OnMouseDrag()
    {
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
        if (startingPoint == Vector3.zero)
        {
            startingPoint = Camera.main.ScreenToWorldPoint(mousePos3D);
            projectile = Instantiate(projectile);
            projectile.GetComponent<Rigidbody>().isKinematic = true;
        }
        Vector3 desiredDelta = mousePos3D - launchPoint.transform.position;
        if (desiredDelta.magnitude > GetComponent<SphereCollider>().radius)
        {
            desiredDelta.Normalize();
            desiredDelta *= GetComponent<SphereCollider>().radius;
        }
        projectile.transform.position = launchPoint.transform.position + desiredDelta;
        projectile.GetComponent<Rigidbody>().velocity = -desiredDelta * velocityMult;
        launchPoint.SetActive(true);
    }
    private void OnMouseUp()
    {
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
        launchPoint.SetActive(false);
        startingPoint = Vector3.zero;
        projectile.GetComponent<Rigidbody>().isKinematic = false;
        FollowCam.objectToFollow = projectile;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { 
    
    }
}
