
public class SlowDownHandler : BaseHandler
{
    
    public override void Handle()
    {
        if (Repository.HasPowerUp(PowerUpTypes.SlowDown))
        {
           var motion= GetComponentInChildren<IMotion>();
            if (motion != null)
            {
                motion.SpeedInt *= 0.5f;
            }
        }
        
    }
}

