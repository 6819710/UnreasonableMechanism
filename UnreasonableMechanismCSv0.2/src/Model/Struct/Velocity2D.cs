namespace UnrealMechanismCS
{
    public struct Velocity2D
    {
        public Vector2D Velocity;

        public Velocity2D(double speed, double direction)
        {
            this.Velocity.Magnitude = speed;
            this.Velocity.Direction = direction;
        }

        public static Velocity2D operator+ (Velocity2D vel, Acceleration2D acc)
        {
            Velocity2D output = vel + acc;
            if(output.Velocity.Magnitude > acc.TermV)
            {
                output.Velocity.Magnitude = acc.TermV;
            }

            return output;
        }
    }
}
