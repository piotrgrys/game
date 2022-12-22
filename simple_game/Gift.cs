using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simple_game
{
    internal class Gift
    {
        public Field Field { get; internal set; }
        private Board Board;
        public Gift(Board board) 
        {
            Board = board;
        }
        public bool IsSet
        {
            get
            {
                if(Field == null) return false;
                return Field.FieldType==FieldType.Gift;
            }
        }

        internal void Set(Field field)
        {
            Board.UpdateFieldType(field, FieldType.Gift);
            Field = field;
        }
    }
    internal enum GiftType
    {
        None,
        Surprise,
        Apple,
        Snowman,
        Reindeer
    }
}
