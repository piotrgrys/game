using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simple_game
{
    internal class TextManager
    {
        private static string ASSETS_PATH = "C://game/simple_game/Fonts/";
        static Font font;
        static Text gameIsOver;
        static Text increaseSpeed;
        static Text decreaseSpeed;
        static Text increaseChain;
        static Text speed;
        static Text length;
        static Text speedValue;
        static Text lengthVaue;
        static Text score;
        static Text scoreValue;
        static Text startAgain;
        public static Text GameIsOverText { get { return gameIsOver; } }
        public static Text IncreaseSpeed { get { return increaseSpeed; } }
        public static Text DecreaseSpeed { get { return decreaseSpeed; } }
        public static Text IncreaseChain { get { return increaseChain; } }
        public static Text Speed { get { return speed; } }
        public static Text Length { get { return length; } }
        public static Text SpeedValue { get { return speedValue; } }
        public static Text LengthVaue { get { return lengthVaue; } }
        public static Text Score { get { return score; } }
        public static Text ScoreValue { get { return scoreValue; } }
        public static Text StartAgain { get { return startAgain; } }
        public static void LoadTexts()
        {
            font = new Font(ASSETS_PATH+ "Light And Airy.ttf");
            gameIsOver = new Text("Game is over !!!", font);
            gameIsOver.CharacterSize = 120;
            gameIsOver.Color = Color.Black;
            increaseSpeed = new Text("Speed increased +1", font);
            increaseSpeed.CharacterSize = 40;
            increaseSpeed.Color = Color.Black;
            decreaseSpeed = new Text("Speed decreased -1", font);
            decreaseSpeed.CharacterSize = 40;
            decreaseSpeed.Color = Color.Black;
            increaseChain = new Text("Chain increased", font);
            increaseChain.CharacterSize = 40;
            increaseChain.Color = Color.Black;
            speed = new Text("Speed:", font);
            speed.CharacterSize = 40;
            speed.Color = Color.Black;
            speedValue = new Text("0", font);
            speedValue.CharacterSize = 40;
            speedValue.Color = Color.Black;
            length = new Text("Length:", font);
            length.CharacterSize = 40;
            length.Color = Color.Black;
            lengthVaue = new Text("0", font);
            lengthVaue.CharacterSize = 40;
            lengthVaue.Color = Color.Black;
            score = new Text("Score:", font);
            score.CharacterSize = 40;
            score.Color = Color.Black;
            scoreValue = new Text("0", font);
            scoreValue.CharacterSize = 40;
            scoreValue.Color = Color.Black;
            startAgain = new Text("Press S to play again", font);
            startAgain.CharacterSize = 100;
            startAgain.Color = Color.Black;
        }
    }
}
