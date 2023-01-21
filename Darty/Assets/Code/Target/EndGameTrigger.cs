using Assets.Code.Target;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

public class EndGameTrigger : MonoBehaviour
{
    public UnityEvent EndGame;
    void OnCollisionEnter2D(Collision2D col)
    {
        var target= col.gameObject.GetComponentInChildren<ITarget>();
        if(target != null)
        {
            EndGame.Invoke();
        }

    }
}

