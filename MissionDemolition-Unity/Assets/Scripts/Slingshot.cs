/*
 * Created by: Qadeem Qureshi
 * Date Created: 2/9/2022
 * 
 * Last Edited by: Qadeem Qureshi
 * Last Edited: Feb 9, 2022
 * 
 * Description: Main slingshot behavior
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : MonoBehaviour
{
    [Header("Drop Prefab Here")]
    public GameObject projPrefab;
    [Header("Change Values Around")]
    public float velocityMultiplier = 10f;

    [Header("Don't Touch")]
    static private Slingshot S;  
    public GameObject launchPoint;
    public GameObject projectile;
    public Vector3 launchPos;
    public bool aimingMode;
    public Rigidbody projRB;

    static public Vector3 LAUNCH_POS {                                       
            get {
                if (S == null ) return Vector3.zero;
                return S.launchPos;
            }
        }

    private void Awake()
    {
        S = this;    
        Transform launchPointTrans = transform.Find("LaunchPoint");
        launchPoint = launchPointTrans.gameObject; 
        launchPoint.SetActive(false);
        launchPos = launchPointTrans.position;
    }

    private void Update()
    {
        if (!aimingMode) return; 

        Vector3 mousePos2D = Input.mousePosition;
        mousePos2D.z = -Camera.main.transform.position.z; 
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        Vector3 mouseDelta = mousePos3D - launchPos;


        float maxMagnitude = this.GetComponent<SphereCollider>().radius;
        if(mouseDelta.magnitude > maxMagnitude) 
        {
            mouseDelta.Normalize();
            mouseDelta *= maxMagnitude;
        }

        projectile.transform.position = launchPos + mouseDelta;

        if (Input.GetMouseButtonUp(0)) 
        {
            aimingMode = false;
            projRB.isKinematic = false;
            projRB.velocity = -mouseDelta * velocityMultiplier; 
            FollowCam.POI = projectile;
            projectile = null;
            MissionDemolition.ShotFired();
            ProjectileLine.S.poi = projectile;
        }
    }
    private void OnMouseEnter()
    {
        launchPoint.SetActive(true);
    }

    private void OnMouseExit()
    {
        launchPoint.SetActive(false);
    }

    private void OnMouseDown()
    {
        aimingMode = true;
        projectile = Instantiate(projPrefab);
        projectile.transform.position = launchPos;

        projRB = projectile.GetComponent<Rigidbody>(); 
        projRB.isKinematic = true;
    }
}
