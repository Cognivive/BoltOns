using Bolt;
using Ludiq;
using VRTK;
using UnityEngine;

namespace Cognivive.Bolt.Units.VRTK
{
    [TypeIcon(typeof(VRTK_SDKManager))] // Choose the type icon. @32x - headers; @16x -ports and fuzzy finder categories. Located in Editor Default Resources.
    [UnitTitle("Headset Camera")] // Sets the actual named title of the unit, this is used in the Fuzzy Finder.
    [UnitCategory("VRTK")] // Sets unit category in Fuzzy Finder. Subfolders are matched and created.
    public class GetHeadsetCamera: Unit
    {
        [DoNotSerialize] public ValueOutput Camera;
        
        protected override void Definition()
        {
            Camera = ValueOutput<Transform>("Transform", GetValue);
        }

        private Transform GetValue(Recursion arg1)
        {
            return VRTK_DeviceFinder.HeadsetCamera();
        }
    }
}