using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The component that manages all the camera's movements.
/// </summary>
public class CameraComponent : MonoBehaviour
{

    /// <summary>
    /// The target that the camera should follow
    /// </summary>
    public Transform followTarget;

    /// <summary>
    /// The limits of the world that the camera must not cross
    /// </summary>
    public SpriteRenderer cameraBounds;

    /// <summary>
    /// the reference of the camera on the scene
    /// </summary>
    private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (followTarget)
            transform.position = followTarget.transform.position;

        ClampToBounds();
    }

    /// <summary>
    /// The function that clamps the position of the parraport camera to a limit
    /// </summary>
    private void ClampToBounds()
    {
        if (cameraBounds)
        {
            // clamp to container bounds
            var vertExtent = cam.orthographicSize;
            var horzExtent = vertExtent * Screen.width / Screen.height;
            var pos = cam.transform.position;

            pos.z = -10;
            cam.transform.position = pos;
            pos = cam.transform.position;

            var containerMin = cameraBounds.bounds.min;
            var containerMax = cameraBounds.bounds.max;
            float dx = 0, dy = 0;

            // compute camera bounds
            var camMin = pos;
            camMin.x -= horzExtent;
            camMin.y -= vertExtent;

            var camMax = pos;
            camMax.x += horzExtent;
            camMax.y += vertExtent;

            // clamp horizontically
            if (camMin.x < containerMin.x)
            {
                dx = containerMin.x - camMin.x;
            }
            if (camMax.x > containerMax.x)
            {
                dx = containerMax.x - camMax.x;
            }

            // clamp vertically
            if (camMin.y < containerMin.y)
            {
                dy = containerMin.y - camMin.y;
            }
            if (camMax.y > containerMax.y)
            {
                dy = containerMax.y - camMax.y;
            }

            cam.transform.Translate(dx, dy, 0);
        }
    }

}
