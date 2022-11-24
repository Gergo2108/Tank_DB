using K9P4EG_HFT_2022231.Models;
using K9P4EG_HFT_2022231.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K9P4EG_HFT_2022231.Logic
{
    public class BattleLogic : IBattleLogic
    {
        Repo<Battle> repo;

        public BattleLogic(Repo<Battle> repo)
        {
            this.repo = repo;
        }
        public void Create(Battle item)
        {
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            repo.Delete(id);
        }

        public Battle Read(int id)
        {
            var battle = this.repo.Read(id);
            if (battle == null)
            {
                throw new ArgumentException("Tank not exissts");
            }
            return battle;
        }

        public IEnumerable<Battle> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Battle item)
        {
            this.repo.Update(item);
        }

        //NON-CRUD

        
    }
}
