/*
 * Created by: Qadeem Qureshi
 * Date Created: 2/14/2022
 * 
 * Last Edited by: Qadeem Qureshi
 * Last Edited: Feb 14, 2022
 * 
 * Description: Controls the Cloud design 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject cloudSphere;
    public int maxSpheres = 10;
    public int minSpheres = 6;
    public Vector2 sphereScaleRangeX = new Vector2(4, 8);
    public Vector2 sphereScaleRangeY = new Vector2(3, 7);
    public Vector2 sphereScaleRangeZ = new Vector2(2, 7);
    public Vector3 sphereOffsetScale = new Vector3(5, 2, 1);
    public float scaleYMin = 2f;

    private List<GameObject> spheres;


    void Start()
    {
        spheres = new List<GameObject>();
        int num = Random.Range(minSpheres, maxSpheres);

        for(int i = 0; i < num; i++)
        {
            GameObject sp = Instantiate(cloudSphere);
            spheres.Add(sp);

            Transform spTrans = sp.transform;
            spTrans.SetParent(this.transform);

            Vector3 offset = Random.insideUnitSphere;
            offset.x *= sphereOffsetScale.x;
            offset.y *= sphereOffsetScale.y;
            offset.z *= sphereOffsetScale.z;

            spTrans.localPosition = offset;

            Vector3 scale = Vector3.one;
            scale.x = Random.Range(sphereScaleRangeX.x, sphereScaleRangeX.y);
            scale.y = Random.Range(sphereScaleRangeY.x, sphereScaleRangeY.y);
            scale.z = Random.Range(sphereScaleRangeZ.x, sphereScaleRangeZ.y);

            scale.y *= 1 - (Mathf.Abs(offset.x) / sphereOffsetScale.x);
            scale.y = Mathf.Max(scale.y, scaleYMin);

            spTrans.localScale = scale;
        }
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
           Restart();
        }
    }

    void Restart()
    {
        foreach (GameObject sp in spheres) {
            Destroy(sp);
        }

        Start();
    }
}
