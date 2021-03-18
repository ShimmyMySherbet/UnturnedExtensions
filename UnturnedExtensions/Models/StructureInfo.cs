using SDG.Unturned;
using UnityEngine;

namespace ShimmyMySherbet.UnturnedExtensions.Models
{
    public struct StructureInfo
    {
        public static readonly StructureInfo Nil = new StructureInfo(null, null, null, null, 0, 0, 0);

        public StructureData Data;
        public StructureRegion Region;
        public StructureDrop Drop;
        public Transform Transform;

        public Structure Structure
        {
            get
            {
                if (Data == null) return null;
                return Data.structure;
            }
        }

        public byte X;
        public byte Y;
        public ushort Index;

        public StructureInfo(StructureRegion region, StructureData data, StructureDrop drop, Transform transform, byte x, byte y, ushort index)
        {
            Data = data;
            Region = region;
            Drop = drop;
            Transform = transform;
            X = x;
            Y = y;
            Index = index;
        }
    }
}