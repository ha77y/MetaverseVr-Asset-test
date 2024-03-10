using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buoyancy : MonoBehaviour
{
    [SerializeField] private Transform[] rayOrigins;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 normalTotal = Vector3.zero;
        foreach (var origin in rayOrigins)
        {
            if (Physics.Raycast(origin.position, -origin.up, out RaycastHit hit,Mathf.Infinity,LayerMask.GetMask("Water")))
            {
                print(hit.transform.gameObject.name);
                normalTotal += hit.normal;
            }
        }

        normalTotal /= rayOrigins.Length;

        transform.up = normalTotal;

    }
}
