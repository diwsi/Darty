using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.Events;

namespace Assets.Code.Target
{
    public interface ITarget
    {
        UnityEvent TargetDestroyedInternal { get; }
    }
}
