using RLNET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike.System
{
    public class MessageLog
    {
        private readonly static int _maxLines = 9;
        private readonly Queue<string> _lines;

        public MessageLog()
        {
            _lines = new Queue<string>();
        }

        public void AddLine(string msg)
        {
            _lines.Enqueue(msg);

            if (_lines.Count > _maxLines) _lines.Dequeue();
        }

        public void DrawLog(RLConsole console)
        {
            console.Clear();
            string[] lines = _lines.ToArray();
            for (int i = 0; i < lines.Length; i++) console.Print(1, i + 1, lines[i], RLColor.White);
        }
    }
}
