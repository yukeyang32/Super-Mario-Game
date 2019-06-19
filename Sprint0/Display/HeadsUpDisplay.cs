using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    internal class HeadsUpDisplay
    {
        private Game1 game;
        private SpriteFont font;
        private Vector2 textPosition;
        private Vector2 gamePausedPosition;
        private Vector2 gameOverOrPkPosition;
        private Vector2 gameWinningPosition;
        //private Stopwatch timer = new Stopwatch();

        //Check here
        //private ISprite coinSprite;
        //private ISprite marioSprite;

        private int score;
        private int coin;
        private string worldLevel = "1-1";


        public double time;

        private string displayPkMarioWinString, displayPkLuigiWinString,displayLabelString, displayNumericalString, displayStringPausedGame, displayStringWinningGame, displayGameOver, displayStringWinningGameCommand;

        //Check here
        //public IMarioState state;
        //public Mario mario;

        public HeadsUpDisplay(Game1 game, ContentManager content)
        {
            this.game = game;
            font = content.Load<SpriteFont>("MarioFont");
            textPosition = new Vector2(ConstantNumber.TEXT_POSITION_X, ConstantNumber.TEXT_POSITION_Y);
            gamePausedPosition = new Vector2(ConstantNumber.GAME_PAUSED_POSITION_X,ConstantNumber.GAME_PAUSED_POSITION_Y);
            gameOverOrPkPosition = new Vector2(ConstantNumber.GAME_OVER_POSITION_X, ConstantNumber.GAME_OVER_POSITION_Y);
            gameWinningPosition = new Vector2(ConstantNumber.GAME_WINNING_POSITION_X, ConstantNumber.GAME_WINNING_POSITION_Y);
            time = ConstantNumber.TIME_INIT;

            displayLabelString = "               SCORE        COIN        LIVES       LEVEL        TIME";
            displayNumericalString = "               " + toString(score, ConstantNumber.SCORE_DIGIT) + "          x" + toString(coin, ConstantNumber.COIN_DIGIT) + "            x" + toString(game.lives, 2)
                + "           " + worldLevel + "             " + toString((int)time, ConstantNumber.TIME_DIGIT);
            displayStringPausedGame = "Game Paused(Press O to Continue)";
            displayStringWinningGame = "You Win!!!";
            displayGameOver = "Game Over!!!";
            displayPkMarioWinString = "Mario Win!!!";
            displayPkLuigiWinString = "Luigi Win!!!";
            displayStringWinningGameCommand = "Press R to Restart Or Press Q to Quit";
        }

        private static string toString(int number, int digits)
        {
            string s = "" + number;
            int length = s.Length;
            if (s.Length < digits)
            {
                for (int i = 0; i < digits - length; i++)
                {
                    s = "0" + s;
                }
            }
            return s;
        }

        public void Reset()
        {
            score = 0;
            coin = 0;
            worldLevel = "1-1";
            time = ConstantNumber.TIME_INIT;
        }


        public void GetScore(int addScore)
        {
            score += addScore;
        }

        public void GetCoin()
        {
            coin += 1;
            GetScore(ConstantNumber.SCORE_200);
        }

        public void Update(GameTime gameTime)
        {
                if (time >= 0)
                {
                if (game.level == 1) worldLevel = "1-1";
                else worldLevel = "1-2";

                time -= gameTime.ElapsedGameTime.TotalSeconds;
                    displayNumericalString = "               " + toString(score, ConstantNumber.SCORE_DIGIT) + "          x" + toString(coin, ConstantNumber.COIN_DIGIT) + "            x" + toString(game.lives, 2)
                        + "           " + worldLevel + "             " + toString((int)time, ConstantNumber.TIME_DIGIT);

                if (game.Mario.ReachDestination)
                {
                        score += (int)time;
                        time = 0;
                }
            }
            else
                {
                    game.ReLoadLevel();
                }
            }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (game.isPkMode)
            {
                if (game.Luigi.health < 0)
                {
                    spriteBatch.DrawString(font, displayPkMarioWinString, gameOverOrPkPosition, Color.White);
                }
                if (game.Mario.health < 0)
                {
                    spriteBatch.DrawString(font, displayPkLuigiWinString, gameOverOrPkPosition, Color.White);
                }
            }
            else
            {
                if (time >= 0)
                {
                    spriteBatch.DrawString(font, displayLabelString, textPosition, Color.White);
                    spriteBatch.DrawString(font, displayNumericalString, textPosition + (new Vector2(ConstantNumber.DISPLAY_X_ADJUSTMENT, ConstantNumber.DISPLAY_Y_ADJUSTMENT)), Color.White);
                }
                if (game.GamePause)
                {
                    spriteBatch.DrawString(font, displayStringPausedGame, gamePausedPosition, Color.White);
                }
                if (game.Mario.Destroyed)
                {
                    spriteBatch.DrawString(font, displayStringWinningGame, gameWinningPosition, Color.White);
                    spriteBatch.DrawString(font, displayStringWinningGameCommand, gameWinningPosition + (new Vector2(ConstantNumber.DISPLAY_X_ADJUSTMENT, ConstantNumber.DISPLAY_Y_ADJUSTMENT)), Color.White);
                }
                if (game.lives < 0)
                {
                    spriteBatch.DrawString(font, displayGameOver, gameOverOrPkPosition, Color.White);
                }
            }

        }
}
}
