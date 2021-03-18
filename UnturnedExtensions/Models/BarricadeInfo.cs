using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDG.Unturned;
using Steamworks;
using UnityEngine;

namespace ShimmyMySherbet.UnturnedExtensions.Models
{
    public struct BarricadeInfo
    {
        public static readonly BarricadeInfo Nil = new BarricadeInfo(null, null, null, null, 0, 0, 0, 0);

        public BarricadeData Data;
        public BarricadeRegion Region;
        public BarricadeDrop Drop;
        public Transform Transform;

        public Barricade Barricade
        {
            get
            {
                if (Data == null) return null;
                return Data.barricade;
            }
        }

        public byte X;
        public byte Y;
        public ushort Index;
        public ushort Plant;

        public BarricadeInfo(BarricadeRegion region, BarricadeData data, BarricadeDrop drop, Transform transform, byte x, byte y, ushort index, ushort plant)
        {
            Data = data;
            Region = region;
            Drop = drop;
            Transform = transform;
            X = x;
            Y = y;
            Index = index;
            Plant = plant;
        }
    }
}
