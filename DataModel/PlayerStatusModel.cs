using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.DataModel.CardModel;
using Assets.Scripts.DataModel.CardModel.EffectModel;

namespace Assets.Scripts.DataModel
{
    // Class to store data relevant to a player during his turn
    public class PlayerStatusModel
    {

        public StandardEffectModel CurrentRessources = new StandardEffectModel();
    }
}
