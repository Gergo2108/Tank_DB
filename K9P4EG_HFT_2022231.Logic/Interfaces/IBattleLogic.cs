using K9P4EG_HFT_2022231.Models;
using System.Collections.Generic;

namespace K9P4EG_HFT_2022231.Logic
{
    public interface IBattleLogic
    {
        void Create(Battle item);
        void Delete(int id);
        Battle Read(int id);
        IEnumerable<Battle> ReadAll();
        void Update(Battle item);
    }
}