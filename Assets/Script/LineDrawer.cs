using UnityEngine;

public static class LineDrawer
{
    public static void DrawLine (Vector3 start, Vector3 end, Color color)
    {
        Gizmos.color = color;
        Gizmos.DrawLine(start, end);
    }
    
    public static void DrawLine (Vector3 start, Vector3 dir, float length, Color color)
    {
        dir = dir.normalized;
        var end = start + length * dir;
        DrawLine(start, end, color);
    }
}
