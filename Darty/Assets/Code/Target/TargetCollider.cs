using Assets.Code.Target;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCollider : MonoBehaviour,ITargetCollider
{
    [Range(0f, 10f)]
    public float Damage=1f;
    public float DamageInt
    {
        get
        {
            return Damage;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Destroy(gameObject);
    }
}
