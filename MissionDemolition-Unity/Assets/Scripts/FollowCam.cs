/*
 * Created by: Qadeem Qureshi
 * Date Created: 2/14/2022
 * 
 * Last Edited by: Qadeem Qureshi
 * Last Edited: Feb 14, 2022
 * 
 * Description: Controls the camera upon projectile spawn 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public static GameObject POI;

    public float camZ; //z transform of the camera

    [Header("Set in Inspector")]
    public float easing = 0.5f; 
    public Vector2 minXY = Vector2.zero;
    
    void Awake()
    {
        camZ = transform.position.z;
    }

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        Vector3 dest;
        if(POI == null)
        {
            dest = Vector3.zero;
        }
        else
        {
            dest = POI.transform.position;
            if(POI.tag == "Projectile")
            {
                if (POI.GetComponent<Rigidbody>().IsSleeping())
                {
                    POI = null;
                    return;
                }
            }
        }


        dest.x = Mathf.Max(minXY.x, dest.x);
        dest.y = Mathf.Max(minXY.y, dest.y);

        dest = Vector3.Lerp(transform.position, dest, easing);
        dest.z = camZ;
        transform.position = dest;

        Camera.main.orthographicSize = dest.y + 10;

    }
}
