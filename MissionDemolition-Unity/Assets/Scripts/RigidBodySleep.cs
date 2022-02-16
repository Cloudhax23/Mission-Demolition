/*
 * Created by: Qadeem Qureshi
 * Date Created: 2/16/2022
 * 
 * Last Edited by: Qadeem Qureshi
 * Last Edited: Feb 16, 2022
 * 
 * Description: Controls the Rigidbody status of objects
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class RigidBodySleep : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb) rb.Sleep();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
