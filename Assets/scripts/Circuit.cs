using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Circuit : MonoBehaviour
{
    
    [SerializeField] private List<BezierNode> bezierNodes;

    public List<BezierNode> BezierNodes
    {
        get { return bezierNodes; }
    }


}
