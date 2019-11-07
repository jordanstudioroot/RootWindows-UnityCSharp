using UnityEngine;

public class Bezier
{
    public static Vector3 GetQuadradicPoint(Vector3 a, Vector3 b, Vector3 c, float t)
    {
        /* Returns a point cooresponding to some time t on a quadradic bezier curve
            * defined by: 
            *       (1 -t)^2 * a + 2(1 - t) * t * b + t^2 * c
            */

        float r = 1f - t;
        return r * r * a + 2f * r * t * b + t * t * c;
    }

    public static Vector3 GetDerivative
    (
        Vector3 a,
        Vector3 b,
        Vector3 c,
        float t
    )
    {
        return 2f * ((1f - t) * (b - a) + t * (c - b));
    }
}

