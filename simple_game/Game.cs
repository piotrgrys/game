using SFML.Graphics;
using SFML.System;
using SFML.Window;
using simple_game;
using System.Diagnostics.Metrics;

class Game
{
    private const int WIDTH = 640;
    private const int HEIGHT = 480;
    private const string TITLE = "Santa challange";
    private RenderWindow window;
    private VideoMode mode = new VideoMode(WIDTH, HEIGHT);
    bool gameStarted = true;
    Sprite background;
    Player player;
    Board board;
    BoardManager boardManager;
    Snake snake;
    Gift gift;
    public Game()
    {
        this.window = new RenderWindow(this.mode, TITLE);
        this.window.SetVerticalSyncEnabled(true);
        this.window.Closed += (sender, args) => {
            this.window.Close(); 
        };

        TextureManager.LoadTexture();
        TextManager.LoadTexts();

        background = new Sprite();
        background.Texture = TextureManager.BackgroundTexture;
        startGame();
    }
    public void run() 
    {
        var boardClock = new Clock();
        while(this.window.IsOpen)
        {
            this.handleEvents();
            if (gameStarted)
            {
                player.update(board);
                if (boardClock.ElapsedTime.AsMilliseconds() > snake.Speed)
                {
                    this.update();
                    boardClock.Restart();
                }

            }
            else
            {
                if(Keyboard.IsKeyPressed(Keyboard.Key.S))
                {
                    startGame();
                }
            }
            this.draw();
            if(player.Field.FieldType == FieldType.Empty)
            {
                finishGame();
            }
        }
    }
    private void handleEvents()
    {
        this.window.DispatchEvents();
    }
    private void update() {
        GiftManager.SetItem(board, gift);
        var result=MoveManager.MoveNext(board,snake,gift);
        if (!result)
        {
            finishGame();
            return;
        }
        board.Score += 1;
    }

    private void draw() 
    {
        boardManager.DrawRightPanel(board,snake, this.window);
        boardManager.Draw(board, this.window);
        player.draw(board,this.window);
        this.window.Display();
    }

    private void finishGame()
    {
        var gameIsOver = TextManager.GameIsOverText;
        gameIsOver.Position = new Vector2f(100, HEIGHT / 2 -100 - gameIsOver.CharacterSize / 2);
        window.Draw(gameIsOver);
        var startAgain = TextManager.StartAgain;
        startAgain.Position = new Vector2f(50, HEIGHT-200  - startAgain.CharacterSize / 2);
        window.Draw(startAgain);
        gameStarted = false;
    }
    private void startGame()
    {
        boardManager = new BoardManager();
        board = new Board(10, 10);
        var startField = board.GetField(5, 5);
        player = new Player(startField);
        snake = new Snake(board, startField);
        gift = new Gift(board);
        gameStarted = true;
    }
}