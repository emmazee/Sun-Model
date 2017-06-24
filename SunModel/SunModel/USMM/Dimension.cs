//------------------------------------------------------------------------------
// Dimension.cs
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

    /// <summary>
    /// The Dimension element contains a hierarchy of dimensional attributes represented as Level
    ///elements.The Dimension element specifies the initial (outer) Level element, referred to by some as
    ///the terminal dimensional attribute.The Name attribute specifies the name of the dimension. (Black, 2011)
    /// </summary>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public class Dimension
    {

        private Level levelField;
        private string nameField;
        private double x_position;
        private double y_position;

        /// <summary>
        /// Gets or sets the initial (outer) Level element, referred to by some as the terminal dimensional attribute. (Black, 2011)
        /// </summary>
        /// <value>
        /// The level.
        /// </value>
        [Browsable(false)]
        public Level Level
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
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [Category("General"),Description("Name of the dimension")]
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
        /// Gets or sets the x position.
        /// </summary>
        /// <value>
        /// The x position.
        /// </value>
        [System.Xml.Serialization.XmlIgnore]
        [Browsable(false)]
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
        /// Gets the tree for this dimension.
        /// </summary>
        /// <param name="s">The shared nodes s.</param>
        /// <returns></returns>
        public TreeNode GetTree(SharedNodes s)
        {
            if(this.Level == null)
            {
                TreeNode t1 = new TreeNode(this.Name);
                t1.Tag = this;
               // t1.Name = this.UID;
                return t1;
            }
            List<TreeNode> array = new List<TreeNode>();
     
            array.Add(this.Level.GetTree(s));
            TreeNode t2 = new TreeNode(this.Name, array.ToArray());
            t2.Tag = this;
           // t2.Name = this.UID;
            return t2;


        }

        /// <summary>
        /// Gets all the dimension levels in a flat list.
        /// </summary>
        /// <returns></returns>
        public List<Level> GetDimensionAllLevels()
        {
            List<Level> l = new List<Level>();
            if(this.Level == null)
            {
                return l;
            }
            l.Add(this.Level);
            l.AddRange(this.Level.FlattenChildren());
            return l;
          
        }

        /// <summary>
        /// Gets the level by uid.
        /// </summary>
        /// <param name="uid">The uid.</param>
        /// <returns></returns>
        public Level GetLevelByUID(string uid)
        {
            if (this.Level == null)
            {
                return null;
            }
            if(this.Level.UID == uid)
            {
                return this.Level;
            }
            return this.Level.GetLevelByUID(uid);
        }
        /// <summary>
        /// Removes the level by uid.
        /// </summary>
        /// <param name="uid">The uid.</param>
        public void RemoveLevelByUID(string uid)
        {
            if (this.Level == null)
            {
                return;
            }
            if (this.Level.UID == uid)
            {
                this.Level = null;
                return;
            }
            this.Level.RemoveLevelByUID(uid);
            return;
        }


        /// <summary>
        /// Draws the dimension graphics.
        /// </summary>
        /// <param name="startAngle">The start angle.</param>
        /// <param name="graphics">The graphics.</param>
        /// <param name="s">The Shared Nodess.</param>
        /// <param name="zoom">The zoom.</param>
        /// <returns></returns>
        public List<Node> DrawDimensionGraphics(double startAngle, Graphics graphics, SharedNodes s, double zoom)
        {

            if (Level == null)
            {
                return new List<Node>(); ;
            }
            if (Level.IsSharedLevel())
            {
                Level start = new Level(Level.GetSharedLevel(s));
             

                start.UID = Guid.NewGuid().ToString();

                start.X_position = Math.Sin(startAngle);
                start.Y_position = Math.Cos(startAngle);

                start.X_position *= 80.0 * zoom;
                start.Y_position *= 80.0 * zoom;
                start.X_position += X_position;
                start.Y_position += Y_position;
                
                return start.DrawLevelGraphics(startAngle, graphics, s, X_position, Y_position,true,zoom);
            }
            else
            {
                Level.X_position = Math.Sin(startAngle);
                Level.Y_position = Math.Cos(startAngle);

                Level.X_position *= 80.0 * zoom;
                Level.Y_position *= 80.0 * zoom;
                Level.X_position += X_position;
                Level.Y_position += Y_position;

                return Level.DrawLevelGraphics(startAngle,  graphics, s, X_position, Y_position,false,zoom);
            }
           

        }
    }
}
