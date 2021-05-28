using UnityEngine;

namespace Rift
{
    static class Vector2Extensions
    {
        public static Vector3 ToVector3(this Vector2 v) => new Vector3(v.x, v.y, 0);

        public static Vector3 ToVector3XZ(this Vector2 v) => new Vector3(v.x, 0, v.y);
    }
}
