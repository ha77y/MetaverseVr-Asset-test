using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class BezierNode : MonoBehaviour
{
    [SerializeField]private Transform node;
    [SerializeField]private Transform weightFwd;
    [SerializeField]private Transform weightBack;
    
    public Transform Node
    {
        get { return node; }
        set { node = value; }
    }

    public Transform WeightFwd
    {
        get { return weightFwd; }
        set { weightFwd = value; }
    }

    public Transform WeightBack
    {
        get { return weightBack; }
        set { weightBack = value; }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(Node.position,WeightFwd.position);
        Gizmos.DrawLine(Node.position,WeightBack.position);
        Gizmos.color = Color.green;
        Gizmos.DrawCube(node.position, Vector3.one *1f); 
        Gizmos.color = Color.red;
        Gizmos.DrawCube(weightBack.position, Vector3.one *0.8f); 
        Gizmos.DrawCube(weightFwd.position, Vector3.one *0.8f); 
        
    }
}
