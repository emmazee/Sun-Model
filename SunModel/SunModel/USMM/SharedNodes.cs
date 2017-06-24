//------------------------------------------------------------------------------
// USMM\SharedNodes.cs
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
    /// SharedNodes element contains all the Levels that can be referred to as a shared attribute on a
    /// hierarchy, a point of convergence on a hierarchy, or a cross dimensional attribute between
    /// hierarchies.Each Level can be referred to by other Levels in Dimension elements belonging to the
    /// same Business Process.
    /// </summary>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public class SharedNodes
    {

        private List<Level> levelField;


        /// <summary>
        /// Gets or sets the level. The Levels defined in the SharedNodes element represent the starting Level, and subsequent sub-
        /// hierarchy in a dimensional hierarchy.Defining sub-hierarchies in this way reduces repetition in the
        /// schema and can avoid spawning new dimensional attributes, and is supportive of a more concise
        /// graphical notation.
        /// </summary>
        /// <value>
        /// The level.
        /// </value>
        [System.Xml.Serialization.XmlElementAttribute("Level")]
        public List<Level> Level
        {
            get
            {
                return this.levelField;
            }
            set
            {
                this.levelField = value;
            }
        }

        /// <summary>
        /// Gets the level by uid.
        /// </summary>
        /// <param name="uid">The uid.</param>
        /// <returns></returns>
        public Level GetLevelByUID(string uid)
        {
            if (this.Level != null && this.Level.Count() != 0) {
                foreach (Level l in this.Level)
                {
                    if (l.UID == uid)
                    {
                        return l;
                    }
                }
            }
            return null;
        }

        
    }
}
