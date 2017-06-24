//------------------------------------------------------------------------------
// USMM\ENUM.cs
//
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SunModelWindows.USMM
{
    /// <summary>
    /// The type of measure
    /// </summary>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public enum MeasureType
    {
        analytical,
        descriptive,
    }
    /// <summary>
    /// The type of level
    /// </summary>
    [System.SerializableAttribute()]
    [XmlTypeAttribute(AnonymousType = true)]
    public enum LevelType :int
    {
        analytical,
        descriptive 
    }

    /// <summary>
    /// The part of the Sun Model
    /// </summary>
    public enum SunModelPart
    {
        Dimension,
        Measure,
        MeasureGroup,
        DimensionGroup,
        BusinessProcess,
        Attribute,
        SharedNode,
        SharedNodeReference,
        SharedNodes,
        None
    }
    /// <summary>
    /// The type of reference to the shared node
    /// </summary>
    public enum ReferenceType
    {
        Key,
        ConvergedKey,
        CDAKey
    }
}
