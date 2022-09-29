using UnityEngine;

namespace Utils
{
    public static class CameraExtensions
    {
        public static Bounds CalculateBounds(this Camera camera)
        {
            var center = camera.transform.position;
            var extentsY = camera.orthographicSize;
            var extentsX = extentsY * ((float) camera.pixelWidth / camera.pixelHeight);
            var extents = new Vector2(extentsX, extentsY);
            return new Bounds(center, extents * 2);
        }
    }
}