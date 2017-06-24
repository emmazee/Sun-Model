//------------------------------------------------------------------------------
// USMM\Level.cs
//
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SunModelWindows.USMM
{
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public class Level
    {
        //A Level element in the USMM represents a location in a hierarchy as well as the dimensional
        //attribute itself.Children of a dimensional attribute are represented as a sequence of Level elements.
        //This relationship of defining levels within levels is how a dimensional hierarchy is built.A Level
        //element can contain zero to many Levels.An instance of a Level element with zero children is a leaf
        //node.
      
        private List<Level> level1Field;
        private LevelType typeField;
        private bool optionalLevelField;
        private bool optionalRelationshipField;
        private bool multipleRelationshipField;
        private string nameField;
        private string uIDField;
        private string keyField;
        private string convergedKeyField;
        private string cDAKeyField;
        private bool recursiveField;
        private double x_position;
        private double y_position;

        /// <summary>
        /// Initializes a new instance of the <see cref="Level"/> class.
        /// </summary>
        public Level()
        {
            this.optionalLevelField = false;
            this.optionalRelationshipField = false;
            this.multipleRelationshipField = false;
            this.recursiveField = false;
            if (this.uIDField == null) {
                this.uIDField = Guid.NewGuid().ToString();
            }
        }
       
        public Level(Level other)
        {
            if (other.Level1 != null)
            {
                this.Level1 = new List<Level>(other.Level1);
            }
            this.Type = other.Type;
            this.CDAKey = other.CDAKey;
            this.ConvergedKey = other.ConvergedKey;
            this.Key = other.Key;
            this.MultipleRelationship = other.MultipleRelationship;
            this.Name = other.Name;
            this.OptionalLevel = other.OptionalLevel;
            this.OptionalRelationship = other.OptionalRelationship;
            this.Recursive = other.Recursive;
        }



        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [Browsable(true)]
        [ReadOnly(false)]
        [System.ComponentModel.Category("General"), Description("The Name attribute is used to provide a friendly name to describe the dimensional attribute.")]
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
        /// Gets or sets the level1.
        /// </summary>
        /// <value>
        /// The level1.
        /// </value>
        [System.Xml.Serialization.XmlElementAttribute("Level")]
        [Browsable(false)]
        [ReadOnly(false)]
        public List<Level> Level1
        {
            get
            {
                return this.level1Field;
            }
            set
            {
                this.level1Field = value;
            }
        }

        
        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        [System.Xml.Serialization.XmlAttributeAttribute(AttributeName = "Type")]
        [DefaultValueAttribute(LevelType.analytical)]
        [Browsable(true)]
        [ReadOnly(false)]
        [System.ComponentModel.Category("General"), Description("The Type attribute defines whether the dimensional attribute is Descriptive or Analytical. A Descriptive attribute should always been a leaf node in a hierarchy and describe a quality of the Level containing it.An Analytical dimensional attribute defines a point along an aggregation path in a dimensional hierarchy.The default value for the Type attribute is Analytical")]
        public LevelType Type
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
        /// Gets or sets a value indicating whether [optional level].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [optional level]; otherwise, <c>false</c>.
        /// </value>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(false)]
        [Browsable(true)]
        [ReadOnly(false)]
        [System.ComponentModel.Category("Heirarchy"), Description("The OptionalLevel attribute is used to define an optional dimensional attribute in a ragged hierarchy. The default value is false meaning the Level is mandatory.A value of true means that this Level is optional.Further levels can be defined inside a Level, whether OptionalLevel is true or not.")]
        public bool OptionalLevel
        {
            
            get
            {
                return this.optionalLevelField;
            }
            set
            {
                this.optionalLevelField = value;
            }
        }



        /// <summary>
        /// Gets or sets a value indicating whether [optional relationship].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [optional relationship]; otherwise, <c>false</c>.
        /// </value>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(false)]
        [Browsable(true)]
        [ReadOnly(false)]
        [System.ComponentModel.Category("Heirarchy"), Description("The OptionalRelationship attribute is used to define an optional relationship in a hierarchy. The relationship is between the Level the attribute is defined on, and its parent in the hierarchy. The default value is false meaning the dimensional attribute is a mandatory part of the hierarchy. A value of true means the branch of the hierarchy is optional.")]
        public bool OptionalRelationship
        {
            get
            {
                return this.optionalRelationshipField;
            }
            set
            {
                this.optionalRelationshipField = value;
            }
        }


        /// <summary>
        /// Gets or sets a value indicating whether [multiple relationship].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [multiple relationship]; otherwise, <c>false</c>.
        /// </value>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(false)]
        [Browsable(true)]
        [ReadOnly(false)]
        [System.ComponentModel.Category("General"), Description("The MultipleRelationship attribute is used to define many-to-many relationships between levels. The default value is false, meaning a one-to-many (one parent to many children) relationship exists. The MultipleRelationship attribute is set to true on the child element of the relationship, defining a many-to-many relationship with its parent.")]
        public bool MultipleRelationship
        {
            get
            {
                return this.multipleRelationshipField;
            }
            set
            {
                this.multipleRelationshipField = value;
            }
        }



        /// <summary>
        /// Gets or sets the uid.
        /// </summary>
        /// <value>
        /// The uid.
        /// </value>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [ReadOnly(true)]
        [Browsable(true)]
        [System.ComponentModel.Category("Referencing"), Description("The UID attribute is used to provide a unique identifier for the dimensional attribute.There are a number of uses for the UID. For example, it can be used to allow an Aggregation element belonging to a Measure to reference the appropriate dimensional attribute (Level). It can be used by supplementary documentation to accurately describe a specific dimensional attribute.")]
        public string UID
        {
            
            get
            {
                return this.uIDField;
            }
            set
            {
                this.uIDField = value;
            }
        }


        /// <summary>
        /// Gets or sets the key.
        /// </summary>
        /// <value>
        /// The key.
        /// </value>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [Browsable(true)]
        [ReadOnly(true)]
        [System.ComponentModel.Category("Referencing"), Description("The Key attribute is used to define a reference parameter when specified on a Level belonging to the SharedNodes element. When the Key attribute is used on a Level in a Dimension, it refers to the corresponding Level in the SharedNodes element.")]
        public string Key
        {
            get
            {
                return this.keyField;
            }
            set
            {
                this.keyField = value;
            }
        }


        /// <summary>
        /// Gets or sets the converged key.
        /// </summary>
        /// <value>
        /// The converged key.
        /// </value>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [Browsable(true)]
        [ReadOnly(true)]
        [System.ComponentModel.Category("Referencing"), Description("The ConvergedKey attribute is used to refer to a Level in the SharedNodes element.The value of Key corresponds with the value of the ConvergedKey.This reference indicates that all Levels should be treated as the same entity by any Level using the same ConvergedKey value.")]
        public string ConvergedKey
        {
            get
            {
                return this.convergedKeyField;
            }
            set
            {
                this.convergedKeyField = value;
            }
        }


        /// <summary>
        /// Gets or sets the cda key.
        /// </summary>
        /// <value>
        /// The cda key.
        /// </value>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [Browsable(true)]
        [ReadOnly(true)]
        [System.ComponentModel.Category("Referencing"), Description("The CDAKey attribute is used to create a Cross Dimensional Attribute. Similar to the ConvergedKey, the CDAKey value is used to refer to the corresponding Key value of a Level in the SharedNodes element.All corresponding CDAKey values point to the same dimensional attribute(Level).")]
        public string CDAKey
        {
            get
            {
                return this.cDAKeyField;
            }
            set
            {
                this.cDAKeyField = value;
            }
        }


        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Level"/> is recursive.
        /// </summary>
        /// <value>
        ///   <c>true</c> if recursive; otherwise, <c>false</c>.
        /// </value>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(false)]
        [Browsable(true)]
        [ReadOnly(false)]
        [System.ComponentModel.Category("Heirarchy"), Description("The Recursive attribute supports the concept of an unbalanced hierarchy resulting from an aggregation path of a hierarchy containing a recursive parent-child relationship.The default value is false defining no recursive relationship with its parent; a value of true, means there is a recursive relationship.No limit is defined explicitly in the schema to constrain the number of levels resulting from recursion.")]
        public bool Recursive
        {
            
            get
            {
                return this.recursiveField;
            }
            set
            {
                this.recursiveField = value;
            }
        }

        /// <summary>
        /// Gets or sets the x position.
        /// </summary>
        /// <value>
        /// The x position.
        /// </value>
        [System.Xml.Serialization.XmlIgnore]
        [Browsable(false)]
        [ReadOnly(false)]
        public double X_position
        {
            get
            {
                return this.x_position;
            }
            set
            {
                this.x_position = value;
            }
        }
        /// <summary>
        /// Gets or sets the y position.
        /// </summary>
        /// <value>
        /// The y position.
        /// </value>
        [System.Xml.Serialization.XmlIgnore]
        [Browsable(false)]
        [ReadOnly(false)]
        public double Y_position
        {
            get
            {
                return this.y_position;
            }
            set
            {
                this.y_position = value;
            }
        }

        /// <summary>
        /// Flattens the children into a list of levels.
        /// </summary>
        /// <returns></returns>
        public List<Level> FlattenChildren()
        {
            List<Level> l = new List<Level>();
            if(this.Level1!=null && this.Level1.Count() > 0)
            {

                foreach (Level lvl in this.Level1)
                {
                    l.Add(lvl);
                    l.AddRange(lvl.FlattenChildren());
                }
            }
            return l;
        }

        /// <summary>
        /// Gets the tree for this level.
        /// </summary>
        /// <param name="s">The Shared Nodes s.</param>
        /// <param name="highlight">The highlight.</param>
        /// <returns></returns>
        public TreeNode GetTree(SharedNodes s, Color? highlight = null)
        {
          

            List<TreeNode> array = new List<TreeNode>();

            if (this.IsSharedLevel())
            {
                Level sharedLevel = new Level(GetSharedLevel(s));

                if (sharedLevel.Level1 != null)
                {
                    foreach (Level l in sharedLevel.Level1)
                    {
                        array.Add(l.GetTree(s, Color.Red));
                    }
                }
                TreeNode st = new TreeNode(sharedLevel.Name, array.ToArray());
                st.Name = this.UID;
                Level tagLevel = this;
                st.Tag = tagLevel;
                st.ForeColor = highlight.GetValueOrDefault(Color.Red);
                //   return sharedLevel.GetTree(s, Color.Red);
                return st;
            }
            else
            {
                if (this.Level1 != null)
                {
                    foreach (Level l in this.Level1)
                    {
                        array.Add(l.GetTree(s, highlight));
                    }
                }
                TreeNode t1 = new TreeNode(this.Name, array.ToArray());
                t1.Name = this.UID;
                t1.Tag = this;
                t1.ForeColor = highlight.GetValueOrDefault(Color.Black);
                return t1;
            }
        }

        /// <summary>
        /// Determines whether [is shared level].
        /// </summary>
        /// <returns>
        ///   <c>true</c> if [is shared level]; otherwise, <c>false</c>.
        /// </returns>
        public bool IsSharedLevel()
        {
            if (this.ConvergedKey != null)
            {
                return true;
            }
            else if (this.CDAKey != null)
            {
                return true;

            }
            else if (this.Name == null && this.Key != null)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Gets the shared level this refers to.
        /// </summary>
        /// <param name="s">The SharedNodes s.</param>
        /// <returns></returns>
        public Level GetSharedLevel(SharedNodes s)
        {
            if (this.ConvergedKey != null)
            {
                return s.Level.First(item => item.Key == this.ConvergedKey);
            }
            else if (this.CDAKey != null)
            {
                return s.Level.First(item => item.Key == this.CDAKey);

            }
            else if (this.Name == null && this.Key != null)
            {
                return s.Level.First(item => item.Key == this.Key);
            }
            return null;
        }

        /// <summary>
        /// Gets the level by uid.
        /// </summary>
        /// <param name="uid">The uid.</param>
        /// <returns></returns>
        public Level GetLevelByUID(string uid)
        {
            Level lvl;
            if (this.Level1 == null || this.Level1.Count() == 0)
            {
                return null;
            }
            foreach(Level l in this.Level1)
            {
                if (l.UID == uid)
                {
                    return l;
                }
                else
                {
                    lvl = l.GetLevelByUID(uid);
                    if (lvl != null)
                    {
                        return lvl;
                    }
                }
            }
            return null; 
        }

        /// <summary>
        /// Removes the level by uid.
        /// </summary>
        /// <param name="uid">The uid.</param>
        public void RemoveLevelByUID(string uid)
        {
            if (this.Level1 == null || this.Level1.Count() == 0)
            {
                return;
            }
            foreach (Level l in this.Level1)
            {
                if (l.UID == uid)
                {
                    this.Level1.Remove(l);
                    return;
                }
                else
                {
                    l.RemoveLevelByUID(uid);
                }
            }
            return;
        }

        /// <summary>
        /// Draws the level graphics.
        /// </summary>
        /// <param name="startAngle">The start angle.</param>
        /// <param name="graphics">The graphics.</param>
        /// <param name="s">The Shared Node s.</param>
        /// <param name="PrevX">The previous x position.</param>
        /// <param name="PrevY">The previous y y position.</param>
        /// <param name="highlight">if set to <c>true</c> [highlight].</param>
        /// <param name="zoom">The zoom.</param>
        /// <returns></returns>
        public List<Node> DrawLevelGraphics(double startAngle, Graphics graphics, SharedNodes s, double PrevX, double PrevY, bool highlight, double zoom)
        {
            Node node = new Node(this, highlight, PrevX, PrevY);
            List<Node> n = new List<Node>();
            n.Add(node);
            node.Draw(graphics, zoom);
            n.AddRange(DrawChildrenGraphics(X_position, Y_position, startAngle, graphics, s, highlight, zoom));
            return n;

        }

        /// <summary>
        /// Draws the children graphics.
        /// </summary>
        /// <param name="startX">The start x.</param>
        /// <param name="startY">The start y.</param>
        /// <param name="startAngle">The start angle.</param>
        /// <param name="graphics">The graphics.</param>
        /// <param name="s">The Shared Node s.</param>
        /// <param name="highlight">if set to <c>true</c> [highlight].</param>
        /// <param name="zoom">The zoom.</param>
        /// <returns></returns>
        public List<Node> DrawChildrenGraphics(double startX, double startY, double startAngle, Graphics graphics, SharedNodes s, bool highlight, double zoom)
        {
            List<Node> p = new List<Node>();

            if (Level1 == null)
            {
                return p;
            }
            if (this.IsSharedLevel())
            {
                Level shared = GetSharedLevel(s);
                shared.UID = Guid.NewGuid().ToString();
                p.AddRange(shared.DrawChildrenGraphics(startX, startY, startAngle, graphics, s, true, zoom));

            }
            double incrementAngleAtt = 2 * Math.PI / (Level1.Count() + 3);

            startAngle += -Math.PI;
            startAngle += incrementAngleAtt;

            foreach (Level l in Level1)
            {
                startAngle += incrementAngleAtt;


                if (l.IsSharedLevel())
                {
                    Level shared = new Level(l.GetSharedLevel(s));

                    shared.X_position = Math.Sin(startAngle);
                    shared.Y_position = Math.Cos(startAngle);
                    shared.X_position *= 90.0 * zoom;
                    shared.Y_position *= 90.0 * zoom;
                    shared.X_position += startX;
                    shared.Y_position += startY;
                    shared.UID = Guid.NewGuid().ToString();
                    p.AddRange(shared.DrawLevelGraphics(startAngle, graphics, s, startX, startY, true,zoom ));
     
                }
                else
                {
                    l.X_position = Math.Sin(startAngle);
                    l.Y_position = Math.Cos(startAngle);

                    l.X_position *= 90.0 * zoom;
                    l.Y_position *= 90.0 * zoom;
                    l.X_position += startX;
                    l.Y_position += startY;
                    p.AddRange(l.DrawLevelGraphics(startAngle, graphics, s, startX, startY, highlight,zoom));
                }
            }
            return p;
        }
    }
}
