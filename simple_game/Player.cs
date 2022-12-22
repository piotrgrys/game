using SFML.Graphics;
using SFML.System;
using SFML.Window;

class Player 
{
    private Sprite santa;
    public Field Field;
    public bool lastMoveLeft;
    public bool lastMoveRight;
    public bool lastMoveUp;
    public bool lastMoveDown;
    public Player (Field startPosition) 
    {
        this.Field = startPosition;
        santa = new Sprite();
        santa.Texture = TextureManager.SantaTexture;
    }
    public void keyHandler(Board board)
    {
        bool moveLeft = Keyboard.IsKeyPressed(Keyboard.Key.Left);
        bool moveRight = Keyboard.IsKeyPressed(Keyboard.Key.Right);
        bool moveUp = Keyboard.IsKeyPressed(Keyboard.Key.Up);
        bool moveDown = Keyboard.IsKeyPressed(Keyboard.Key.Down);

        bool isMove = moveLeft || moveRight || moveUp || moveDown;

        if(isMove)
        {
            var x = Field.X;
            var y=Field.Y;
            if (moveLeft && !lastMoveLeft)
            {
                if (x == 0)
                {
                    x = board.X-1;
                }
                else
                { 
                    x --;
                }
            }
            if (moveRight && !lastMoveRight)
            {
                if(x==board.X-1)
                {
                    x = 0;
                }
                else
                {
                    x++;
                }
            }
            if (moveUp && ! lastMoveUp)
            {
                if(y==0)
                {
                    y = board.Y-1;
                }
                else
                {
                    y--;
                }
            }
            if (moveDown && !lastMoveDown)
            {
                if(y==board.Y-1)
                {
                    y = 0;
                }
                else
                {
                    y++;
                }
            }
            board.UpdateFieldType(Field, Field.FieldType);
            Field = board.GetField(x, y);
        } 
        lastMoveLeft= moveLeft;
        lastMoveRight = moveRight;
        lastMoveDown = moveDown;
        lastMoveUp = moveUp;
    }
    public void update(Board board) { 
        this.keyHandler(board);
    }

    public void draw(Board board,RenderTarget window) 
    {
        var width = (float)(window.Size.X - 150) / board.X;
        var height = (float)window.Size.Y / board.Y;
        santa.Position = new Vector2f(Field.X * width, Field.Y * height);
        santa.Scale = new Vector2f((width - 1) / santa.Texture.Size.X, (height - 1) / santa.Texture.Size.Y);
        window.Draw(santa);
    }
}