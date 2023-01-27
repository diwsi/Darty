
using System.Collections.Generic;
using System.Linq;

public class PowerUpRepository
{

    static PowerUpRepository instance;

  public  static PowerUpRepository Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new PowerUpRepository();
            }
            return instance;
        }
    }
    List<PowerUpTypes> PowerUps;
    private PowerUpRepository()
    {
        Clear();
    }

    public void Clear()
    {
        PowerUps = new List<PowerUpTypes>();
    }

    public void Add(PowerUpTypes powerUp)
    {
        if (!HasPowerUp(powerUp))
        {
            PowerUps.Add(powerUp);
        }        
    }

    public bool HasPowerUp(PowerUpTypes powerUp)
    {
        return PowerUps.Any(d => d == powerUp);
    }

}

