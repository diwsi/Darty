
using UnityEngine;

public abstract class BaseHandler : MonoBehaviour, IPowerUpHandler
{

   public PowerUpRepository Repository
    {
        get
        {
           return PowerUpRepository.Instance;
        }
    }

    void Start()
    {
        Handle();
    }
    public abstract void Handle();
}

