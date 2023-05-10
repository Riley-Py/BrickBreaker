using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickBreaker
{
    public class HighScore
    {
        public string score, playerName;
        public HighScore(string _score, string _playerName)
        {
            score = _score;
            playerName = _playerName;
        }
    }
}
