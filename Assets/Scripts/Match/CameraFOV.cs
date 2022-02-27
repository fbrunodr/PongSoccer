using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ConstantsNamespace;

public class CameraFOV : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Camera camera = GameObject.Find("Main Camera").GetComponent<Camera>();

        GameObject field = GameObject.Find("Field");
        float fieldWidth = 10 * field.transform.localScale.x;
        float fieldLength = 10 * field.transform.localScale.z;
        float fieldHeight = field.transform.position.y;

        float cameraHeight = this.transform.position.y;
        float height = cameraHeight - fieldHeight;
        float minFOVhorizontal = 2.0F * Mathf.Rad2Deg * Mathf.Atan2(fieldWidth/2, height);
        float minFOVverticalFromHorizontal = Camera.HorizontalToVerticalFieldOfView(minFOVhorizontal, camera.aspect);
        float cameraDisplacement = camera.transform.position.z;
        float minFOVvertical = 2.0F * Mathf.Rad2Deg * Mathf.Atan2(fieldLength/2 + cameraDisplacement, height);

        float trueMinFOVvertical = Mathf.Max(minFOVverticalFromHorizontal, minFOVvertical);

        // the multiplier is used to make the camera look a bit better
        float fovMultiplier = 1.025F;
        camera.fieldOfView = fovMultiplier * trueMinFOVvertical;
    }
}
