using SFML.Graphics;
using SFML.System;

class Field: IEquatable<Field>
{

    public int X { get; set; }
    public int Y { get; set; }
    public FieldType FieldType { get; set; } = FieldType.Empty;
    public Field(int x, int y)
    {
        this.X = x;
        this.Y = y;
     }
    public override bool Equals(object obj) => this.Equals(obj as Field);
    public bool Equals(Field p)
    {
        if (p is null)
        {
            return false;
        }
        if (Object.ReferenceEquals(this, p))
        {
            return true;
        }
        if (this.GetType() != p.GetType())
        {
            return false;
        }
        return (X == p.X) && (Y == p.Y);
    }
    public override int GetHashCode() => (X, Y).GetHashCode();
    public static bool operator ==(Field lhs, Field rhs)
    {
        if (lhs is null)
        {
            if (rhs is null)
            {
                return true;
            }

            // Only the left side is null.
            return false;
        }
        // Equals handles case of null on right side.
        return lhs.Equals(rhs);
    }
    public static bool operator !=(Field lhs, Field rhs) => !(lhs == rhs);
}
