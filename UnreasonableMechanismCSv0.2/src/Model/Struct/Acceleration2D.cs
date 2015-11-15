namespace UnrealMechanismCS
{
    public struct Acceleration2D
    {
        public Vector2D Acceleration;
        public double TermV;

        public Acceleration2D(Vector2D deltaV, double termV)
        {
            this.Acceleration = deltaV;
            this.TermV = termV;
        }
    }
}
