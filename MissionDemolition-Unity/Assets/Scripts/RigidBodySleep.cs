/*
 * Created by: Qadeem Qureshi
 * Date Created: 2/18/2022
 * 
 * Last Edited by: Qadeem Qureshi
 * Last Edited: Feb 18, 2022
 * 
 * Description: Rigid body's to sleep! 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class RigidBodySleep : MonoBehaviour
{
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if(rb != null)
        {
            rb.Sleep();
        }
    }
}
