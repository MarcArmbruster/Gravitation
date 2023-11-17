namespace GravitationNET
{
    public class ForceCalculator
    {
        /// <summary>
        /// Value Unit: m³/(kg s²)
        /// </summary>
        private static double GravitationConstant = 6.672 * Math.Pow(10, -11);

        /// <summary>
        /// Force value in N
        /// </summary>
        /// <param name="massOne">Mass of one object</param>
        /// <param name="massTwo">Mass of another object</param>
        /// <param name="distance">Distance between the objects</param>
        /// <returns>The gravitation force.</returns>
        public double OutsideGravitationForce(double massOne, double massTwo, double distance)
        {
            if (distance < 0d)
            {
                throw new InvalidOperationException("Distance must be positive");
            }

            if (massOne == 0d || massTwo == 0d)
            {
                throw new InvalidOperationException("Gravitation works only on objects with a mass");
            }
            else
            {
                return GravitationConstant * massOne * massTwo / (distance * distance);
            }
        }

        /// <summary>
        /// Force value in N if the second object is within the first object
        /// </summary>
        /// <param name="massOne">Mass of a big object</param>
        /// <param name="massTwo">Mass of another (smaller) object</param>
        /// <param name="massOneRadius">Radius of the greater object (object one)</param>
        /// <param name="innerDistance">The distinct of the second object from center of first object</param>
        /// <returns>The gravitation force.</returns>
        public double InsideGravitationForce(
            double massOne,
            double massTwo,
            double massOneRadius,
            double innerDistance)
        {
            if (innerDistance < 0d)
            {
                throw new InvalidOperationException("Distance must be positive");
            }

            if (massOne == 0d || massTwo == 0d)
            {
                throw new InvalidOperationException("Gravitation works only on objects with a mass");
            }

            ////if (massOneRadius <= 0d)
            ////{
            ////    throw new InvalidOperationException("Radius must be greater than zero!");
            ////}

            if (massOneRadius < innerDistance)
            {
                return OutsideGravitationForce(massOne, massTwo, innerDistance);
            }

            if (massOne == 0d || massTwo == 0d)
            {
                throw new InvalidOperationException("Gravitation works only on objects with a mass");
            }
            else
            {
                return GravitationConstant * massOne * massTwo * innerDistance / (massOneRadius * massOneRadius * massOneRadius);
            }
        }
    }
}
