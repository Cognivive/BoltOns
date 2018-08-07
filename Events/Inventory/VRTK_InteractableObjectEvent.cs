using Bolt;
using Ludiq;
using VRTK;
using UnityEngine;

namespace Core.Cognivive.Bolt.Events.Inventory
{
    [TypeIcon(typeof(VRTK_SnapDropZone))] // Choose the type icon. @32x - headers; @16x -ports and fuzzy finder categories. Located in Editor Default Resources.
    [UnitCategory("Events/Inventory")] // Sets unit category in Fuzzy Finder. Subfolders are matched and created.
    public abstract class VRTK_SnapDropZoneEvent : CustomDelegateEvent<VRTK_SnapDropZone>
    {
        [DoNotSerialize] public ValueOutput InteractingObject;

        [DoNotSerialize] public ValueOutput Object;

        public abstract string InteractingObjectLabel { get; }

        protected override void Definition()
        {
            base.Definition();
            ArgumentCount(3);

            Object = ValueOutput("Snap Drop Zone", delegate { return (VRTK_SnapDropZone)arguments[1]; });
            InteractingObject = ValueOutput(InteractingObjectLabel, delegate { return (GameObject)arguments[2]; });
        }

        protected void DoTrigger(object sender, SnapDropZoneEventArgs e)
        {
            Trigger(this, sender, e.snappedObject);
        }
        
    }
}