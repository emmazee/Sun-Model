//------------------------------------------------------------------------------
// USMM\ConceptualModel.cs
//
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunModelWindows.USMM
{

    /// <summary>
    /// The ConceptualModel element represents an enterprise view of the analytical needs of the business.
    /// It contains all the business processes.It is modelled in the XML Schema as being able to contain zero
    /// to many business processes; thus allowing an empty file to be represented as the ConceptualModel
    /// element with no child elements. (Black, 2011)
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public class ConceptualModel
    {
        

        private List<BusinessProcess> businessProcessField;


        /// <summary>
        /// Gets or sets the business process.
        /// </summary>
        /// <value>
        /// The business process.
        /// </value>
        [System.Xml.Serialization.XmlElementAttribute("BusinessProcess")]
        public List<BusinessProcess> BusinessProcess
        {
            get
            {
                return this.businessProcessField;
            }
            set
            {
                this.businessProcessField = value;
            }
        }
        
        /// <summary>
        /// Adds a new business process to the model
        /// </summary>
        /// <param name="b">The b.</param>
        public void AddBusinessProcess(BusinessProcess b)
        {
            if(BusinessProcess == null)
            {
                BusinessProcess = new List<BusinessProcess>();
            }
            businessProcessField.Add(b);
        }
        
        /// <summary>
        /// Gets the business process with given name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public BusinessProcess GetBusinessProcess(string name)
        {
            if(this.BusinessProcess == null || this.BusinessProcess.Count()==0)
            {
                return null;
            }
           return this.BusinessProcess.Find(x => x.Name.ToLower().Equals(name.ToLower()));

        }

        /// <summary>
        /// Adds a dimension.
        /// </summary>
        /// <param name="d">The Dimension.</param>
        /// <param name="businessProcessName">Name of the business process.</param>
        public void AddDimension(Dimension d, string businessProcessName)
        {
            this.GetBusinessProcess(businessProcessName).AddDimension(d);
        }
        /// <summary>
        /// Removes the business process.
        /// </summary>
        /// <param name="businessProcessName">Name of the business process.</param>
        public void RemoveBusinessProcess(string businessProcessName)
        {
            this.BusinessProcess.Remove(this.GetBusinessProcess(businessProcessName));
        }
        /// <summary>
        /// Removes the measure.
        /// </summary>
        /// <param name="measureName">Name of the measure.</param>
        /// <param name="businessProcessName">Name of the business process.</param>
        public void RemoveMeasure(string measureName, string businessProcessName)
        {

            BusinessProcess b = this.GetBusinessProcess(businessProcessName);
            b.RemoveMeasure(measureName);
        }
        /// <summary>
        /// Removes the dimension.
        /// </summary>
        /// <param name="dimensionName">Name of the dimension.</param>
        /// <param name="businessProcessName">Name of the business process.</param>
        public void RemoveDimension(string dimensionName, string businessProcessName)
        {

            BusinessProcess b = this.GetBusinessProcess(businessProcessName);
            b.RemoveDimension(dimensionName);
        }

        /// <summary>
        /// Removes the level by uid.
        /// </summary>
        /// <param name="uid">The uid.</param>
        /// <param name="dimensionName">Name of the dimension.</param>
        /// <param name="businessProcessName">Name of the business process.</param>
        public void RemoveLevelByUID(string uid, string dimensionName, string businessProcessName)
        {
            BusinessProcess b = this.GetBusinessProcess(businessProcessName);
            b.RemoveLevelByUID(uid, dimensionName);
        }

        /// <summary>
        /// Converts the level to a shared node by uid.
        /// </summary>
        /// <param name="uid">The uid.</param>
        /// <param name="dimensionName">Name of the dimension.</param>
        /// <param name="businessProcessName">Name of the business process.</param>
        /// <param name="type">The type of reference.</param>
        public void ConvertLevelByUID(string uid, string dimensionName, string businessProcessName, ReferenceType type)
        {
            BusinessProcess b = this.GetBusinessProcess(businessProcessName);
            b.ConvertLevelByUID(uid, dimensionName, type);
        }
    }
}
