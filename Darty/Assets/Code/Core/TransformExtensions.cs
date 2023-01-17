using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Code.Core
{
    public static class TransformExtensions
    {
        public static void LookAt2D(this Transform transform, Vector2 target)
        { 
            var zRotation = Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, zRotation + 90);
        }
    }
}
