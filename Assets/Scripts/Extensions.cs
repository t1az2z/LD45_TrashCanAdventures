﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Vector3Extensions
{
    public static Vector3 Where (this Vector3 original, float? x = null, float? y = null, float? z = null)
    {
        return new Vector3(x ?? original.x, y ?? original.y, z ?? original.z);
    }
    public static Vector2 Where (this Vector2 original, float? x = null, float? y = null)
    {
        return new Vector2(x ?? original.x, y ?? original.y);
    }

    public static void LookAt2D(this Transform me, Vector2 eye, Vector2 target)
    {
        Vector2 look = target - (Vector2)me.position;

        float angle = Vector2.Angle(eye, look);

        Vector2 right = Vector3.Cross(Vector3.forward, look);

        int dir = 1;

        if (Vector2.Angle(right, eye) < 90)
        {
            dir = -1;
        }

        me.rotation *= Quaternion.AngleAxis(angle * dir, Vector3.forward);
    }

    public static void LookAt2D(this Transform me, Vector2 eye, Transform target)
    {
        me.LookAt2D(eye, target.position);
    }

    public static void LookAt2D(this Transform me, Vector2 eye, GameObject target)
    {
        me.LookAt2D(eye, target.transform.position);
    }

}

