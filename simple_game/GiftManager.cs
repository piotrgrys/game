using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simple_game
{
    
    internal class GiftManager
    {
        static Random rnd = new Random();
        public static bool SetItem(Board board, Gift gift)
        {
            if(!gift.IsSet)
            {
                var field = GetField(board);
                gift.Set(field);
            }
            return true;
        }
        private static Field GetField(Board board)
        {
            Field result= null;
            while (result is null)
            {
                var indexX = rnd.Next(board.X);
                var indexY = rnd.Next(board.Y);
                var field = board.GetField(indexX, indexY);
                if(field.FieldType==FieldType.Empty)
                {
                    result= field;
                }
            }
            return result;
        }
    }
}
