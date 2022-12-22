class Snake
{
    public List<SnakeItem> Parts;
    public int LengthOfSnake = 5;
    public int Speed = 500;
    private Board Board;
    public SnakeItem Head { get; internal set; }
    public Snake(Board board,Field field)
    {
        Board = board;
        var snakeItem = new SnakeItem(field, null, null);
        Head = snakeItem;
        Parts = new List<SnakeItem>
        {
            snakeItem
        };
        Board.UpdateFieldType(field, FieldType.Head);
    }
    private void extendSnake(Field field)
    {
        var snakeItem = new SnakeItem(field,Head,null);
        Board.UpdateFieldType(field,FieldType.Head);
        Board.UpdateFieldType(Head.Field, GetFieldType(Head.Previous?.Field,Head.Field,field));
        Head.Next= snakeItem;
        Parts.Add(snakeItem);
        Head= snakeItem;
    }
    private FieldType GetFieldType(Field previous, Field current, Field next)
    {
        if (previous is null) return FieldType.End;
        if (next is null) return FieldType.Head;
        if (previous.X == current.X)
        {
            if(current.X == next.X) return FieldType.Vertical;
            var ydif = previous.Y - current.Y;
            var xdif = current.X - next.X;
            var start = "";
            if (ydif == -1) start = "DownToUp";
            if (ydif == 1) start = "UpToDown";
            if (ydif == -(Board.Y - 1)) start = "UpToDown";
            if (ydif == Board.Y - 1) start = "DownToUp";
            var end = "";
            if (xdif == -1) end = "RightToLeft";
            if (xdif == 1) end = "LeftToRight";
            if (xdif == -(Board.X - 1)) end = "LeftToRight";
            if (xdif == Board.X - 1) end = "RightToLeft";
            
            if (start == "UpToDown" && end == "LeftToRight") return FieldType.LeftDown;
            if (start == "UpToDown" && end == "RightToLeft") return FieldType.RightDown;
            if (start == "DownToUp" && end == "LeftToRight" ) return FieldType.LeftUp;
            if (start == "DownToUp" && end == "RightToLeft") return FieldType.RightUp;
        }
        if(previous.Y == current.Y)
        {
            if(current.Y == next.Y) return FieldType.Horizontal;
            var xdif=previous.X- current.X;
            var ydif = current.Y - next.Y;
            var start = "";
            if (xdif == -1) start = "LeftToRight";
            if (xdif == 1) start = "RightToLeft";
            if (xdif == -(Board.X - 1)) start = "RightToLeft";
            if (xdif == Board.X - 1) start = "LeftToRight";
            var end = "";
            if (ydif == -1) end = "UpToDown";
            if (ydif == 1) end = "DownToUp";
            if (ydif == -(Board.Y - 1)) end = "DownToUp";
            if (ydif == Board.Y - 1) end = "UpToDown";
            if (start == "LeftToRight" && end == "UpToDown") return FieldType.LeftDown;
            if (start == "RightToLeft" && end == "UpToDown") return FieldType.RightDown;
            if (start == "LeftToRight" && end == "DownToUp") return FieldType.LeftUp;
            if (start == "RightToLeft" && end == "DownToUp") return FieldType.RightUp;
        }
        throw new Exception("Unexpected direction");
    }
    public void Move(Field field)
    {
        extendSnake(field);
        if(Parts.Count> LengthOfSnake)
        {
            var snakeItem=Parts.First();
            Board.UpdateFieldType(snakeItem.Field, FieldType.Empty);
            Parts.RemoveAt(0);
            if(Parts.Count>1)
            {
                Board.UpdateFieldType(Parts.First().Field, FieldType.End);
            }
        }
    }
}
