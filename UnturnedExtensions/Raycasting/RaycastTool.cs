using SDG.Unturned;
using ShimmyMySherbet.UnturnedExtensions.Models;
using UnityEngine;

namespace ShimmyMySherbet.UnturnedExtensions.Raycasting
{
    public static class RaycastTool
    {
        public static Raycast RaycastPlayer(Player player, ERaycastDirection direction, float maxDistance, Raymask raymask = null)
        {
            Vector3 dir = RaycastDirectionTransformer.GetDirection(direction);
            return RaycastPlayer(player, dir, maxDistance, raymask);
        }

        public static Raycast RaycastPlayerLook(Player player, ERaycastDirection direction, float maxDistance, Raymask raymask = null)
        {
            Vector3 dir = RaycastDirectionTransformer.GetDirection(direction, player);
            return RaycastPlayer(player, dir, maxDistance, raymask);
        }

        public static Raycast RaycastTransform(Transform transform, ERaycastDirection direction, float maxDistance, Raymask raymask = null)
        {
            Vector3 dir = RaycastDirectionTransformer.GetDirection(direction, transform);
            Vector3 origin = transform.position + (dir * 0.5f);
            return Raycast(origin, dir, maxDistance, raymask);
        }

        public static Raycast RaycastPlayer(Player player, Vector3 direction, float maxDistance, Raymask raymask = null)
        {
            Vector3 origin = player.transform.position + (direction * 0.5f);
            return Raycast(origin, direction, maxDistance, raymask);
        }

        public static Raycast Raycast(Vector3 origin, Vector3 direction, float maxDistance, Raymask raymask = null)
        {
            if (raymask == null) raymask = Raymask.All;
            if (Physics.Raycast(origin, direction, out RaycastHit hit, maxDistance, raymask.Mask, QueryTriggerInteraction.Collide))
            {
                return new Raycast(true, hit);
            }
            else
            {
                return new Raycast(false, hit);
            }
        }
    }
}