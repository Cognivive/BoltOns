using Bolt;

namespace Cognivive.Bolt.Events.Items
{
    [UnitTitle("On Exited Drop Zone")] // Sets the actual named title of the unit, this is used in the Fuzzy Finder.
    public class ExitedSnapDropZoneEvent : VRTK_InteractableObjectEvent
    {
        protected override void SetupListener()
        {
            Component.InteractableObjectExitedSnapDropZone += DoTrigger;
        }

        protected override void RemoveListener()
        {
            Component.InteractableObjectExitedSnapDropZone -= DoTrigger;
        }

        public override string InteractingObjectLabel
        {
            get { return "Drop Zone"; }
        }
    }
}