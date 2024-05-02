using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceObject : MonoBehaviour
{
    public Transform indicator;
    void Start()
    {
        if (indicator == null)
        {
            indicator = GameObject.Find("Indicator").transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("update!!");
        transform.LookAt(new Vector3(indicator.position.x, transform.position.y, indicator.position.z));
    }
}