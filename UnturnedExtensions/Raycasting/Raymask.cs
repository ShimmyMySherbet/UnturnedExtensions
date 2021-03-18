using SDG.Unturned;

namespace ShimmyMySherbet.UnturnedExtensions.Raycasting
{
    public class Raymask
    {
        public static Raymask Default => new Raymask(RayMasks.DEFAULT);

        public static Raymask All => new Raymask(RayMasks.BARRICADE | RayMasks.ENEMY | RayMasks.ENTITY | RayMasks.ENVIRONMENT | RayMasks.GROUND
            | RayMasks.GROUND2 | RayMasks.ITEM | RayMasks.LARGE | RayMasks.MEDIUM | RayMasks.PLAYER | RayMasks.RESOURCE | RayMasks.STRUCTURE | RayMasks.VEHICLE);

        public int Mask { get; set; } = 0;

        /// <summary>
        /// Creates a blank raymask. Add layers using .With methods.
        /// </summary>
        public Raymask()
        {
        }

        /// <summary>
        /// Creates a raymask using an existing mask.
        /// </summary>
        public Raymask(int mask)
        {
            Mask = mask;
        }

        public Raymask WithWater()
        {
            Mask = Mask | RayMasks.WATER;
            return this;
        }

        public Raymask WithPlayer()
        {
            Mask = Mask | RayMasks.PLAYER;
            return this;
        }

        public Raymask WithEnemy()
        {
            Mask = Mask | RayMasks.ENEMY;
            return this;
        }

        public Raymask WithDebris()
        {
            Mask = Mask | RayMasks.DEBRIS;
            return this;
        }

        public Raymask WithItem()
        {
            Mask = Mask | RayMasks.ITEM;
            return this;
        }

        public Raymask WithResource()
        {
            Mask = Mask | RayMasks.RESOURCE;
            return this;
        }

        public Raymask WithLargeObject()
        {
            Mask = Mask | RayMasks.LARGE;
            return this;
        }

        public Raymask WithMediumObject()
        {
            Mask = Mask | RayMasks.MEDIUM;
            return this;
        }

        public Raymask WithSmallObject()
        {
            Mask = Mask | RayMasks.SMALL;
            return this;
        }

        public Raymask WithNavmesh()
        {
            Mask = Mask | RayMasks.NAVMESH;
            return this;
        }

        public Raymask WithSky()
        {
            Mask = Mask | RayMasks.SKY;
            return this;
        }

        public Raymask WithStructure()
        {
            Mask = Mask | RayMasks.STRUCTURE;
            return this;
        }

        public Raymask WithBarricade()
        {
            Mask = Mask | RayMasks.BARRICADE;
            return this;
        }

        public Raymask WithEntity()
        {
            Mask = Mask | RayMasks.ENTITY;
            return this;
        }

        public Raymask WithEnvironment()
        {
            Mask = Mask | RayMasks.ENVIRONMENT;
            return this;
        }

        public Raymask WithGround()
        {
            Mask = Mask | RayMasks.GROUND;
            return this;
        }

        public Raymask WithGround2()
        {
            Mask = Mask | RayMasks.GROUND2;
            return this;
        }

        public Raymask WithLadder()
        {
            Mask = Mask | RayMasks.LADDER;
            return this;
        }

        public Raymask WithTire()
        {
            Mask = Mask | RayMasks.TIRE;
            return this;
        }

        public Raymask WithTrap()
        {
            Mask = Mask | RayMasks.TRAP;
            return this;
        }
    }
}