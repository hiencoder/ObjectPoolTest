using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestObject : PoolObject
{
    TrailRenderer trail;
    float trailTime;
    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        trail = GetComponent<TrailRenderer>();
        trailTime = trail.time;
    }
    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        //Scale 
        transform.localScale += Vector3.one * Time.deltaTime * 1.5f;
        //Translate
        transform.Translate(Vector3.forward * Time.deltaTime * 25);
    }

    public override void OnObjectResuse()
    {
        trail.time = -1;
		Invoke("ResetTrail",.1f);
        transform.localScale = Vector3.one;
    }

    void ResetTrail()
    {
        trail.time = trailTime;
    }
}
