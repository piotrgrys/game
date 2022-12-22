using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace simple_game
{
    class BoardManager
    {
        private Sprite Empty;
        private Sprite HeadOfSnake;
        private Sprite HorizontalPartOfSnake;
        private Sprite VerticalPartOfSnake;
        private Sprite EndOfSnake;
        private Sprite LeftUpSnake;
        private Sprite RightUpSnake;
        private Sprite LeftDownSnake;
        private Sprite RightDownSnake;
        private Sprite Gift;
        private Sprite Apple;
        private Sprite RightPanel;
        private Sprite Snowman;
        private Sprite Reindeer;
        public BoardManager()
        {
            Empty = new Sprite();
            Empty.Texture = TextureManager.FieldTexture;
            RightPanel= new Sprite();
            RightPanel.Texture = TextureManager.RightPanelTexture;
            HeadOfSnake= new Sprite();
            HeadOfSnake.Texture = TextureManager.HeadTexture;
            HorizontalPartOfSnake= new Sprite();
            HorizontalPartOfSnake.Texture = TextureManager.HorizontalTexture;
            VerticalPartOfSnake= new Sprite();
            VerticalPartOfSnake.Texture= TextureManager.VerticalTexture;
            EndOfSnake= new Sprite();
            EndOfSnake.Texture=TextureManager.EndTexture;
            LeftUpSnake = new Sprite();
            LeftUpSnake.Texture = TextureManager.LeftUpTexture;
            LeftDownSnake = new Sprite();
            LeftDownSnake.Texture = TextureManager.LeftDownTexture;
            RightUpSnake = new Sprite();
            RightUpSnake.Texture = TextureManager.RightUpTexture;
            RightDownSnake = new Sprite();
            RightDownSnake.Texture = TextureManager.RightDownTexture;
            Gift = new Sprite();
            Gift.Texture = TextureManager.GiftTexture;
            Apple = new Sprite();
            Apple.Texture = TextureManager.AppleTexture;
            Snowman=new Sprite();
            Snowman.Texture = TextureManager.SnowmanTexture;
            Reindeer = new Sprite();
            Reindeer.Texture = TextureManager.ReindeerTexture;
        }
        public void Draw(Board board, RenderTarget window)
        {
            var fieldToDraw=board.GetChanges();
            var width =(float) (window.Size.X-150) / board.X;
            var height=(float) window.Size.Y / board.Y;
            
            foreach(var item in fieldToDraw)
            {
                switch(item.FieldType)
                {
                    case FieldType.Empty:
                        drawEmpty(window, width, height, item);
                        break;
                    case FieldType.Head:
                        HeadOfSnake.Position = new Vector2f(item.X * width, item.Y * height);
                        HeadOfSnake.Scale = new Vector2f((width - 1) / HeadOfSnake.Texture.Size.X , (height - 1) / HeadOfSnake.Texture.Size.Y);
                        window.Draw(HeadOfSnake);
                        break;
                    case FieldType.Horizontal:
                        drawEmpty(window, width, height, item);
                        HorizontalPartOfSnake.Position = new Vector2f(item.X * width, item.Y * height);
                        HorizontalPartOfSnake.Scale = new Vector2f((width - 1) / HorizontalPartOfSnake.Texture.Size.X, (height - 1) / HorizontalPartOfSnake.Texture.Size.Y);
                        window.Draw(HorizontalPartOfSnake);
                        break;
                    case FieldType.Vertical:
                        drawEmpty(window, width, height, item);
                        VerticalPartOfSnake.Position = new Vector2f(item.X * width, item.Y * height);
                        VerticalPartOfSnake.Scale = new Vector2f((width - 1) / VerticalPartOfSnake.Texture.Size.X, (height - 1) / VerticalPartOfSnake.Texture.Size.Y);
                        window.Draw(VerticalPartOfSnake);
                        break;
                    case FieldType.End:
                        drawEmpty(window, width, height, item);
                        EndOfSnake.Position = new Vector2f(item.X * width, item.Y * height);
                        EndOfSnake.Scale = new Vector2f((width - 1) / EndOfSnake.Texture.Size.X, (height - 1) / EndOfSnake.Texture.Size.Y);
                        window.Draw(EndOfSnake);
                        break;
                    case FieldType.LeftUp:
                        drawEmpty(window, width, height, item);
                        LeftUpSnake.Position = new Vector2f(item.X * width, item.Y * height);
                        LeftUpSnake.Scale = new Vector2f((width - 1) / LeftUpSnake.Texture.Size.X, (height - 1) / LeftUpSnake.Texture.Size.Y);
                        window.Draw(LeftUpSnake);
                        break;
                    case FieldType.LeftDown:
                        drawEmpty(window, width, height, item);
                        LeftDownSnake.Position = new Vector2f(item.X * width, item.Y * height);
                        LeftDownSnake.Scale = new Vector2f((width - 1) / LeftDownSnake.Texture.Size.X, (height - 1) / LeftDownSnake.Texture.Size.Y);
                        window.Draw(LeftDownSnake);
                        break;
                    case FieldType.RightUp:
                        drawEmpty(window, width, height, item);
                        RightUpSnake.Position = new Vector2f(item.X * width, item.Y * height);
                        RightUpSnake.Scale = new Vector2f((width - 1) / RightUpSnake.Texture.Size.X, (height - 1) / RightUpSnake.Texture.Size.Y);
                        window.Draw(RightUpSnake);
                        break;
                    case FieldType.RightDown:
                        drawEmpty(window, width, height, item);
                        RightDownSnake.Position = new Vector2f(item.X * width, item.Y * height);
                        RightDownSnake.Scale = new Vector2f((width - 1) / RightDownSnake.Texture.Size.X, (height - 1) / RightDownSnake.Texture.Size.Y);
                        window.Draw(RightDownSnake);
                        break;
                    case FieldType.Gift:
                        drawEmpty(window, width, height, item);
                        Gift.Position = new Vector2f(item.X * width, item.Y * height);
                        Gift.Scale = new Vector2f((width - 1) / Gift.Texture.Size.X, (height - 1) / Gift.Texture.Size.Y);
                        window.Draw(Gift);
                        break;
                    default:
                        break;
                }
            }
            board.ResetChanges();
        }

        internal void DrawRightPanel(Board board, Snake snake,RenderWindow window)
        {
            RightPanel.Position= new Vector2f(window.Size.X - 150, 0);
            RightPanel.Scale = new Vector2f(150f / RightPanel.Texture.Size.X, (float)window.Size.Y / RightPanel.Texture.Size.Y);
            window.Draw(RightPanel);
            if(board.GiftType == GiftType.Apple)
            {
                Apple.Position = new Vector2f(window.Size.X - 150, 0);
                Apple.Scale= new Vector2f(150f / Apple.Texture.Size.X, 150f / Apple.Texture.Size.Y);
                window.Draw(Apple);
                var text = TextManager.IncreaseChain;
                text.Position = new Vector2f(window.Size.X - 150, 150);
                window.Draw(text);

            }
            if (board.GiftType == GiftType.Snowman)
            {
                Snowman.Position = new Vector2f(window.Size.X - 150, 0);
                Snowman.Scale = new Vector2f(150f / Snowman.Texture.Size.X, 150f / Snowman.Texture.Size.Y);
                window.Draw(Snowman);
                var text = TextManager.DecreaseSpeed;
                text.Position = new Vector2f(window.Size.X - 150, 150);
                window.Draw(text);
            }
            if (board.GiftType == GiftType.Reindeer)
            {
                Reindeer.Position = new Vector2f(window.Size.X - 150, 0);
                Reindeer.Scale = new Vector2f(150f / Reindeer.Texture.Size.X, 150f / Reindeer.Texture.Size.Y);
                window.Draw(Reindeer);
                var text = TextManager.IncreaseSpeed;
                text.Position = new Vector2f(window.Size.X - 150, 150);
                window.Draw(text);
            }
            if (board.GiftType == GiftType.Surprise)
            {
                Gift.Position = new Vector2f(window.Size.X - 150, 0);
                Gift.Scale = new Vector2f(150f / Gift.Texture.Size.X, 150f / Gift.Texture.Size.Y);
                window.Draw(Gift);
            }
            var speed = TextManager.Speed;
            speed.Position = new Vector2f(window.Size.X - 140, 200);
            window.Draw(speed);
            var speedValue = TextManager.SpeedValue;
            speedValue.Position = new Vector2f(window.Size.X - 140, 245);
            speedValue.DisplayedString = Convert.ToString(60-snake.Speed / 10);
            window.Draw(speedValue);
            var length = TextManager.Length;
            length.Position = new Vector2f(window.Size.X - 140, 290);
            window.Draw(length);
            var lengthValue = TextManager.LengthVaue;
            lengthValue.Position = new Vector2f(window.Size.X - 140, 335);
            lengthValue.DisplayedString = snake.LengthOfSnake.ToString();
            window.Draw(lengthValue);
            var score = TextManager.Score;
            score.Position = new Vector2f(window.Size.X - 140, 380);
            window.Draw(score);
            var scoreValue = TextManager.ScoreValue;
            scoreValue.Position = new Vector2f(window.Size.X - 140, 425);
            scoreValue.DisplayedString =board.Score.ToString();
            window.Draw(scoreValue);

        }

        private void drawEmpty(RenderTarget window, float width, float height, Field item)
        {
            Empty.Position = new Vector2f(item.X * width, item.Y * height);
            Empty.Scale = new Vector2f((width - 1) / Empty.Texture.Size.X, (height - 1) / Empty.Texture.Size.Y);
            window.Draw(Empty);
        }
    }
}
