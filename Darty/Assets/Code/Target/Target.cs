using Assets.Code.Target;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Target : MonoBehaviour, ITarget
{
    [Range(1, 5)]
    public float Life = 1f;

    public UnityEvent<float> TargetHit;
    public UnityEvent TargetDestroyed;
    public UnityEvent TargetDestroyedInternal
    {
        get { return TargetDestroyed; }
    }

    public GameObject DestroyEffect;
    void OnCollisionEnter2D(Collision2D col)
    {
        var collider = col.collider.gameObject.GetComponent<ITargetCollider>();
        if (collider != null)
        {
            HitTarget(collider.DamageInt);
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

        if (DestroyEffect != null)
        {
            var effect = Instantiate(DestroyEffect,transform.position,Quaternion.identity);
            GameObject.Destroy(effect, 3f);
        }

        Destroy(gameObject);

    }
}
