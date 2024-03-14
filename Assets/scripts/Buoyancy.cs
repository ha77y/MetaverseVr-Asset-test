
using System;
using UnityEngine;
using UnityEngine.Serialization;

public class Buoyancy : MonoBehaviour
{
    [SerializeField] private Material waterMat;
    [SerializeField] private float numOfBuoys =1;
    [SerializeField] private Rigidbody rb;
    private float _frequency, _amplitude, _speed
        , _wave1Rot,_wave2Rot,_wave3Rot,_wave4Rot
        ,_wave1Size,_wave2Size,_wave3Size,_wave4Size;
    private Vector2 _direction;

    private float _waterHeight;

    private static readonly int WaveFrequency = Shader.PropertyToID("_WaveFrequency");
    private static readonly int WaveAmplitude = Shader.PropertyToID("_WaveAmplitude");
    private static readonly int WaveSpeed = Shader.PropertyToID("_WaveSpeed");
    private static readonly int Wave1Rotation = Shader.PropertyToID("_Wave1Rotation");
    private static readonly int Wave1Size = Shader.PropertyToID("_Wave1Size");
    private static readonly int Wave2Rotation = Shader.PropertyToID("_Wave2Rotation");
    private static readonly int Wave2Size = Shader.PropertyToID("_Wave2Size");
    private static readonly int Wave3Rotation = Shader.PropertyToID("_Wave3Rotation");
    private static readonly int Wave3Size = Shader.PropertyToID("_Wave3Size");
    private static readonly int Wave4Rotation = Shader.PropertyToID("_Wave4Rotation");
    private static readonly int Wave4Size = Shader.PropertyToID("_Wave4Size");

    // Start is called before the first frame update
    void Start()
    {
        _direction = Vector2.one.normalized;
        
    }


    // Update is called once per frame
    void Update()
    {
        FetchVariables();
        
        _waterHeight = GetWaterHeightAt(transform.position);
       

    }

    private void FixedUpdate()
    {
        
        var position = transform.position;
        
        rb.AddForceAtPosition(Physics.gravity/numOfBuoys,position ,ForceMode.Acceleration);
        if (position.y < _waterHeight)
        {
            print("underwater");
            
            rb.AddForceAtPosition(
                Vector3.up/numOfBuoys * ((_waterHeight-position.y) * Physics.gravity.magnitude)
                ,position);
        }
    }

    private void FetchVariables()
    {
        _frequency = waterMat.GetFloat(WaveFrequency);
        _amplitude = waterMat.GetFloat(WaveAmplitude);
        _speed = waterMat.GetFloat(WaveSpeed);
        _wave1Rot = waterMat.GetFloat(Wave1Rotation);
        _wave1Size = waterMat.GetFloat(Wave1Size);
        _wave2Rot = waterMat.GetFloat(Wave2Rotation);
        _wave2Size = waterMat.GetFloat(Wave2Size);
        _wave3Rot = waterMat.GetFloat(Wave3Rotation);
        _wave3Size = waterMat.GetFloat(Wave3Size);
        _wave4Rot = waterMat.GetFloat(Wave4Rotation);
        _wave4Size = waterMat.GetFloat(Wave4Size);
    }

    private float GetWaterHeightAt( Vector3 pos)
    {
        float wave1 = WaveGenerator(pos,_direction, _wave1Rot,_wave1Size);
        float wave2 = WaveGenerator(pos, _direction,_wave2Rot,_wave2Size);
        float wave3 = WaveGenerator(pos,_direction,_wave3Rot,_wave3Size);
        float wave4 = WaveGenerator(pos,_direction,_wave4Rot,_wave4Size);
        return (wave1 + wave2 + wave3+ wave4);
    }

    private float WaveGenerator(Vector3 position , Vector2 direction,float rotation, float size)
    {
        var rotatedDir = new Vector2( 
            (Mathf.Cos(rotation* Mathf.Deg2Rad)*direction).magnitude,
            (Mathf.Sin(rotation* Mathf.Deg2Rad)*direction).magnitude);
        
        var planePos = new Vector2(position.x, position.z);
        var dotDir = Vector2.Dot(rotatedDir, planePos);
        var sinIn = (dotDir + (2 * Time.time * _speed / size)) * (6.28f * _frequency/size);
        print(rotatedDir);

        return (Mathf.Sin(sinIn) + 0.5f) /2  * _amplitude* size ;
    }
}
