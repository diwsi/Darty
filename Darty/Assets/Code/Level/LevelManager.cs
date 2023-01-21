using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Code.Level
{
    public class LevelManager : MonoBehaviour
    {
        public Level[] Levels;
        public UnityEvent<Level> LevelChange;
        public UnityEvent<string> LevelChangeStr;
        public int Goal;
        void Start()
        {
            SetNextLevel();
        }

        public Level CurrentLevel
        {
            get
            {
                return Levels.FirstOrDefault(d => !d.Completed);
            }
        }

       public void SetNextLevel()
        {
            var level = CurrentLevel;
            if (level != null)
            {
                SetLevel(level);
            }
        }

        void SetLevel(Level level)
        {
            Goal = level.Spawns.Length;
            LevelChange.Invoke(level);
            LevelChangeStr.Invoke($"Level {level.LevelNo}");
        }

        public void LevelCompleted()
        {
            CurrentLevel.Completed = true;
        }

        public void SetScore()
        {
            Goal--;
            if (Goal <= 0 && CurrentLevel != null)
            {
                CurrentLevel.Completed = true;
                SetNextLevel();
            }
        }

    }
}
