using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Target : MonoBehaviour
{
    [Range(1,5)]
    public float Life=1f;

    public UnityEvent<float> TargetHit;
    public UnityEvent TargetDestroyed;

    void OnCollisionEnter2D(Collision2D col)
    {
        var collider= col.collider.gameObject.GetComponent<TargetCollider>();
        if (collider != null)
        {
            HitTarget(collider.Damage);
        }
        if (Life <= 0)
        {
            DestroyTarget();
        }
    }

    public void HitTarget(float damage)
    {
        Life -= damage;
        TargetHit.Invoke(Life);
    }

    public void DestroyTarget()
    {
        TargetDestroyed.Invoke();
        Destroy(gameObject);
    }
}
