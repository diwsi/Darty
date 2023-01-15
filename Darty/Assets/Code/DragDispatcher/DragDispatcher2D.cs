using Assets.Code.DragDispatcher;
using Assets.Code.DragIndicator;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEditor;
using UnityEngine;

public class DragDispatcher2D : MonoBehaviour
{
     
    [Range(0.1f,1f)]
    public float DispatchSegment=0.1f;

    public DragStatus Status { get; set; }
    public Vector2? Pivot { get; set; }

    public Vector2? DragPostion { get; set; }

    public Vector2 Delta
    {
        get
        {
            if (!Pivot.HasValue || !DragPostion.HasValue)
            {
                return new Vector2();
            }
            var plotVector = (DragPostion.Value - Pivot.Value);
            var dV = Mathf.Min(plotVector.magnitude / (float)(Screen.width * DispatchSegment), 1f);
            return plotVector.normalized * dV;
        }
    }
     

    // Update is called once per frame
    void Update()
    {
        UpdateStatus();
        // DrawIndicator();
    }
     


    private void UpdateStatus()
    {
        if (DragMapper.IsDragStarted)
        {
            Status = DragStatus.Dragging;
            Pivot = DragMapper.DragPoint;
            return;
        }

        if (DragMapper.IsDragging)
        {
            Status = DragStatus.Dragging;
            DragPostion = DragMapper.DragPoint;
            return;
        }

        if (DragMapper.IsRelased)
        {
            Status = DragStatus.Relased;
            DragPostion = DragMapper.DragPoint;
            return;
        }

        Status = DragStatus.Idle;
        DragPostion = null;
        Pivot = null;

    }





}
