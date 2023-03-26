namespace SI.Units.NET
{
    public interface IMathOperations<T>
    {
        /// <summary>
        /// Returns the square root of Quantity.
        /// Unit of measure is preserved
        /// </summary>
        /// <returns>Square root of quantity</returns>
        T Sqrt();

        /// <summary>
        /// Returns the cubic root of Quantity.
        /// Unit of measure is preserved
        /// </summary>
        /// <returns>Cubic root of quantity</returns>
        T Cbrt();

        /// <summary>
        /// Returns the logarithm of Quantity.
        /// Unit of measure is preserved
        /// </summary>
        /// <returns>Log of quantity</returns>
        T Log();

        /// <summary>
        /// Returns the base 2 logarithm of Quantity.
        /// Unit of measure is preserved
        /// </summary>
        /// <returns>Base 2 logarithm of Quantity</returns>
        T Log2();

        /// <summary>
        /// Returns the base 10 logarithm of Quantity.
        /// Unit of measure is preserved
        /// </summary>
        /// <returns>Base 10 logarithm of Quantity</returns>
        T Log10();

        /// <summary>
        /// Return Quantity raised to specified power
        /// </summary>
        /// <param name="power">Power to raise Quantity by</param>
        /// <returns>Quantity raised to power</returns>
        T Pow(double power);

        /// <summary>
        /// Return absolute value of Quantity.
        /// Unit of measure is preserved.
        /// </summary>
        /// <returns>Absolute value of Quantity</returns>
        T Abs();

        /// <summary>
        /// Returns the largest integral value less than or equal to Quantity
        /// Unit of measure is preserved.
        /// </summary>
        /// <returns>Largest integral value less than or equal to Quantity</returns>
        T Floor();

        /// <summary>
        /// Returns the smallest integral value greater than or equal to Quantity.
        /// Unit of measure is preserved.
        /// </summary>
        /// <returns>Smallest integral value greater than or equal to Quantity</returns>
        T Ceiling();

        /// <summary>
        /// Calculates the integral part of a Quantity.
        /// Unit of measure is preserved.
        /// </summary>
        /// <returns>Integral part of a Quantity</returns>
        T Truncate();

        /// <summary>
        /// Rounds a Quantity to the nearest integer
        /// </summary>
        /// <returns></returns>
        T Round();

        /// <summary>
        /// Rounds a Quantity to the specified number of fractional digits.
        /// </summary>
        /// <param name="digits">Number of digits of precision</param>
        /// <returns>Quantity rounded to specified number of digits</returns>
        T Round(int digits);

        /// <summary>
        /// Returns true if Quantity value is NegativeInfinity, otherwise false
        /// </summary>
        /// <returns>True if Quantity Value is NegativeInfinity, otherwise false</returns>
        bool IsNegativeInfinity();

        /// <summary>
        /// Returns true if Quantity value is PositiveInfinity, otherwise false
        /// </summary>
        /// <returns>True if Quantity Value is PositiveInfinity, otherwise false</returns>
        bool IsPositiveInfinity();

        /// <summary>
        /// Returns true if Quantity value is NaN, otherwise false
        /// </summary>
        /// <returns>True if Quantity Value is NaN, otherwise false</returns>
        bool IsNaN();

        /// <summary>
        /// Returns true if Quantity value is PositiveInfinity or NegativeInfinity, otherwise false
        /// </summary>
        /// <returns>True if Quantity Value is PositiveInfinity or NegativeInfinity, otherwise false</returns>
        bool IsInfinity();


        int Sign();
    }
}
