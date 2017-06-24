using SunModelWindows.USMM;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//------------------------------------------------------------------------------
// Node.cs
//
//------------------------------------------------------------------------------

namespace SunModelWindows
{
    public class Node
    {
        private GraphicsPath path;
        private Rectangle rect;
        private Level level;
        private bool highlight;
        private double parentX;
        private double parentY;

        /// <summary>
        /// Initializes a new instance of the <see cref="Node"/> class.
        /// </summary>
        /// <param name="l">The level.</param>
        /// <param name="h">if set to <c>true</c> highlight.</param>
        /// <param name="pX">The position x.</param>
        /// <param name="pY">The position y.</param>
        public Node (Level l, bool h, double pX, double pY)
        {
            this.Path = new GraphicsPath();
            this.Level = l;
            this.Highlight = h;
            this.ParentX = pX;
            this.ParentY = pY;
            this.Rect = new Rectangle((int)this.Level.X_position - 4, (int)this.Level.Y_position - 4, 8, 8);
        }
        /// <summary>
        /// Gets or sets the path. Set via draw method and used to check if a node is selected
        /// </summary>
        /// <value>
        /// The path.
        /// </value>
        public GraphicsPath Path
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
        /// Gets or sets the level.
        /// </summary>
        /// <value>
        /// The level.
        /// </value>
        public Level Level
        {

            get
            {
                return this.level;
            }
            set
            {
                this.level = value;
            }
        }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Node"/> is highlighted.
        /// </summary>
        /// <value>
        ///   <c>true</c> if highlighted; otherwise, <c>false</c>.
        /// </value>
        public bool Highlight
        {

            get
            {
                return this.highlight;
            }
            set
            {
                this.highlight = value;
            }
        }
        /// <summary>
        /// Gets or sets the parent x corrdinate.
        /// </summary>
        /// <value>
        /// The parent x corrdinate.
        /// </value>
        public double ParentX
        {

            get
            {
                return this.parentX;
            }
            set
            {
                this.parentX = value;
            }
        }
        /// <summary>
        /// Gets or sets the parent y corrdinate.
        /// </summary>
        /// <value>
        /// The parent y corrdinate.
        /// </value>
        public double ParentY
        {

            get
            {
                return this.parentY;
            }
            set
            {
                this.parentY = value;
            }
        }
        /// <summary>
        /// Gets or sets the rectangle to base the nodes circle on, this is done in the contructor based off the coordinates and height.
        /// </summary>
        /// <value>
        /// The rectangle.
        /// </value>
        public Rectangle Rect
        {

            get
            {
                return this.rect;
            }
            set
            {
                this.rect = value;
            }
        }
        /// <summary>
        /// Gets the brush to be used to draw the node.
        /// </summary>
        /// <returns></returns>
        public SolidBrush GetBrush()
        {
            if (this.Highlight)
            {
                return new SolidBrush(Color.Red);
            }
            return new SolidBrush(Color.Black);
        }

        /// <summary>
        /// Draws the node and a line to its parent on the graphics g given a zoom factor.
        /// </summary>
        /// <param name="g">The graphics.</param>
        /// <param name="zoom">The zoom.</param>
        public void Draw(Graphics g, double zoom)
        {
            if (zoom < 0.125) { zoom = 0.125; }
            this.Path.AddEllipse(this.Rect);
            g.FillEllipse(this.GetBrush(), Rect);
            g.DrawString(this.Level.Name, new Font("Arial", (int)(8*zoom), FontStyle.Regular, GraphicsUnit.Point), new SolidBrush(Color.Black), (float)this.Level.X_position + 4, (float)this.Level.Y_position + 4);
            g.DrawLine(System.Drawing.Pens.Black, (float)this.Level.X_position, (float)this.Level.Y_position, (float)this.ParentX, (float)this.ParentY);
        }
    }
}
