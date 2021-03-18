using SDG.Unturned;
using ShimmyMySherbet.UnturnedExtensions.Models;
using UnityEngine;

namespace ShimmyMySherbet.UnturnedExtensions.Raycasting
{
    public static class RaycastDirectionTransformer
    {
        public static Vector3 GetDirection(ERaycastDirection direction)
        {
            switch (direction)
            {
                case ERaycastDirection.Backward:
                    return Vector3.back;

                case ERaycastDirection.Down:
                    return Vector3.down;

                case ERaycastDirection.Forward:
                    return Vector3.forward;

                case ERaycastDirection.Left:
                    return Vector3.left;

                case ERaycastDirection.Right:
                    return Vector3.right;

                case ERaycastDirection.Up:
                    return Vector3.up;

                default:
                    return Vector3.zero;
            }
        }

        public static Vector3 GetDirection(ERaycastDirection direction, Player player)
        {
            return GetDirection(direction, player.look.aim);
        }

        public static Vector3 GetDirection(ERaycastDirection direction, Transform origin)
        {
            switch (direction)
            {
                case ERaycastDirection.Backward:
                    return origin.forward * -1f;

                case ERaycastDirection.Down:
                    return origin.up * -1f;

                case ERaycastDirection.Forward:
                    return origin.forward;

                case ERaycastDirection.Left:
                    return origin.right * -1f;

                case ERaycastDirection.Right:
                    return origin.right;

                case ERaycastDirection.Up:
                    return origin.up;

                default:
                    return new Vector3(0, 0, 0);
            }
        }
    }
}