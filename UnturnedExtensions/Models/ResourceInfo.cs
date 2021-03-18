using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDG.Unturned;
using UnityEngine;

namespace ShimmyMySherbet.UnturnedExtensions.Models
{
    public struct ResourceInfo
    {
        public static readonly ResourceInfo Nil = new ResourceInfo(null, null, 0, 0, 0);

        public Transform Transform;
        public ResourceSpawnpoint Spawnpoint;
        public byte X;
        public byte Y;
        public ushort Index;

        public ResourceInfo(Transform transform, ResourceSpawnpoint resourceSpawnpoint, byte x, byte y, ushort index)
        {
            Transform = transform;
            Spawnpoint = resourceSpawnpoint;
            X = x;
            Y = y;
            Index = index;
        }

    }
}
