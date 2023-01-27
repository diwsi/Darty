
using UnityEngine;

public abstract class BaseMotion : MonoBehaviour, IMotion
{
    public Vector3 Direction;
    public float Speed;

    public bool RandomSpeed;
    public float RandomMin;
    public float RandomMax;


    public float SpeedInt
    {
        get { return Speed; }
        set { Speed = value; }
    }

    void Start()
    {
        RandomiseSpeed();
    }

    void Update()
    {
        Move();

    }

    public abstract void Move();
    public virtual void RandomiseSpeed()
    {
        if (RandomSpeed)
        {
            Speed = Random.Range(RandomMin, RandomMax);
        }
    }

}

