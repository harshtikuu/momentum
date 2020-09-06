using Engine.Common;
namespace Extensions
{
    public static class ExtensionMethods
    {
        public static void clear(this Vector v)
        {
            v.x = 0;
            v.y = 0;
            v.z = 0;
        }
    }
}