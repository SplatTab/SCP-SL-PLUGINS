using Exiled.Events.EventArgs;
using Exiled.API.Enums;
using Exiled.Events.Extensions;
using System.Collections.Generic;


namespace Medkit_Antidote
{
    public class EventHandlers
    {
        private readonly Plugin plugin;
        public EventHandlers(Plugin plugin) => this.plugin = plugin;

        public void OnMedicalItem(UsedItemEventArgs ev)
        {
            List<EffectType> effectList = new List<EffectType> { };
            switch (ev.Item.Type)
            {
                case ItemType.Medkit:
                    effectList = plugin.Config.MedkitEffectsToRemove;
                    break;

                case ItemType.Adrenaline:
                    effectList = plugin.Config.AdrenalineEffectsToRemove;
                    break;

                case ItemType.Painkillers:
                    effectList = plugin.Config.PillsEffectsToRemove;
                    break;
                case ItemType.SCP500:
                    effectList = plugin.Config.SCP500EffectsToRemove;
                    break;
            }

            //Loop through the list from the config file and remove chosen effects from a player after they've used a medical item
            if (effectList.Count > 0)
            {
                foreach (EffectType effectName in effectList)
                {
                    ev.Player.DisableEffect(effectName);
                }
            }
        }
    }
}
