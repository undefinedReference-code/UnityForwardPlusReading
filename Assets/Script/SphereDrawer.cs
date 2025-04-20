using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereDrawer
{
    static public void DrawSphere(Vector3 center, float radius, Color color)
    {
        // 保存原始状态
        Matrix4x4 originalMatrix = Gizmos.matrix;
        Color originalColor = Gizmos.color;
    
        // 绘制赤道面圆
        Gizmos.color = color;
        CircleDrawer.DrawCircle(center, Vector3.up, radius, color); 
        CircleDrawer.DrawCircle(center, Vector3.left, radius, color);
        CircleDrawer.DrawCircle(center, Vector3.forward, radius, color);

        // 绘制视角轮廓圆
        if (Camera.current != null )
        {
            Vector3 camDirection = (center - Camera.current.transform.position).normalized;
        }

        // 恢复状态
        Gizmos.matrix = originalMatrix;
        Gizmos.color = originalColor;
    }
    
}
