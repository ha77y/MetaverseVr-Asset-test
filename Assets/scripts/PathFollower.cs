using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollower : MonoBehaviour
{
    [SerializeField] private Circuit path;
    [SerializeField] private float timeBetweenNodes =1;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private int NodeOffset;
    
    [SerializeField] private float initialTOffset;

    private BezierNode _n0;
    private int _n0Pointer=0;
    private BezierNode _n1;
    private int _n1Pointer =1;

    private float _t;
    private Vector3 _c;

    private void Awake()
    {
        _n0Pointer += NodeOffset;
        _n1Pointer += NodeOffset;
        AssignNodes();
        _t += initialTOffset;

    }

    // Update is called once per frame
    void Update()
    {
        _t += Time.deltaTime/timeBetweenNodes;
        print("_t = " + _t);
        if (_t >= 1)
        {
            
                ;
                _t = 0;

                //when pointer reaches the end of the list: loop back to the first point
                _n0Pointer = (_n0Pointer + 1) % path.BezierNodes.Count;
                _n1Pointer = (_n1Pointer + 1) % path.BezierNodes.Count;
                AssignNodes();
            
            
        }
        
        //Bezier Calculations
        var a0 = Vector3.Lerp(_n0.Node.position, _n0.WeightFwd.position, _t);
        var a1 = Vector3.Lerp(_n0.WeightFwd.position, _n1.WeightBack.position, _t);
        var a2 = Vector3.Lerp( _n1.WeightBack.position,_n1.Node.position, _t);
        
        var b0 = Vector3.Lerp(a0, a1, _t);
        var b1 = Vector3.Lerp(a1, a2, _t);
        
        var c0 = Vector3.Lerp(b0, b1, _t);
        _c = c0;
        
        ;
        //transform.rotation = Quaternion.LookRotation(Vector3.forward, Vector3.up);
        transform.position = c0;


    }

    private void AssignNodes()
    {
        _n0 = path.BezierNodes[_n0Pointer];
        _n1 = path.BezierNodes[_n1Pointer];
    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(_c,1f);
    }
}
