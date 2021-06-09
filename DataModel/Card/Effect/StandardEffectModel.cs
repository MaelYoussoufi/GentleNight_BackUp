using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.DataModel.CardModel.EffectModel;
using Assets.Scripts.DataModel.DeckM;

namespace Assets.Scripts.DataModel.CardModel
{
    [Serializable]
    public class StandardEffectModel : EffectModelBase
    {
        [OptionalField]
        public short Wander; // Boots
        [OptionalField]
        public short Kindling; // Basic turn-bound resource
        [OptionalField]
        public short Wealth; // Basic storable ressource
        [OptionalField]
        public short Might; // Combat attack power
        [OptionalField]
        public short Bulwark; // Combat defense power
        [OptionalField]
        public short Craft; // Activation of POI/card improvements
        [OptionalField]
        public short Arcana; // Spell & magic card activation
        [OptionalField]
        public short HealthGain; // Modify the health of the player

        public override object Clone()
        {
            return new StandardEffectModel()
            {
                Wander = Wander,
                Kindling = Kindling,
                Wealth = Wealth,
                Might = Might,
                Bulwark = Bulwark,
                Craft = Craft,
                HealthGain = HealthGain,
                Arcana = Arcana
            };
        }

        public override void Apply(PlayerStatusModel player)
        {
            player.CurrentRessources += this;
        }

        public static StandardEffectModel operator +(StandardEffectModel a, StandardEffectModel b)
            => new StandardEffectModel()
            {
                Wander = (short)(a.Wander + b.Wander),
                Kindling = (short)(a.Kindling + b.Kindling),
                Wealth = (short)(a.Wealth + b.Wealth),
                Might = (short)(a.Might + b.Might),
                Bulwark = (short)(a.Bulwark + b.Bulwark),
                Craft = (short)(a.Craft + b.Craft),
                HealthGain = (short)(a.HealthGain + b.HealthGain),
                Arcana = (short)(a.Arcana + b.Arcana)
            };
    }
}
