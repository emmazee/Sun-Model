//------------------------------------------------------------------------------
// USMM\Aggregation.cs
//
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunModelWindows
{
    /// <summary>
    /// A measure can specify zero to many Aggregation elements.An implied default is a fully additive
    ///measure.The Aggregation element is used to explicitly specify additivity.Additivity should be
    ///specified when a measure is non-additive or non-aggregable.
    ///There are a number of ways aggregations can be represented in a conformant USMM.Users may
    ///choose free form text to define the AggType, allowing multiple aggregation types to be represented
    ///in a single instance, and associated with a single AssocLevelID; or users may choose to represent
    ///each aggregation type for an AssocLevelID as a separation Aggregation. (Black, 2011)
    /// </summary>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public class Aggregation
    {

        private string aggTypeField;
        private string assocLevelUIDField;


        /// <summary>
        /// Gets or sets the type of the aggregate. This attribute is not restricted to well-
        ///known aggregation types like sum and average.The lack of restriction allows user-defined
        ///aggregations to be specified.An AggType of None could be used to express a non-aggregable
        ///measure on a dimension. (Black, 2011)
        /// </summary>
        /// <value>
        /// The type of the aggregate.
        /// </value>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string AggType
        {
            get
            {
                return this.aggTypeField;
            }
            set
            {
                this.aggTypeField = value;
            }
        }


        /// <summary>
        /// Gets or sets the associated dimensional attribute (Level) where the specified aggregation type is valid. (Black, 2011)
        /// </summary>
        /// <value>
        /// The assoc level uid.
        /// </value>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string AssocLevelUID
        {
            get
            {
                return this.assocLevelUIDField;
            }
            set
            {
                this.assocLevelUIDField = value;
            }
        }
    }
}
