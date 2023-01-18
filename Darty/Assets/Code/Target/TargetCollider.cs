using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCollider : MonoBehaviour
{
    [Range(0f, 10f)]
    public float Damage=1f;

    void OnCollisionEnter2D(Collision2D col)
    {
        Destroy(gameObject);
    }
}
