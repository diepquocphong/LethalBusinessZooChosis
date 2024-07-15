using UnityEngine;

public class CameraResolutionScaler : MonoBehaviour
{
    // FPS mục tiêu
    public int targetFPS = 60;

    // Tỷ lệ nhỏ nhất và lớn nhất
    public float minScaleFactor = 0.5f;
    public float maxScaleFactor = 1f;

    // Tốc độ thay đổi của tỷ lệ
    public float scaleFactorChangeRate = 0.1f;

    // Độ phân giải tham chiếu
    public Vector2 referenceResolution = new Vector2(1920, 1080);

    // Camera cần thay đổi độ phân giải
    public Camera targetCamera;

    private float currentScaleFactor = 1f;
    private RenderTexture renderTexture;

    void Start()
    {
        // Đặt FPS mục tiêu
        Application.targetFrameRate = targetFPS;
        // Tạo RenderTexture ban đầu
        UpdateRenderTexture();
    }

    void Update()
    {
        // Tính toán tải GPU hiện tại
        float gpuLoad = Mathf.Clamp01((float)SystemInfo.graphicsMemorySize / SystemInfo.graphicsMemorySize);

        // Tính toán tỷ lệ mong muốn dựa trên tải GPU
        float desiredScaleFactor = Mathf.Lerp(minScaleFactor, maxScaleFactor, gpuLoad);

        // Điều chỉnh mịn tỷ lệ hiện tại đến tỷ lệ mong muốn
        currentScaleFactor = Mathf.Lerp(currentScaleFactor, desiredScaleFactor, scaleFactorChangeRate * Time.deltaTime);

        // Tính toán độ phân giải được thu nhỏ
        int newWidth = Mathf.RoundToInt(referenceResolution.x * currentScaleFactor);
        int newHeight = Mathf.RoundToInt(referenceResolution.y * currentScaleFactor);

        // Cập nhật RenderTexture nếu cần
        if (renderTexture.width != newWidth || renderTexture.height != newHeight)
        {
            UpdateRenderTexture(newWidth, newHeight);
        }
    }

    void UpdateRenderTexture(int width = 0, int height = 0)
    {
        // Nếu không cung cấp width và height, sử dụng độ phân giải tham chiếu
        if (width == 0 || height == 0)
        {
            width = (int)referenceResolution.x;
            height = (int)referenceResolution.y;
        }

        // Tạo RenderTexture mới với kích thước được cập nhật
        if (renderTexture != null)
        {
            renderTexture.Release();
        }
        renderTexture = new RenderTexture(width, height, 24);
        targetCamera.targetTexture = renderTexture;
    }

    void OnDestroy()
    {
        // Giải phóng RenderTexture khi script bị hủy
        if (renderTexture != null)
        {
            renderTexture.Release();
        }
    }
}
