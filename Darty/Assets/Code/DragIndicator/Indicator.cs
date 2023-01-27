using Assets.Code.DragIndicator;
using UnityEngine;
using Assets.Code.Core;
using Assets.Code.DragDispatcher;
using System.Collections;

public class Indicator : MonoBehaviour
{


    public GameObject DartPrefab;
    GameObject currentDart;
   public LineRenderer lineRenderer;
    bool locked;
   public float LockTimeout;
    // Start is called before the first frame update
    void Start()
    {
        initDart();
        lineRenderer.SetPosition(0,transform.localPosition);
        lineRenderer.SetPosition(1, transform.localPosition);
    }


    public void DragStatusChanged(DragEvent dragEvent)
    {
        if (locked)
        {
            return;
        }
        switch (dragEvent.Status)
        {
            case DragStatus.Idle:
                break;
            case DragStatus.Dragging:
                DrawIndicator(dragEvent);
                break;
            case DragStatus.Relased:
                launchDart(dragEvent.Delta.magnitude);
                break;
            default:
                break;
        }
    }


    void DrawIndicator(DragEvent dragEvent)
    {
        lineRenderer.SetPosition(1, 3f * dragEvent.Delta);
       // Debug.DrawRay(transform.position, 3f * dragEvent.Delta, Color.red);
        transform.LookAt2D(dragEvent.Delta);
    }

    void launchDart(float force)
    {
        if (currentDart == null) return;
        currentDart.transform.parent = null;
        currentDart.GetComponent<ILaunchable>().Launch(force);
        currentDart = null;
        lineRenderer.SetPosition(1, transform.localPosition);
        StartCoroutine(Lock());
    }
    void initDart()
    {
        currentDart = Instantiate(DartPrefab, transform);
    }

    IEnumerator Lock()
    {
        locked = true;
        yield return new WaitForSeconds(LockTimeout);
        locked = false;
        initDart();
    }

}
