using System.Collections.Generic;
using Bolt;
using Ludiq;
using UnityEngine;

namespace Core.Cognivive.Bolt.Units
{
    [UnitTitle("Get Objects In Radius")] // Sets the actual named title of the unit, this is used in the Fuzzy Finder.
    [UnitCategory("World")] // Sets unit category in Fuzzy Finder. Subfolders are matched and created.
    public class GetObjectsInRadius<T> : Unit where T : Component
    {
        [DoNotSerialize] public ValueOutput ObjectsInRadius;

        [DoNotSerialize] public ValueInput Origin;

        [DoNotSerialize] public ValueInput Radius;

        protected override void Definition()
        {
            Origin = ValueInput<GameObject>("Origin");
            Radius = ValueInput<float>("Radius");
            ObjectsInRadius = ValueOutput("ObjectsInRadius", GetValue);
        }

        private List<T> GetValue(Recursion recursion)
        {
            float squaredRadius = Radius.GetValue<float>() * Radius.GetValue<float>();
            Vector3 originPoint = Origin.GetValue<GameObject>().transform.position;
            T[] objects = Object.FindObjectsOfType<T>();

            List<T> radius = new List<T>(objects.Length);
            for (int i = 0; i < objects.Length; i++)
            {
                if ((objects[i].transform.position - originPoint).sqrMagnitude < squaredRadius)
                {
                    radius.Add(objects[i]);
                }
            }
            return radius;
        }
    }
}