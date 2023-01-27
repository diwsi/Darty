using UnityEngine;

public class PowerUp:MonoBehaviour,IPowerUp
{
    public PowerUpTypes PowerUpType;
    public void Activate()
    {
        PowerUpRepository.Instance.Add(PowerUpType);
        var handlers= GameObject.FindObjectsOfType<BaseHandler>();
        foreach (var item in handlers)
        {
            item.Handle();
        }
    }

  
}

