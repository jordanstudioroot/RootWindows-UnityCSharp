using UnityEngine;

public static class TransformExtensions {
    public static Vector3 Feet(this Transform transform) {
        if (transform.GetComponent<MeshRenderer>()) {
            return (
                transform.position - 
                (transform.up * 
                    (transform.GetComponent<MeshRenderer>().bounds.size.y * .5f)
                )
            );
        }
        else {
            Debug.Log("Method not supported on objects without a mesh renderer. " + 
                "Returning Vector3.negativeInfinity.");
            return Vector3.negativeInfinity;
        }
    }

    public static void StandOn(this Transform myTransform, Vector3 positionToStand) {
        if(myTransform.GetComponent<MeshRenderer>()) {
            float centerDist = Vector3.Distance(myTransform.Feet(), myTransform.position);
            myTransform.position = new Vector3(
                positionToStand.x,
                positionToStand.y + centerDist,
                positionToStand.z
            );
        }
    }
}