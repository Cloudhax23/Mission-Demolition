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

public class Cloud : MonoBehaviour
{
    public GameObject cloudSpherePrefab;
    public int numSphereMin = 5;
    public int numSphereMax = 15;
    public Vector2 sphereScaleRangeX = new Vector2(4, 8);
    public Vector2 sphereScaleRangeY = new Vector2(4, 8);
    public Vector2 sphereScaleRangeZ = new Vector2(4, 8);
    public Vector3 sphereOffsetScale = new Vector3(5, 2, 1);
    public float scaleYMin = 2f;
    private List<GameObject> spheres;

    // Start is called before the first frame update
    void Start()
    {
        spheres = new List<GameObject>();
        int num = Random.Range(numSphereMin, numSphereMax);
        for(int i = 0; i < num; i++)
        {
            GameObject sp = Instantiate(cloudSpherePrefab);
            spheres.Add(sp);

            Transform spTransform = sp.transform;
            spTransform.SetParent(transform);

            Vector3 offset = Random.insideUnitSphere;

            offset.x *= sphereOffsetScale.x;
            offset.y *= sphereOffsetScale.y;
            offset.z *= sphereOffsetScale.z;
            spTransform.localPosition =  offset;
            
            Vector3 scale = Vector3.one;
            scale.x = Random.Range(sphereScaleRangeX.x,
            sphereScaleRangeX.y);
            scale.y = Random.Range(sphereScaleRangeY.x,
            sphereScaleRangeY.y);
            scale.z = Random.Range(sphereScaleRangeZ.x,
            sphereScaleRangeZ.y);

            scale.y *= 1 - (Mathf.Abs(offset.x) / sphereOffsetScale.x);
            scale.y = Mathf.Max(scale.y, scaleYMin);
            spTransform.localScale = scale;

        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
