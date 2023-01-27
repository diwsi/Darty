public class VectorMotion : BaseMotion
{
    public override void Move()
    {
        gameObject.transform.position += Direction.normalized * Speed;
    }

}
