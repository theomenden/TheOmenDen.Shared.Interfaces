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
