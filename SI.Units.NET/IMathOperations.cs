namespace SI.Units.NET
{
    public interface IMathOperations<T>
    {
        T Sqrt();

        T Cbrt();

        T Log();

        T Log2();

        T Log10();

        T Pow(double exp);

        T Abs();

        T Floor();

        T Ceiling();

        T Truncate();

        T Round();

        T Round(int digits);

        bool IsNegativeInfinity();

        bool IsPositiveInfinity();

        bool IsNaN();

        bool IsInfinity();
    }
}
