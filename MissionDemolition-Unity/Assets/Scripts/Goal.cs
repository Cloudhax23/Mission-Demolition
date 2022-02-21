/*
 * Created by: Qadeem Qureshi
 * Date Created: 2/17/2022
 * 
 * Last Edited by: Qadeem Qureshi
 * Last Edited: Feb 17, 2022
 * 
 * Description: M<anages what happens when a projectile enters the goal
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public static bool goalMet = false; 
    
    void OnTriggerEnter(Collider other) {

        if(other.gameObject.tag == "Projectile"){
            Goal.goalMet = true;

            Material mat = GetComponent<Renderer>().material;
            Color c = mat.color;
            c.a = 1;
            mat.color = c;
        }
    }
}
