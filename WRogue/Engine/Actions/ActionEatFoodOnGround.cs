using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

using djack.RogueSurvivor.Data;

namespace djack.RogueSurvivor.Engine.Actions
{
    class ActionEatFoodOnGround : ActorAction
    {
        #region Fields
        Item m_Item;
        #endregion

        #region Init
        public ActionEatFoodOnGround(Actor actor, RogueGame game, Item it)
            : base(actor, game)
        {
            if (it == null)
                throw new ArgumentNullException("item");

            m_Item = it;
        }
        #endregion

        #region ActorAction
        public override bool IsLegal()
        {
            return m_Game.Rules.CanActorEatFoodOnGround(m_Actor, m_Item, out m_FailReason); 
        }

        public override void Perform()
        {
            m_Game.DoEatFoodFromGround(m_Actor, m_Item);
        }
        #endregion
    }
}
