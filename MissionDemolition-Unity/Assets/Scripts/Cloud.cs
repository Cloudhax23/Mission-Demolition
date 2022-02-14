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

            offset = Vector3.Cross(offset, sphereOffsetScale);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
