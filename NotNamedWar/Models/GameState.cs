using System;
using System.Collections.Generic;
using System.Text;

namespace NotNamedWar.Models
{
    public enum RunningState
    {
        start,
        suspend,
        running
    }

    class GameState
    {
        public RunningState RunningState { get; set; } = RunningState.start;
    }
}
