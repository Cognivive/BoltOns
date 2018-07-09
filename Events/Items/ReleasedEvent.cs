using Bolt;

namespace Cognivive.Bolt.Events.Items
{
    [UnitTitle("On Released")] // Sets the actual named title of the unit, this is used in the Fuzzy Finder.
    public class ReleasedEvent : VRTK_InteractableObjectEvent
    {
        public override string InteractingObjectLabel
        {
            get { return "Grabber"; }
        }

        protected override void SetupListener()
        {
            Component.InteractableObjectUngrabbed += DoTrigger;
        }

        protected override void RemoveListener()
        {
            Component.InteractableObjectUngrabbed -= DoTrigger;
        }
    }
}