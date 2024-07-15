using UnityEngine;
using System.Collections;

public class CameraPermission : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(RequestCameraPermission());
    }

    private IEnumerator RequestCameraPermission()
    {
        // Kiểm tra và yêu cầu quyền truy cập camera
        if (Application.platform == RuntimePlatform.Android)
        {
            if (!Application.HasUserAuthorization(UserAuthorization.WebCam))
            {
                yield return Application.RequestUserAuthorization(UserAuthorization.WebCam);
            }

            // Đợi quyền được cấp
            while (!Application.HasUserAuthorization(UserAuthorization.WebCam))
            {
                yield return null;
            }
        }
    }
}
