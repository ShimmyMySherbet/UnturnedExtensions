using System.Linq;
using SDG.Unturned;
using UnityEngine;

namespace ShimmyMySherbet.UnturnedExtensions.Models
{
    public struct Raycast
    {
        public RaycastHit RaycastHit;
        public bool RayHit { get; internal set; }
        public bool HasTransform => RayHit && Transform != null;

        public Raycast(bool hit, RaycastHit m_hit)
        {
            RaycastHit = m_hit;
            RayHit = hit;
        }

        public Transform Transform
        {
            get
            {
                if (!RayHit) return null;
                return RaycastHit.transform;
            }
        }

        private bool m_HasTarget => m_Target != null;

        private Transform m_Target
        {
            get
            {
                if (!RayHit || RaycastHit.collider == null || RaycastHit.collider.transform == null) return null;
                return RaycastHit.collider.transform;
            }
        }

        public bool HasVehicle => Vehicle != null;

        public InteractableVehicle Vehicle => GetComponent<InteractableVehicle>();

        public bool HasBarricade
        {
            get
            {
                if (!m_HasTarget) return false;
                return m_Target.CompareTag("Barricade");
            }
        }

        public bool HasStructure
        {
            get
            {
                if (!m_HasTarget) return false;
                return m_Target.CompareTag("Structure");
            }
        }

        public bool TryGetBarricade(out BarricadeInfo barricade)
        {
            barricade = BarricadeInfo.Nil;
            if (HasBarricade)
            {
                var target = DamageTool.getBarricadeRootTransform(m_Target);
                if (BarricadeManager.tryGetInfo(target, out byte x, out byte y, out ushort plant, out ushort index, out BarricadeRegion Region, out BarricadeDrop Drop))
                {
                    BarricadeData B = Region.barricades.FirstOrDefault(D => D.instanceID == Drop.instanceID);
                    if (B != null)
                    {
                        barricade = new BarricadeInfo(Region, B, Drop, target, x, y, index, plant);
                        return true;
                    }
                }
                return false;
            }
            else
            {
                return false;
            }
        }

        public bool TryGetStructure(out StructureInfo structure)
        {
            structure = StructureInfo.Nil;
            if (HasStructure)
            {
                var target = DamageTool.getStructureRootTransform(m_Target);
                if (StructureManager.tryGetInfo(target, out byte x, out byte y, out ushort index, out StructureRegion Region))
                {
                    StructureData B = Region.structures[index];
                    StructureDrop drop = Region.drops[index];

                    if (B != null)
                    {
                        structure = new StructureInfo(Region, B, drop, target, x, y, index);
                        return true;
                    }
                }
                return false;
            }
            else
            {
                return false;
            }
        }

        public Player Player => GetComponent<Player>();
        public bool HasPlayer => Player != null;

        public Animal Animal => GetComponent<Animal>();
        public bool HasAnimal => Animal != null;

        public Zombie Zombie => GetComponent<Zombie>();
        public bool HasZombie => Zombie != null;

        public bool HasResource => TryGetResource(out _);

        public bool TryGetResource(out ResourceInfo resource)
        {
            resource = ResourceInfo.Nil;
            if (ResourceManager.tryGetRegion(m_Target, out byte x, out byte y, out ushort index))
            {
                var sp = ResourceManager.getResourceSpawnpoint(x, y, index);

                resource = new ResourceInfo(m_Target, sp, x, y, index);
                return true;
            }
            return false;
        }

        public T GetComponent<T>()
        {
            if (RayHit)
            {
                return Transform.GetComponentInParent<T>();
            }
            else
            {
                return default(T);
            }
        }

        public bool HasComponent<T>()
        {
            if (RayHit)
            {
                return GetComponent<T>() != null;
            }
            else
            {
                return false;
            }
        }
    }
}