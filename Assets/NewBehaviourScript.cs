using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;
public class Example : MonoBehaviour
{
    void Start()
    {

    }

    private void OnDrawGizmos()
    {
        Vector3 lightPositionVS = new Vector3(2, 3, 4);
        float range = 10;
        SphereDrawer.DrawSphere(lightPositionVS, range, Color.red);
        float spotAngle = 85;
        var halfAngle = math.radians(spotAngle * 0.5f);
        Vector3 lightDirVS = new Vector3(23, 45, 21).normalized;
        LineDrawer.DrawLine(lightPositionVS, lightDirVS, range, Color.white);
        
        // draw big circle of light, not in forward code
        Vector3 normal = Vector3.Cross(lightDirVS, Vector3.up);
        CircleDrawer.DrawCircle(lightPositionVS, normal, range, Color.magenta);
        
        var cosHalfAngle = math.cos(halfAngle);
        var coneHeight = cosHalfAngle * range;
        var circleCenter = lightPositionVS + lightDirVS * coneHeight;
        var circleRadius = math.sqrt(range * range - coneHeight * coneHeight);
        CircleDrawer.DrawCircle(circleCenter, lightDirVS, circleRadius, Color.blue);
        
        
        var circleUp = (Vector3.up - lightDirVS * lightDirVS.y).normalized;
        var circleRight = (Vector3.right - lightDirVS * lightDirVS.x).normalized;
        var circleBoundY0 = circleCenter - circleUp * circleRadius;
        var circleBoundY1 = circleCenter + circleUp * circleRadius;
        var circleBoundX0 = circleCenter - circleRight * circleRadius;
        var circleBoundX1 = circleCenter + circleRight * circleRadius;
        float maxX = circleBoundX1.x;
        float minX = circleBoundX0.x;
        float minY = circleBoundY0.y;
        float maxY = circleBoundY1.y;
        LineDrawer.DrawLine(new Vector3(maxX, minY), new Vector3(minX, minY) , Color.green);
        LineDrawer.DrawLine(new Vector3(maxX, maxY), new Vector3(minX, maxY) , Color.green);
        LineDrawer.DrawLine(new Vector3(maxX, minY), new Vector3(maxX, maxY) , Color.green);
        LineDrawer.DrawLine(new Vector3(minX, minY), new Vector3(minX, maxY) , Color.green);
    }
}