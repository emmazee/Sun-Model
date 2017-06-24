//------------------------------------------------------------------------------
// Utils.cs
//
//------------------------------------------------------------------------------

using SunModelWindows.USMM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SunModelWindows
{
    /// <summary>
    /// Utility class
    /// </summary>
    public static class Utils
    {
        /// <summary>
        /// Given a tree node returns the coressponding Sun Model part.
        /// </summary>
        /// <param name="t">The TreeNode t.</param>
        /// <returns>SunModelPart</returns>
        public static SunModelPart GetTreeNodeClass(TreeNode t)
        {

            string path = t.FullPath;
            List<string> pathList = path.Split('\\').ToList();
            if(pathList.Count()==1)
            {
                return SunModelPart.BusinessProcess;
            }
            
            if(pathList.Count()==2)
            {
                if(pathList[1] == "Measures")
                {
                    return SunModelPart.MeasureGroup;
                }
                if (pathList[1] == "Dimensions")
                {
                    return SunModelPart.DimensionGroup;
                }
                if (pathList[1] == "Shared Nodes")
                {
                    return SunModelPart.SharedNodes;
                }
            }
            if (pathList.Count() == 3)
            {
                if (pathList[1] == "Measures")
                {
                    return SunModelPart.Measure;
                }
                if (pathList[1] == "Dimensions")
                {
                    return SunModelPart.Dimension;
                }
                if (pathList[1] == "Shared Nodes")
                {
                    return SunModelPart.SharedNode;
                }
            }
            if (pathList.Count() > 3)
            {
                if (pathList[1] == "Dimensions")
                {
                    if(t.ForeColor != System.Drawing.Color.Black)
                    {
                        return SunModelPart.SharedNodeReference;
                    }
                    return SunModelPart.Attribute;
                }
                if (pathList[1] == "Shared Nodes")
                {
                    if (((Level)t.Tag).IsSharedLevel())
                    {
                        return SunModelPart.SharedNodeReference;
                    }
                    return SunModelPart.SharedNode;
                }
            }
             return SunModelPart.None;
        }

        /// <summary>
        /// Gets the name of the business process given a TreeNode.
        /// </summary>
        /// <param name="t">The TreeNode t.</param>
        /// <returns>The business process name</returns>
        public static string GetBusinessProcessName(TreeNode t)
        {
            string path = t.FullPath;
            List<string> pathList = path.Split('\\').ToList();
            return pathList[0];

        }
        public static string GetDimension(TreeNode t)
        {
            if(t.Parent.Text == "Dimensions")
            {
                return t.Text;
            }
            else
            {
                return GetDimension(t.Parent);
            }

        }
        /// <summary>
        /// Gets the tree node by unique identifier.
        /// </summary>
        /// <param name="uid">The uid.</param>
        /// <param name="tv">The TreeView we are looking at tv.</param>
        /// <returns>TreeNode</returns>
        public static TreeNode GetTreeNodeByGUID(string uid, TreeView tv)
        {
            TreeNodeCollection t = tv.Nodes;
            TreeNode[] nodes = t.Find(uid, true);
           if(nodes.Count() == 0)
            {
                return null;
            }
            return nodes[0];
        }
   
    }
}
