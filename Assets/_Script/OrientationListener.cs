using UnityEngine;
using UnityEngine.Events;

public class OrientationListener : MonoBehaviour
{
    public UnityEvent onLandscapeLeft;
    public UnityEvent onLandscapeRight;

    private DeviceOrientation lastOrientation;

    void Start()
    {
        lastOrientation = Input.deviceOrientation;
    }

    void Update()
    {
        DeviceOrientation currentOrientation = Input.deviceOrientation;

        if (currentOrientation != lastOrientation)
        {
            lastOrientation = currentOrientation;
            HandleOrientationChange(currentOrientation);
        }
    }

    private void HandleOrientationChange(DeviceOrientation orientation)
    {
        switch (orientation)
        {
            case DeviceOrientation.LandscapeLeft:
                onLandscapeLeft.Invoke();
                break;
            case DeviceOrientation.LandscapeRight:
                onLandscapeRight.Invoke();
                break;
        }
    }
}
