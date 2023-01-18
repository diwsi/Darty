using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorMotion : MonoBehaviour
{
    public Vector3 Direction;
    public float Speed;
    void Update()
    {
        gameObject.transform.position += Direction.normalized * Speed;
    }
}
