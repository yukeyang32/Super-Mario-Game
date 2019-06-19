using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    internal static class ConstantNumber
    {
        public const int ITEM_HEIGHT = 21;
        public const int ITEM_WIDTH = 19;
        public const int FIREBALL_HEIGHT_COLLISION = 16;
        public const int FIREBALL_WIDTH_COLLISION = 16;
        public const int GOOMBA_HEIGHT = 21;
        public const int GOOMBA_WIDTH = 21;

        public const int KOOPA_HEIGHT = 23;
        public const int KOOPA_WIDTH = 21;
        public const int STOMPED_KOOPA_HEIGHT = 20;
        public const int STOMPED_KOOPA_WIDTH = 19;

        public const int STOMPED_GOOMBA_HEIGHT = 12;
        public const int STOMPED_GOOMBA_WIDTH = 19;
        public const int BLOCK_HEIGHT = 16;
        public const int BLOCK_WIDTH = 16;

        public const int PIPE_HEIGHT = 32;
        public const int PIPE_WIDTH = 32;

        public const int BIG_HEIGHT = 32;
        public const int CROUCHING_MARIO_HEIGHT = 23;
        public const int BIG_WIDTH = 16;
        public const int BIG_JUMPING_WALKING_WIDTH = 17;
        public const int SMALL_HEIGHT = 16;
        public const int CROUCHING_HEIGHT = 24;
        public const int SMALL_WIDTH = 13;
        public const int SMALL_JUMPING_WALKING_WIDTH = 16;

        public const int SCREEN_WIDTH = 800;
        public const int SCREEN_HEIGHT = 480;
        public const int SCREEN_HEIGHT_ADJUST = 800;

        public const int MARIO_STAR_POWER_TIMER = 600;
        public const int MARIO_TRANSITION_STATE_TIMER = 100;

        public const int LEVEL_END = 3236;

        public const int FLAG_POLE_WIDTH = 3;
        public const int FLAG_POLE_HEIGHT = 130;
        public const int LIVES_INIT = 3;
        public const int FIREBALL_HEIGHT_DRAW = 18;
        public const int FIREBALL_WIDTH_DRAW = 18;
        public const int EXPLODED_FIREBALL_HEIGHT = 9;
        public const int EXPLODED_FIREBALL_WIDTH = 9;
        public const int FIREBALL_COLUMN = 1;

        public const int MARIO_JUMPING_POWER = 25;
        public const int MARIO_RELOAD_TIME = 30;
        public const int MARIO_STANDING_TIME = 30;
        public const int FIREBALL_LEFT = 3;
        public const int ENEMY_HEIGHT = 25;
        public const int ENEMY_WIDTH = 27;
        public const int GOOMBA_COLUMNS = 2;
        public const int KOOPA_COLUMNS = 2;
        public const int KOOPA_DEAD_COLUMNS = 1;
        public const int ITEM_SPRITE_HEIGHT = 20;
        public const int ITEM_SPRITE_WIDTH = 30;
        public const int FLAG_HEIGHT = 127;
        public const int FLAG_WIDTH = 31;
        public const int STAR_X = 0;
        public const int STAR_Y = 90;
        public const int STAR_COL = 4;
        public const int FLOWER_X = 0;
        public const int FLOWER_Y = 64;
        public const int FLOWER_COL = 4;
        public const int MUSHROOM_X = 180;
        public const int MUSHROOM_Y = 32;
        public const int MUSHROOM_COL = 1;

        public const int POISON_X = 210;
        public const int POISON_Y = 32;
        public const int POISON_COL = 1;

        public const int COIN_X = 120;
        public const int COIN_Y = 90;
        public const int COIN_COL = 1;
        public const int FLAG_COL = 1;
        public const int ANIMATED_FLAG_COL = 2;

        public const int ANIMATED_COLUMNS = 3;
        public const int STATIC_COLUMNS = 1;
        public const int BLOCK_ROWS = 1;

        public const int VELOCITY_X_LIMIT = 4;
        public const int VELOCITY_Y_LIMIT = 3;

        public const int MARIO_TRANSITION_OFFSET = 17;
        public const int MARIO_DAMAGE_TRANSITION_OFFSET = 18;
        public const int BIG_MARIO_UP_AND_DOWN_OFFSET = 10;

        public const int BLOCK_POSITION_Y_ADJUST = 2;
        public const int FlAG_POSITION_X_ADJUST = 16;
        public const int CAMERA_START_X = 0;
        public const int CAMERA_MARIO_POSITION_X_ADJUST =16;
        public const int CAMERA_MARIO_POSITION_X_LIMIT = 3121;
        public const int SCORE_100 = 100;
        public const int SCORE_200 = 200;
        public const int SCORE_1000 = 1000;
        public const int BLOCK_BOUNCE_X = 0;
        public const int BLOCK_BOUNCE_Y = 1;
        public const int Support_Force_X = 0;
        public const float Support_Force_Y = 0.15f;
        public const int GOOMBA_DIE_TIME = 3;
        public const int SHELL_DURATION = 400;
        public const int KOOPA_POSITION_X_ADJUST = 5;
        public const int KOOPA_POSITION_Y_ADJUST = 2;
        public const int GOOMBA_POSITION_Y_ADJUST = 5;
        public const float FIREBALL_VELOCITY = 3f;
        public const float FIREBALL_BOUNCE_VELOCITY = -10f;
        public const int TEXT_POSITION_X = 50;
        public const int TEXT_POSITION_Y = 20;
        public const int GAME_PAUSED_POSITION_X = 260;
        public const int GAME_PAUSED_POSITION_Y = 240;
        public const int GAME_OVER_POSITION_X = 320;
        public const int GAME_OVER_POSITION_Y = 240;
        public const int GAME_WINNING_POSITION_X = 250;
        public const int GAME_WINNING_POSITION_Y = 240;
        public const int SCORE_DIGIT = 6;
        public const int COIN_DIGIT = 2;
        public const int TIME_DIGIT = 3;
        public const int DISPLAY_X_ADJUSTMENT = 0;
        public const int DISPLAY_Y_ADJUSTMENT = 30;
        public const int TIME_INIT = 300;
        public const int FLAG_X_ADJUSTMENT = 17;
        public const int LEVEL_LOADER_SPACING = 16;
        public const int LEVEL_LOADER_STARTING_Y = 1;

        public const int LIVES_STARTING = 3;
        public const int FIREBALL_TIMER = 100;
        public const int STOMPED_TIMER = 3;
        public const float ITEM_VELOCITY = 0.75f;
        public const int FLAG_FALLING_TIME = 40;
        public const int ENEMY_ITEM_SPEED_X = 2;
        public const int ENEMY_ITEM_SPEED_Y = 2;
        public const int CELL_SIZE = 16;
        public const int CELL_STARTING_ROW = 1;
        public const int BLOCK_EXPLODING_TIME = 35;
        public const int MARIO_MOVING_VELOCITY_LIMIT = 2;
        public const int MARIO_MOVING_FORCE_X = 2;
        public const int MARIO_MOVING_FORCE_Y = 0;
        public const int MARIO_RISING_FORCE_X = 0;
        public const int MARIO_RISING_FORCE_Y = 3;
        public const int SMALL_MARIO_RISING_FORCE_X = 0;
        public const int SMALL_MARIO_RISING_FORCE_Y = 2;
        public const int MARIO_RUNNING_FORCE_X = 4;
        public const int MARIO_RUNNING_FORCE_Y = 0;
        public const int DEAD_MARIO_FORCE_X = 0;
        public const int DEAD_MARIO_FORCE_Y = 1;
        public const int MARIO_JUMPING_FORCE_X =0;
        public const float MARIO_JUMPING_FORCE_Y = 4.5f;
        public const int MARIO_DESTINATION_SPEED_LIMIT = 2;
        public const int BIG_MARIO_POSITION_X_ADJUST = 3;
        public const int STAR_MARIO_POSITION_X_ADJUST = 2;
        public const int BIG_MARIO_FALLING_POSITION_X_ADJUST = 2;
        public const int BIG_MARIO_CREEPING_POSITION_Y_ADJUST = 5;
        public const int BIG_MARIO_CREEPING_HEIGHT_ADJUST = 5;
        public const float MARIO_BOUNCE_FORCE = 0.8f;
        public const int SMALL_MARIO_POSITION_X_ADJUST = 3;
        public const int SMALL_MARIO_WIDTH_ADJUST = 3;
        public const int SMALL_MARIO_HEIGHT_ADJUST = 1;
        public const int SMALL_MARIO_CREEPING_HEIGHT_ADJUST = 2;
        public const int FIREBALL_OFFSET = 20;

        public const int MARIO_HEALTH = 150;

        public const int MENU_WIDTH = 800;
        public const int MENU_HEIGHT = 600;

        public const int MENU_LEVEL_1_X = 350;
        public const int MENU_LEVEL_1_Y = 200;
        public const int MENU_LEVEL_2_X = 350;
        public const int MENU_LEVEL_2_Y = 250;
        public const int MENU_LEVEL_3_X = 350;
        public const int MENU_LEVEL_3_Y = 300;
        public const int MENU_LEVEL_4_X = 350;
        public const int MENU_LEVEL_4_Y = 350;

        public const int LEVEL_1 = 1;
        public const int LEVEL_2 = 2;
        public const int LEVEL_3 = 3;
        public const int LEVEL_4 = 4;

        public const int DEFAULT_LEVEL = 1;

        public const int MARIO_HEALTH_BAR_X = 0;
        public const int MARIO_HEALTH_BAR_Y = 0;
        public const int LUIGI_HEALTH_BAR_X = 650;
        public const int LUIGI_HEALTH_BAR_Y = 0;


    }
}
