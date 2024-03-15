using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat : MonoBehaviour
{

    [SerializeField] private Transform lookTarget;
    // Start is called before the first frame update
    
    

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(lookTarget);
    }
}
