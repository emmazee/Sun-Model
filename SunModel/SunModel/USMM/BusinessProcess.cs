//------------------------------------------------------------------------------
// USMM\BusinessProcess.cs
//
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Drawing.Design;

namespace SunModelWindows.USMM
{
    /// <summary>
    /// The BusinessProcess element represents the analytical needs of a particular business unit, or set of
    ///end-user analysts.The name of the business process can be represented by the Name attribute.
    ///The business process must consist of a Measures and Dimensions element.The inclusion of a
    ///SharedNodes element is optional. (Black, 2011)
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public class BusinessProcess
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessProcess"/> class.
        /// </summary>
        public BusinessProcess()
        {
            this.Measures = new List<Measure>();
            this.Paths = new List<Node>(); 
        }

        private List<Measure> measuresField;
        private List<Dimension> dimensionsField;
        private SharedNodes sharedNodesField;
        private string nameField;

        //canvas center x coordinate
        private int c_x = 200;
        //canvas center y coordinate
        private int c_y = 200;
        //measure circle diameter
        private int d;

        private List<Node> path;

        /// <summary>
        /// Gets or sets the measures.
        /// </summary>
        /// <value>
        /// The measures.
        /// </value>
        [System.Xml.Serialization.XmlArrayItemAttribute("Measure", IsNullable = false)]
        [Browsable(false)]
        public List<Measure> Measures
        {
            get
            {
                return this.measuresField;
            }
            set
            {
                this.measuresField = value;
            }
        }

        /// <summary>
        /// Gets or sets the dimensions.
        /// </summary>
        /// <value>
        /// The dimensions.
        /// </value>
        [System.Xml.Serialization.XmlArrayItemAttribute("Dimension", IsNullable = false)]
        [Browsable(false)]
        public List<Dimension> Dimensions
        {
            get
            {
                return this.dimensionsField;
            }
            set
            {
                this.dimensionsField = value;
            }
        }

