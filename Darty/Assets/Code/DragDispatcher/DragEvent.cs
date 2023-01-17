using Assets.Code.DragIndicator;
using System;
using UnityEngine;

namespace Assets.Code.DragDispatcher
{
    [Serializable]
    public class DragEvent
    {
        public DragStatus Status { get; set; }
        public Vector2 Delta { get; set; }
    }
}
