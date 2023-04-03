using System.Numerics;

namespace SI.Units.NET
{
    /// <summary>
    /// IQuantity defines the interface for all Quantity based types, which
    /// are defined by the International System of Units
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IQuantity<T> : IFormattable,
                                    IParsable<T>,
                                    IMathOperations<T>,
                                    IEquatable<T>,
                                    IEqualityOperators<T, T, bool>,
                                    IIncrementOperators<T>,
                                    IDecrementOperators<T>,
                                    IAdditionOperators<T, T, T>,
                                    ISubtractionOperators<T, T, T>,
                                    IDivisionOperators<T, T, double>,
                                    IComparisonOperators<T,T,bool>,
                                    IUnaryNegationOperators<T, T>,
                                    IMultiplyOperators<T, double, T>,
                                    IModulusOperators<T, double, T>,
                                    IComparable<T> where T : struct, IQuantity<T>
    {
        /// <summary>
        /// Quantity value (amount)
        /// </summary>
        public double Value { get; init; }

        /// <summary>
        /// Convert Quantity to Base Unit of Measure
        /// </summary>
        /// <returns></returns>
        T ToBase();

        /// <summary>
        /// Return Quantity value in Base Unit of Measure
        /// </summary>
        /// <returns>Value in base unit of measure</returns>
        double BaseValue();

        /// <summary>
        /// Formats the value of the current instance using the specified format.
        /// </summary>
        /// <param name="format">The format to use</param>
        /// <returns>The value of the current instance in the specified format</returns>
        string ToString(string? format);
    }
}
