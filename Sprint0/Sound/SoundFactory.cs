using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;

namespace Sprint0
{
    internal class SoundFactory
    {
        private Song themeBackgroundMusic;
        private Song undergroundBackgroundMusic;
        private Song starBackgroundMusic;
        private Song levelCompleteBackgroundMusic;
        private Song deadBackgroundMusic;
        private Song gameOverBackgroundMusic;
        private SoundEffect breakBlockSoundEffect;
        private SoundEffect bumpBlockSoundEffect;
        private SoundEffect coinSoundEffect;
        private SoundEffect fireballSoundEffect;
        private SoundEffect flagpoleSoundEffect;
        private SoundEffect smallMarioJumpSoundEffect;
        private SoundEffect bigMarioJumpSoundEffect;
        private SoundEffect stompEnemySoundEffect;
        private SoundEffect pipeSoundEffect;
        private SoundEffect powerUpSoundEffect;
        private SoundEffect takeDamageSoundEffect;
        private SoundEffect vineSoundEffect;

        static readonly SoundFactory instance = new SoundFactory();

        public static SoundFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private SoundFactory()
        {
        }

        public void LoadAllSound(ContentManager content)
        {
            themeBackgroundMusic = content.Load<Song>("01-main-theme-overworld");
            undergroundBackgroundMusic = content.Load<Song>("02-underworld");
            starBackgroundMusic = content.Load<Song>("05-starman");
            levelCompleteBackgroundMusic = content.Load<Song>("06-level-complete");
            deadBackgroundMusic = content.Load<Song>("08-you-re-dead");
            gameOverBackgroundMusic = content.Load<Song>("09-game-over");
            breakBlockSoundEffect = content.Load<SoundEffect>("smb_breakblock");
            bumpBlockSoundEffect = content.Load<SoundEffect>("smb_bump");
            coinSoundEffect = content.Load<SoundEffect>("smb_coin");
            fireballSoundEffect = content.Load<SoundEffect>("smb_fireball");
            flagpoleSoundEffect = content.Load<SoundEffect>("smb_flagpole");
            smallMarioJumpSoundEffect = content.Load<SoundEffect>("smb_jumpsmall");
            bigMarioJumpSoundEffect = content.Load<SoundEffect>("smb_jump-super");
            stompEnemySoundEffect = content.Load<SoundEffect>("smb_kick");
            pipeSoundEffect = content.Load<SoundEffect>("smb_pipe");
            powerUpSoundEffect = content.Load<SoundEffect>("smb_powerup");
            takeDamageSoundEffect = content.Load<SoundEffect>("smb_powerup_appears");
            vineSoundEffect = content.Load<SoundEffect>("smb_vine");
        }

        public void playThemeSong()
        {
            MediaPlayer.Play(themeBackgroundMusic);
        }

        public void playUndergroundSong()
        {
            MediaPlayer.Play(undergroundBackgroundMusic);
        }

        public void playStarMaioSong()
        {
            MediaPlayer.Play(starBackgroundMusic);
        }

        public void playLevelCompleteSong()
        {
            MediaPlayer.Play(levelCompleteBackgroundMusic);
        }

        public void playDeadSong()
        {
            MediaPlayer.Play(deadBackgroundMusic);
        }

        public void playGameOverSong()
        {
            MediaPlayer.Play(gameOverBackgroundMusic);
        }

        public void playBreakBlockSoundEffect()
        {
            breakBlockSoundEffect.Play();
        }

        public void playBumpBlockSoundEffect()
        {
            bumpBlockSoundEffect.Play();
        }

        public void playCoinSoundEffect()
        {
            coinSoundEffect.Play();
        }

        public void playFireballSoundEffect()
        {
            fireballSoundEffect.Play();
        }

        public void playFlagpoleSoundEffect()
        {
            if (!Game1.Instance.flagpoleEffectPlayed)
            {
                flagpoleSoundEffect.Play();
                playLevelCompleteSong();
                Game1.Instance.flagpoleEffectPlayed = true;
            }
        }

        public void playSmallMarioJumpSoundEffect()
        {
            smallMarioJumpSoundEffect.Play();
        }

        public void playBigMarioJumpSoundEffect()
        {
            bigMarioJumpSoundEffect.Play();
        }

        public void playStompEnemySoundEffect()
        {
            stompEnemySoundEffect.Play();
        }

        public void playPipeSoundEffect()
        {
            pipeSoundEffect.Play();
        }

        public void playPowerUpSoundEffect()
        {
            powerUpSoundEffect.Play();
        }

        public void playTakeDamageSoundEffect()
        {
            takeDamageSoundEffect.Play();
        }

        public void playVineSoundEffect()
        {
            vineSoundEffect.Play();
        }
    }
}
