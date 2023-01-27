using Assets.Code.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public class DartBody : MonoBehaviour, ILaunchable
{

    Rigidbody2D rb;
    bool Launched;
    [Range(0, 1000)]
    public float MaxPower = 500f;
    public TrailRenderer Tail;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.simulated = false;
        Tail.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!Launched)
        {

            return;
        }

        var velocity = rb.velocity;
        transform.LookAt2D(velocity);
    }

    public void Launch(float force)
    {
        if (Launched) return;
        Tail.enabled =true;
        rb.simulated = true;
        rb.AddForce(-1f * transform.up * MaxPower * force);
        Launched = true;
        Destroy(gameObject, 7f);
    }

}
