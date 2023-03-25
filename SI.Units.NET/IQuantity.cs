﻿namespace SI.Units.NET
{
    /// <summary>
    /// IQuantity defines the interface for all Quantity based types, which
    /// are defined by the Internation System of Units
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IQuantity<T> : IFormattable,
                                    IMathOperations<T>,
                                    IEquatable<T>,
                                    IComparable<T> where T : struct
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

        string ToString(string? format);
    }
}
