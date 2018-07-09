using Bolt;

namespace Cognivive.Bolt.Events.Items
{
    [UnitTitle("On Enter Drop Zone")] // Sets the actual named title of the unit, this is used in the Fuzzy Finder.
    public class EnteredSnapDropZoneEvent : VRTK_InteractableObjectEvent
    {
        protected override void SetupListener()
        {
            Component.InteractableObjectEnteredSnapDropZone += DoTrigger;
        }

        protected override void RemoveListener()
        {
            Component.InteractableObjectEnteredSnapDropZone -= DoTrigger;
        }

        public override string InteractingObjectLabel
        {
            get { return "Drop Zone"; }
        }
    }
}