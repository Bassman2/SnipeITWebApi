namespace SnipeITWebApi;

/// <summary>
/// Represents a named item in the Snipe-IT system, identified by an ID and a name.
/// </summary>
[DebuggerDisplay("{this.GetType().Name}: {Id} : {Name}")]
public class NamedItem 
{
    internal NamedItem()
    { }

    internal NamedItem(int id, string? name = null)
    {
        Id = id;
        Name = name;
    }

    internal NamedItem(NamedItemModel model)
    {
        Id = model.Id;
        Name = model.Name;
    }

    //internal NamedItemModel ToCreate()
    //{
    //    ArgumentException.ThrowIfNullOrWhiteSpace(Name, nameof(Name));
    //    return new()
    //    {
    //        Name = Name,
    //    };
    //}

    internal NamedItemModel ToModel()
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(Name, nameof(Name));
        return new()
        {
            Id = Id,
            Name = Name,
        };
    }

    //internal NamedItemModel ToPatch()
    //{
    //    ArgumentException.ThrowIfNullOrWhiteSpace(Name, nameof(Name));
    //    return new()
    //    {
    //        Name = Name,
    //    };
    //}

    /// <summary>
    /// Returns a string representation of the <see cref="NamedItem"/>.
    /// </summary>
    /// <returns>A string containing the ID and name of the item.</returns>
    public override string ToString() => $"{Id} : {Name}";

    /// <summary>
    /// Determines whether the specified object is equal to the current <see cref="NamedItem"/>.
    /// </summary>
    /// <param name="obj">The object to compare with the current item.</param>
    /// <returns><c>true</c> if the specified object is equal to the current item; otherwise, <c>false</c>.</returns>
    public override bool Equals(object? obj) => obj is NamedItem item && Id == item.Id && Name == item.Name;

    /// <summary>
    /// Returns the hash code for the current <see cref="NamedItem"/>.
    /// </summary>
    /// <returns>The hash code for the current item.</returns>
    public override int GetHashCode() => base.GetHashCode();

    /// <summary>
    /// Implicitly converts a tuple containing an ID and name to a <see cref="NamedItem"/>.
    /// </summary>
    /// <param name="item">A tuple containing the ID and name of the item.</param>
    /// <returns>A new <see cref="NamedItem"/> instance with the specified ID and name.</returns>
    public static implicit operator NamedItem((int, string) item) => new() { Id = item.Item1, Name = item.Item2 };

    /// <summary>
    /// Gets or sets the unique identifier of the item.
    /// </summary>
    public int Id { get; internal set; }

    /// <summary>
    /// Gets or sets the name of the item.
    /// </summary>
    public string? Name { get; set;  }
}
