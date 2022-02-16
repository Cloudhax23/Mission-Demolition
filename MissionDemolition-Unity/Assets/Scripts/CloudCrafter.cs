/*
 * Created by: Qadeem Qureshi
 * Date Created: 2/16/2022
 * 
 * Last Edited by: Qadeem Qureshi
 * Last Edited: Feb 16, 2022
 * 
 * Description: Controls the Slingshot 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudCrafter : MonoBehaviour
{
    [Header("Set in Inspector")]
    public int numClouds = 40; 
    public GameObject cloudPrefab; 
    public Vector3 cloudPosMin = new Vector3(-50, -5, 10);
    public Vector3 cloudPosMax = new Vector3(150, 100, 10);
    public float cloudScaleMin = 1; 
    public float cloudScaleMax = 3;
    public float cloudSpeedMult = 0.5f; 
    private GameObject[] cloudInstances;
    
    void Awake()
    {
        cloudInstances = new GameObject[numClouds];
        // Find the CloudAnchor parent GameObject
        GameObject anchor = GameObject.Find("CloudAnchor");
        // Iterate through and make Cloud_s
        GameObject cloud;
        for (int i = 0; i < numClouds; i++)
        {
            // Make an instance of cloudPrefab
            cloud = Instantiate<GameObject>(cloudPrefab);
            // Position cloud
            Vector3 cPos = Vector3.zero;
            cPos.x = Random.Range(cloudPosMin.x, cloudPosMax.x);
            cPos.y = Random.Range(cloudPosMin.y, cloudPosMax.y);
            // Scale cloud
            float scaleU = Random.value;
            float scaleVal = Mathf.Lerp(cloudScaleMin,
            cloudScaleMax, scaleU);
            cPos.y = Mathf.Lerp(cloudPosMin.y, cPos.y, scaleU);
            // Smaller clouds should be further away
            cPos.z = 100 - 90 * scaleU;
            // Apply these transforms to the cloud
            cloud.transform.position = cPos;
            cloud.transform.localScale = Vector3.one * scaleVal;
            // Make cloud a child of the anchor
            cloud.transform.SetParent(anchor.transform);
            // Add the cloud to cloudInstances
            cloudInstances[i] = cloud;
        }
    }
    void Update()
    {
        // Iterate over each cloud that was created
        foreach (GameObject cloud in cloudInstances)
        {
            // Get the cloud scale and position
            float scaleVal = cloud.transform.localScale.x;
            Vector3 cPos = cloud.transform.position;
            // Move larger clouds faster
            cPos.x -= scaleVal * Time.deltaTime * cloudSpeedMult;
            // If a cloud has moved too far to the left...
            if (cPos.x <= cloudPosMin.x)
            {
                // Move it to the far right
                cPos.x = cloudPosMax.x;
            }
            // Apply the new position to cloud
            cloud.transform.position = cPos;
        }
    }
}