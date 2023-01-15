using Assets.Code.DragIndicator;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indicator : MonoBehaviour
{

    public DragDispatcher2D Dispatcher;
    // Start is called before the first frame update
    void Start()
    {
        if (Dispatcher == null)
        {
            Dispatcher = gameObject.GetComponent<DragDispatcher2D>();
            if (Dispatcher == null)
            {
                Debug.LogError("No Dispatcher Found");
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Dispatcher == null) return;

        
        switch (Dispatcher.Status)
        {
            case DragStatus.Idle:
                break;
            case DragStatus.Dragging:
                DrawIndicator();
                break;
            case DragStatus.Relased:
                break;
            default:
                break;
        }
    }
 

    void DrawIndicator()
    {
        var delta = Dispatcher.Delta;         
        Debug.DrawRay(gameObject.transform.position, 3f * delta, Color.red); 
        var zRotation = Mathf.Atan2(delta.y, delta.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, zRotation + 90);
    }


}
