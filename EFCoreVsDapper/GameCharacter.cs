using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreVsDapper
{
    public class GameCharacter
    {
        public int GameCharacterId { get; set; }
        public string CharacterName { get; set; }
        public int PowerLevel { get; set; }
        public string Wepon { get; set; }

    }
}
