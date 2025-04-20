using UnityEngine;

public static class CircleDrawer
{
    /// <summary>
    /// 在三维空间中绘制圆形
    /// </summary>
    /// <param name="lineRenderer">LineRenderer组件</param>
    /// <param name="center">圆心坐标</param>
    /// <param name="normal">法向量（朝向）</param>
    /// <param name="radius">半径</param>
    /// <param name="segmentCount">顶点数（默认360）</param>
    public static void DrawCircle(Vector3 center, Vector3 normal, float radius, Color color, int segmentCount = 360)
    {
        Gizmos.color = color;
        // 计算旋转四元数：将默认的XY平面旋转到法向量方向
        Quaternion rotation = Quaternion.FromToRotation(Vector3.forward, normal.normalized);
        Vector3[] points = new Vector3[segmentCount];
        // 生成圆上的点坐标
        for (int i = 0; i < segmentCount; i++)
        {
            float angle = i * 360f / segmentCount;
            Vector3 point = GetPointOnCircle(center, radius, angle, rotation);
            points[i] = point;
            if (i > 0)
            {
                Gizmos.DrawLine(points[i], points[i-1]);
            }
        }
        Gizmos.DrawLine(points[0], points[segmentCount-1]);
    }

    // 计算圆上单个点的坐标
    private static Vector3 GetPointOnCircle(Vector3 center, float radius, float angle, Quaternion rotation)
    {
        // 基础平面上的坐标（XY平面）
        float x = radius * Mathf.Cos(angle * Mathf.Deg2Rad);
        float y = radius * Mathf.Sin(angle * Mathf.Deg2Rad);
        Vector3 localPoint = new Vector3(x, y, 0);

        // 应用旋转并返回世界坐标
        return center + rotation * localPoint;
    }
}