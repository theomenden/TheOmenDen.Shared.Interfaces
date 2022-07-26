namespace TheOmenDen.Shared.Interfaces.Models;
/// <summary>
/// A set of constraints for a given Entity
/// </summary>
public interface IEntityKey
{
    /// <summary>
    /// The entity's unique Id
    /// </summary>
    /// <value>
    /// A unique Id
    /// </value>
    Guid Id { get; }

    /// <summary>
    /// The originating date of the entity
    /// </summary>
    /// <value>
    /// A <see cref="DateTime"/> for when the entity was first initialized/created
    /// </value>
    DateTime CreatedAt { get; }

    /// <summary>
    /// The location where the entity originated - The "Where"
    /// </summary>
    /// <value>
    /// A provided <see cref="ITenant"/> that we can subscribe to
    /// </value>
    public ITenant Tenant { get; }

    /// <summary>
    /// The originator/creator of the entity - The "Who" 
    /// </summary>
    /// <value>
    /// A record of the <see cref="IUser"/> who created of this entity
    /// </value>
    public IUser Creator { get; }
}
