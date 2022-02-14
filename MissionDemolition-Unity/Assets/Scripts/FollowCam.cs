/*
 * Created by: Qadeem Qureshi
 * Date Created: 2/14/2022
 * 
 * Last Edited by: Qadeem Qureshi
 * Last Edited: Feb 14, 2022
 * 
 * Description: Controls the Slingshot 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public static GameObject objectToFollow;
    float camZ = 0;
    public float ease = .05f;
    public Vector2 minXY = Vector2.zero;

    // Start is called before the first frame update
    void Awake()
    {
        camZ = transform.position.z;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!objectToFollow)
            return;
        Vector3 destination = objectToFollow.transform.position;
        destination = Vector3.Lerp(transform.position, destination, ease);
        destination.x = Mathf.Max(minXY.x, destination.x);
        destination.y = Mathf.Max(minXY.y, destination.y);
        destination.z = camZ;
        transform.position = destination;
        Camera.main.orthographicSize = destination.y +  10;
    }
}
