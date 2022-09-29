namespace TheOmenDen.Shared.Interfaces.Models;

/// <summary>
/// A common marker interface
/// </summary>
public interface IEntity
{
    /// <summary>
    /// Provides a unique identity containing various information regarding the underlying entity
    /// </summary>
    /// <value>
    /// <see cref="IEntityKey"/>
    /// </value>
    IEntityKey Key { get; }
}

/// <summary>
/// A common marker interface
/// <inheritdoc cref="IComparable{T}"/>
/// <inheritdoc cref="IEquatable{T}" />
/// </summary>
public interface IEntity<T> : IEntity, IComparable<T>, IEquatable<T>
{
    /// <summary>
    /// Gets or sets the underlying entity
    /// </summary>
    T Entity { get; init; }
}