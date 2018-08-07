using System.Collections;
using Bolt;
using Extensions;
using Ludiq;

namespace Core.Cognivive.Bolt.Units
{
    /// <summary>Gets the item at the specified index of a list.</summary>
    [UnitCategory("Collections/Lists")]
    [UnitSurtitle("List")]
    [UnitShortTitle("Get Random Item")]
    [TypeIcon(typeof(IList))]
    public sealed class GetRandomListItem : Unit
    {
        /// <summary>The list.</summary>
        [DoNotSerialize]
        [PortLabelHidden]
        public ValueInput list { get; private set; }

        /// <summary>The item.</summary>
        [DoNotSerialize]
        [PortLabelHidden]
        public ValueOutput item { get; private set; }

        protected override void Definition()
        {
            list = ValueInput<IList>("list");
            item = ValueOutput("item", Get);
            Relation(list, item);
        }

        public object Get(Recursion recursion)
        {
            return list.GetValue<IList>(recursion).RandomElement();
        }
    }
}