        /// <summary>
        /// Gets or sets the shared nodes. (optional)
        /// </summary>
        /// <value>
        /// The shared nodes.
        /// </value>
        [Browsable(false)]
        public SharedNodes SharedNodes
        {
            get
            {
                return this.sharedNodesField;
            }
            set
            {
                this.sharedNodesField = value;
            }
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [Category("General"), Description("The name of the business process")]
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
        /// Gets or sets the nodes which contain paths.
        /// </summary>
        /// <value>
        /// The paths.
        /// </value>
        [System.Xml.Serialization.XmlIgnore]
        [Browsable(false)]
        public List<Node> Paths
        {
            get
            {
                return this.path;
            }
            set
            {
                this.path = value;
            }
        }


        /// <summary>
        /// Gets the diameter of the center circle.
        /// </summary>
        /// <param name="font">The font.</param>
        /// <param name="graphics">The graphics.</param>
        /// <returns></returns>
        protected int GetDiameter(Font font, Graphics graphics)
        {
            int maxHeight;
            int maxLength;
            int h;

            if (Measures == null || Measures.Count() == 0)
            {
                maxHeight = 0;
                maxLength = 50;
            }
            else
            {

                maxLength = Measures.Max(x => x.Name.Length);
                Measure m = Measures.FirstOrDefault(r => r.Name.Length == maxLength);
                SizeF s = graphics.MeasureString(m.Name, font);
                maxHeight = (int)(Measures.Count() * s.Height);
                maxLength = (int)(s.Width);
            }
            if (maxHeight > maxLength)
            {
                h = maxHeight;
            }
            else
            {
                h = maxLength;
            }
            return (int)(h * 1.1);
        }

        /// <summary>
        /// Removes the level by uid.
        /// </summary>
        /// <param name="uid">The uid.</param>
        /// <param name="dimensionName">Name of the dimension.</param>
        public void RemoveLevelByUID(string uid, string dimensionName)
        {
            Dimension d = this.GetDimension(dimensionName);
            d.RemoveLevelByUID(uid);
        }

        /// <summary>
        /// Converts the level by uid.
        /// </summary>
        /// <param name="uid">The uid.</param>
        /// <param name="dimensionName">Name of the dimension.</param>
        /// <param name="type">The type.</param>
        public void ConvertLevelByUID(string uid, string dimensionName, ReferenceType type)
        {
            Dimension d = this.GetDimension(dimensionName);
            Level l = d.GetLevelByUID(uid);
            if(this.SharedNodes == null)
            {
                this.SharedNodes = new SharedNodes();
            }
            if (this.SharedNodes.Level == null)
            {
                this.SharedNodes.Level = new List<Level>();
            }
            Level l2 = new Level();
            l2.Key = l.Name;
            l2.Name = l.Name;
            l2.Type = l.Type;
            l2.Level1 = l.Level1;
            this.SharedNodes.Level.Add(l2);
            if(type == ReferenceType.ConvergedKey)
            {
                l.ConvergedKey = l.Name;
            }
            else if (type == ReferenceType.CDAKey)
            {
                l.CDAKey = l.Name;
            }
            else
            {
                l.Key = l.Name;
            }
            l.Name = null;
            l.Level1 = null;
           // l.UID = null;
            
        }
        
        /// <summary>
        /// Gets the dimension with the given name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public Dimension GetDimension(string name)
        {
            if(this.Dimensions == null || this.Dimensions.Count()==0)
            {
                return null;
            }
            return this.Dimensions.Find(x => x.Name.Equals(name));

        }
        
        /// <summary>
        /// Gets the measure with the given name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public Measure GetMeasure(string name)
        {
            if (this.Measures == null || this.Measures.Count() == 0)
            {
                return null;
            }
            return this.Measures.Find(x => x.Name.ToLower().Equals(name.ToLower()));

        }

        /// <summary>
        /// Gets the shared node level by uid.
        /// </summary>
        /// <param name="uid">The uid.</param>
        /// <returns></returns>
        public Level GetSharedNodeLevelByUID(string uid)
        {
            if(this.SharedNodes != null)
            {
                return this.SharedNodes.GetLevelByUID(uid);
            }
            return null;
        }
        
        /// <summary>
        /// Adds a measure to the business process.
        /// </summary>
        /// <param name="m">The m.</param>
        public void AddMeasure(Measure m)
        {
            if (Measures == null)
            {
                Measures = new List<Measure>();
            }
            Measures.Add(m);
           
        }

        /// <summary>
        /// Removes the measure with the given name.
        /// </summary>
        /// <param name="name">The name.</param>
        public void RemoveMeasure(string name)
        {
            Measure m = this.Measures.Find(x => x.Name.ToLower().Equals(name.ToLower()));
            this.Measures.Remove(m);
        }

        /// <summary>
        /// Adds a dimension to a business process.
        /// </summary>
        /// <param name="d">The Dimesnion d.</param>
        public void AddDimension(Dimension d)
        {
            if (Dimensions == null)
            {
                Dimensions = new List<Dimension>();
            }
            Dimensions.Add(d);
        }
        

        /// <summary>
        /// Removes the dimension with the given name.
        /// </summary>
        /// <param name="name">The name.</param>
        public void RemoveDimension(string name)
        {
            Dimension d = this.Dimensions.Find(x => x.Name.ToLower().Equals(name.ToLower()));
            this.Dimensions.Remove(d);
        }
        
        /// <summary>
        /// Gets the tree for this process.
        /// </summary>
        /// <returns></returns>
        public TreeNode GetTree()
        {
            TreeNode TreeMeasures = new TreeNode("Measures");
            if (Measures != null && Measures.Count > 0)
            {
                foreach (Measure m in Measures)
                {
                    TreeMeasures.Nodes.Add(m.GetTree());
                }
            }
            TreeNode TreeDimensions = new TreeNode("Dimensions");
            if (Dimensions != null && Dimensions.Count > 0)
            {
                foreach (Dimension d in Dimensions)
                {
                    TreeDimensions.Nodes.Add(d.GetTree(this.SharedNodes));

                }
            }

            TreeNode treeNode;
            if (this.SharedNodes != null && SharedNodes.Level != null && SharedNodes.Level.Count() > 0)
            {
                TreeNode TreeShared = new TreeNode("Shared Nodes");
                TreeShared.ForeColor = Color.Red;
                foreach (Level l in SharedNodes.Level)
                {
                    TreeShared.Nodes.Add(l.GetTree(this.SharedNodes, Color.Red));
                }
                treeNode = new TreeNode(Name, new TreeNode[] { TreeMeasures, TreeDimensions, TreeShared });
            }
            else
            {
                treeNode = new TreeNode(Name, new TreeNode[] { TreeMeasures, TreeDimensions });
            }
            return treeNode;
        }

        /// <summary>
        /// Gets the center x.
        /// </summary>
        /// <returns></returns>
        public int GetCenterX()
        {
            return c_x;

        }

        /// <summary>
        /// Gets the center y.
        /// </summary>
        /// <returns></returns>
        public int GetCenterY()
        {
            return c_y;
        }

        /// <summary>
        /// Draws the sun model graphics.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="centerX">The center x.</param>
        /// <param name="centerY">The center y.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="zoom">The zoom.</param>
        public void DrawSunModelGraphics(Graphics graphics, int centerX, int centerY, int width, int height, double zoom)
        {
            this.Paths = new List<Node>();
            this.c_x = centerX;
            this.c_y = centerY;
          
            //Draw Measures
            string text = "";
            if (Measures != null)
            {
                text = string.Join("\n", Measures.Select(m => m.Name));

            }
            double fontzoom = zoom;
            if (zoom <= 0.125)
            {
                fontzoom = 0.125;
            }
            Font font2 = new Font("Arial", (int)(8 * fontzoom), FontStyle.Regular, GraphicsUnit.Point);
            int diameter = this.GetDiameter(font2, graphics);


            Rectangle rect2 = new Rectangle(GetCenterX() - diameter / 2, GetCenterY() - diameter / 2, diameter, diameter);

                // Specify the text is wrapped.
                TextFormatFlags flags = TextFormatFlags.WordBreak | TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter;
                TextRenderer.DrawText(graphics, text, font2, rect2, Color.Black, flags);
                graphics.DrawEllipse(System.Drawing.Pens.Black, rect2);
              
            

            //Draw first arms
            if (Dimensions != null && Dimensions.Count() > 0)
            {
                //angle in radians
                double incrementAngle = 2 * Math.PI / Dimensions.Count();
                double angle = 0;

                foreach (Dimension d in Dimensions)
                {

                    angle = angle + incrementAngle;

                    var radius = diameter / 2.0f;

                    d.X_position = Math.Sin(angle);
                    d.Y_position = Math.Cos(angle);

                    d.X_position *= (radius);
                    d.Y_position *= (radius);

                    d.X_position += GetCenterX();
                    d.Y_position += GetCenterY();

                    Font font = new Font("Arial", (int)(20 * zoom), FontStyle.Regular, GraphicsUnit.Point);
                    
                    double fontX = Math.Sin(angle);
                    fontX *= (width/2);
                    fontX += GetCenterX();
                    SizeF s = graphics.MeasureString(d.Name, font);
                    if (fontX > s.Width)
                    {
                        fontX -= s.Width / 2;
                    }
                    if (fontX > width - s.Width)
                    {
                        fontX = width - s.Width;
                    }
                    double fontY = Math.Cos(angle);
                    fontY *= (height / 2);
                    fontY += GetCenterY();
                    if(fontY > font.GetHeight())
                    {
                        fontY -= font.GetHeight() / 2;
                    }
                    if (fontY > height - font.GetHeight() )
                    {
                        fontY = height - font.GetHeight();
                    }
                    graphics.DrawString(d.Name, font, new SolidBrush(Color.DarkGray),
                        (float)fontX, (float)fontY);

                    this.Paths.AddRange(d.DrawDimensionGraphics(angle, graphics, SharedNodes, zoom));

                }
            }
        }
    }
}
