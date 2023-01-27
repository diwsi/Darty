
using UnityEngine;

public class PowerUpManager:MonoBehaviour
{
    PowerUpRepository Repository
    {
        get
        {
            return PowerUpRepository.Instance;
        }
    }

    public void ClearRepository()
    {
        Repository.Clear();
    }
}

