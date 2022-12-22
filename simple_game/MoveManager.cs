using simple_game;
using System.Runtime.CompilerServices;

class MoveManager
{
    static Random rnd = new Random();
    public static bool MoveNext(Board board, Snake snake,Gift gift)
    {
        var head = snake.Head;
        var field = head.Field;
        //var nextMove = NextRandomField(board, snake, field);
        var nextMove = ASearch(board, snake, gift);
        //var nextMove=NextFreeField(board,snake,field);
        //var nextMove=Path(board,snake,field);
        if (nextMove == null) return false;
        if (nextMove.FieldType == FieldType.Gift)
        {
            board.GiftIsEaten = true;
            switch(rnd.Next(6))
            {
                case 0:
                    board.GiftType = GiftType.Snowman;
                    snake.LengthOfSnake++;
                    break;
                case 1:
                    board.GiftType = GiftType.Reindeer;
                    snake.Speed+=10;
                    break;
                case 2:
                    board.GiftType = GiftType.Reindeer;
                    if (snake.Speed > 10)
                    {
                        snake.Speed -= 10;
                    }
                    break;
                default:
                    board.GiftType = GiftType.Apple;
                    snake.LengthOfSnake++;
                    break;
            }
            
        }
        snake.Move(nextMove);
        return true;
    }
    private static Field NextFreeField(Board board, Snake snake, Field field)
    {
        var neighborhoodList = board.GetFieldNeighborhood(field);
        return neighborhoodList.Where(x => !snake.Parts.Select(y => y.Field).Any(y => y.Equals(x))).FirstOrDefault();
    }
    private static Field NextRandomField(Board board, Snake snake, Field field)
    {
        var neighborhoodList = board.GetFieldNeighborhood(field);
        var list = neighborhoodList.Where(x => !snake.Parts.Select(y => y.Field).Any(y => y.Equals(x))).ToList();
        if (list == null || list.Count == 0) return null;
        var index = rnd.Next(list.Count);
        return list[index];
    }

    private static Field ASearch(Board board, Snake snake, Gift gift)
    {
        var start = new SearchedField()
        {
            Field = snake.Head.Field
        };
        var end = new SearchedField()
        {
            Field = gift.Field
        };
        start.SetDistance(end.Field);
        var activeFields = new List<SearchedField>
        {
            start
        };
        var visitedFields = new List<SearchedField>();
        while (activeFields.Any())
        {
            var checkTile = activeFields.OrderBy(x => x.CostDistance).First();

            if (checkTile.Field == end.Field)
            {
                var tile = checkTile;
                while (true)
                {
                    if (tile.Previous.Field == start.Field) return tile.Field;
                    tile = tile.Previous;
                }
            }
            visitedFields.Add(checkTile);
            activeFields.Remove(checkTile);
            var possibilities = GetNewPossibilities(board, checkTile, end.Field);
            foreach(var possibility in possibilities)
            {
                if (visitedFields.Any(x => x.Field == possibility.Field)) continue;
                if (activeFields.Any(x => x.Field==possibility.Field))
                {
                    var existingField = activeFields.First(x => x.Field == possibility.Field);
                    if (existingField.CostDistance > checkTile.CostDistance)
                    {
                        activeFields.Remove(existingField);
                        activeFields.Add(possibility);
                    }
                }
                else
                {
                    activeFields.Add(possibility);
                }
            }
        }
        return null;
    }
    private static List<SearchedField> GetNewPossibilities(Board board, SearchedField currentField, Field targetField)
    {
        var neighborhoods = board.GetFieldNeighborhood(currentField.Field);
        return neighborhoods
            .Where(x=>x.FieldType==FieldType.Empty || x.FieldType==FieldType.Gift)
            .Select(x =>
        {
            var result = new SearchedField()
            {
                Field = x,
                Previous = currentField,
                Cost = currentField.Cost + 1
            };
            result.SetDistance(targetField);
            return result;
        }).ToList();
    }
}
class SearchedField
{
    public Field Field { get; set; }
    public int Distance { get; set; }
    public int Cost { get; set; }
    public int CostDistance => Cost + Distance;
    public SearchedField? Previous { get; set; }
    public void SetDistance(Field target)
    {
        Distance = Math.Abs(Field.X - target.X) + Math.Abs(Field.Y - target.Y);
    }

}