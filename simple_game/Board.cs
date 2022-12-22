using SFML.Graphics;
using SFML.System;
using SFML.Window;
using simple_game;

class Board
{
    public int X{get;init;}
    public int Y{get;init;}
    public bool GiftIsEaten { get; set; } = false;
    public int Score { get; set; } = 0;
    public GiftType GiftType { get; set; }
    private Dictionary<int,Dictionary<int,Field>> Fields;
    private List<Field> ChangedFields=new ();
    ///Columns from left to right
    ///Rows from up to down
    public Board(int NumberOfColumns, int NumberOfRows)
    {
        this.X=NumberOfColumns;
        this.Y=NumberOfRows;
        Fields=new Dictionary<int, Dictionary<int, Field>>();
        for(int x=0;x<NumberOfColumns;x++)
        {
            var wiersz=new Dictionary<int,Field>();
            for(int y=0;y<NumberOfRows;y++)
            {
                var field = new Field(x, y);
                wiersz.Add(y,field);
                ChangedFields.Add(field);
            }
            Fields.Add(x,wiersz);
        }
        
    }
    public List<Field> GetFieldNeighborhood(Field field)
    {
        var result=new List<Field>();
        result.Add(Fields[LeftField(field.X)][field.Y]);
        result.Add(Fields[field.X][UpField(field.Y)]);
        result.Add(Fields[RightField(field.X)][field.Y]);
        result.Add(Fields[field.X][DownField(field.Y)]);
        return result;
    }
    private int LeftField(int x)
    {
        if(x==0) return X-1;
        return x-1;
    }
    private int RightField(int x)
    {
        if(x==X-1) return 0;
        return x+1;
    }
    private int UpField(int y)
    {
        if(y==Y-1) return 0;
        return y+1;
    }
    private int DownField(int y)
    {
        if(y==0) return Y-1;
        return y-1;
    }
    public Field GetField(int x,int y)
    {
        return Fields[x][y];
    }
    public List<Field> GetChanges()
    {
        return ChangedFields;
    }
    public void UpdateFieldType(Field field, FieldType fieldType)
    {
        field.FieldType = fieldType;
        ChangedFields.Add(field);
    }
    public void ResetChanges()
    {
        ChangedFields = new List<Field>();
    }
}
class SnakeItem
{
    public Field Field{get;set;}
    public SnakeItem Previous { get; set; }
    public SnakeItem Next { get; set; }
    public SnakeItem(Field field, SnakeItem previous, SnakeItem next)
    {
        Field= field;
        Previous = previous;
        Next = next;
    }
}