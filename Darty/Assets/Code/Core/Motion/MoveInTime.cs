using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Code.Core.Motion
{
    public class MoveInTime:MonoBehaviour
    { 
        public Vector3 From;
        public Vector3 To;
        public float TimeLimit;
 
         IEnumerator AnimateInternal()
        {

            float elapsedTime = 0;
            gameObject.transform.position = From;
            while (elapsedTime < TimeLimit)
            {
                transform.position = Vector3.Lerp(From, To, (elapsedTime / TimeLimit));
                elapsedTime += Time.deltaTime;
                yield return null;
            }
        
        }

        public void Animate()
        {
            StartCoroutine(AnimateInternal());
        }
        
    }
}
