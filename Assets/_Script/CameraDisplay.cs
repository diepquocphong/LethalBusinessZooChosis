using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CameraDisplay : MonoBehaviour
{
    public RawImage rawImage;
    public AspectRatioFitter aspectRatioFitter;

    private WebCamTexture webCamTexture;

    void Start()
    {
        StartCoroutine(StartCamera());
    }

    private IEnumerator StartCamera()
    {
        // Kiểm tra quyền truy cập camera
        if (Application.platform == RuntimePlatform.Android)
        {
            if (!Application.HasUserAuthorization(UserAuthorization.WebCam))
            {
                yield return Application.RequestUserAuthorization(UserAuthorization.WebCam);
            }
        }

        // Đợi cho đến khi quyền được cấp
        yield return new WaitForSeconds(1);

        // Lấy danh sách các thiết bị camera có sẵn
        WebCamDevice[] devices = WebCamTexture.devices;
        WebCamDevice? frontCamera = null;

        // Tìm camera trước
        foreach (var device in devices)
        {
            if (device.isFrontFacing)
            {
                frontCamera = device;
                break;
            }
        }

        if (frontCamera.HasValue)
        {
            // Khởi tạo WebCamTexture với camera trước
            webCamTexture = new WebCamTexture(frontCamera.Value.name);

            // Bắt đầu chạy camera
            webCamTexture.Play();

            // Gán texture của camera cho RawImage
            rawImage.texture = webCamTexture;

            // Điều chỉnh tỉ lệ hình ảnh cho phù hợp
            aspectRatioFitter.aspectRatio = (float)webCamTexture.width / (float)webCamTexture.height;
        }
        else
        {
            Debug.LogWarning("No front camera detected!");
        }
    }

    public void StopCamera()
    {
        if (webCamTexture != null && webCamTexture.isPlaying)
        {
            webCamTexture.Stop();
        }
    }

    // Phương thức khởi động lại camera
    public void PlayCamera()
    {
        if (webCamTexture != null && !webCamTexture.isPlaying)
        {
            webCamTexture.Play();
        }
    }
}
