//------------------------------------------------------------------------------
// USMM\Measure.cs
//
//------------------------------------------------------------------------------

using SunModelWindows.USMM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.ComponentModel;

namespace SunModelWindows
{
    /// <summary>
    /// A Measure element belongs to a Measures(Fact) element.(Black, 2011)
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public class Measure 
    {

        private List<Aggregation> aggregationField;
        private string nameField;
        private string notesField;
        
        private MeasureType typeField;


        /// <summary>
        /// Gets or sets the name. A Name attribute is used to provide the name of the measure. (Black, 2011)
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [Category("General"), Description("The name of the measure")]
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }


        /// <summary>
        /// Gets or sets the type. The Type attribute is used to specify the type of measure. The type of measure is restricted to Descriptive or Analytical. These are the same categories used to describe the Level element(this loosely ties to the symmetric treatment of measures and dimensions). 
        /// The default value of the Type attribute is Analytical.(Black, 2011)
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        [Category("General"), Description(@"The Type attribute is used to specify the type of measure. The type of measure is restricted to Descriptive or Analytical. These are the same categories used to describe the Level element(this loosely ties to the symmetric treatment of measures and dimensions).  

The default value of the Type attribute is Analytical.")]
        [System.Xml.Serialization.XmlAttributeAttribute(AttributeName = "Type")]
        [DefaultValueAttribute(MeasureType.analytical)]
        public MeasureType Type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }


        /// <summary>
        /// Gets or sets the aggregation.   
        /// A Measure can optionally specify the types of aggregation supported by the measure with a sequence of Aggregation elements.  (Black, 2011)
        /// </summary>
        /// <value>
        /// The aggregation.
        /// </value>
        [System.Xml.Serialization.XmlElementAttribute("Aggregation")]
        [Category("General"), Description(@" A measure can specify zero to many Aggregation elements.An implied default is a fully additive measure.The Aggregation element is used to explicitly specify additivity.Additivity should be specified when a measure is non-additive or non-aggregable.")]
        public List<Aggregation> Aggregation
        {
            get
            {
                return this.aggregationField;
            }
            set
            {
                this.aggregationField = value;
            }
        }

        /// <summary>
        /// Gets or sets the notes.
        /// </summary>
        /// <value>
        /// The notes.
        /// </value>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [Category("General"), Description("additional notes")]
        public string Notes
        {
            get
            {
                return this.notesField;
            }
            set
            {
                this.notesField = value;
            }
        }
        
        /// <summary>
        /// Adds a new aggregation to this measure.
        /// </summary>
        /// <param name="a">a.</param>
        public void AddAggregation(Aggregation a)
        {
            if(Aggregation == null)
            {
                Aggregation = new List<Aggregation>();
            }
            Aggregation.Add(a);
        }

        /// <summary>
        /// Gets the tree node for this measure.
        /// </summary>
        /// <returns></returns>
        public TreeNode GetTree()
        {
            TreeNode t = new TreeNode(this.Name);
            t.Tag = this;
            return t;
        }
    }
    

}
