using UnityEngine;

public class LightingSettings : MonoBehaviour
{
    [Header("Skybox Settings")]
    public Material skyboxMaterial;

    [Header("Directional Light Settings")]
    public Color directionalLightColor = Color.white;
    public Light directionalLight;

    [Header("Environment Lighting Settings")]
    public Color skyColor = Color.gray;
    public Color equatorColor = Color.gray;
    public Color groundColor = Color.gray;

    [Header("Fog Settings")]
    public bool enableFog = false;
    public Color fogColor = Color.gray;
    public FogMode fogMode = FogMode.Linear;
    public float fogDensity = 0.01f;
    public float fogStartDistance = 0.0f;
    public float fogEndDistance = 300.0f;

  

  
    public void ApplyLightingSettings()
    {
        // Set the skybox
        if (skyboxMaterial != null)
        {
            RenderSettings.skybox = skyboxMaterial;
        }

        // Set the directional light color
        if (directionalLight != null)
        {
            directionalLight.color = directionalLightColor;
        }

        // Set the environment lighting
        RenderSettings.ambientSkyColor = skyColor;
        RenderSettings.ambientEquatorColor = equatorColor;
        RenderSettings.ambientGroundColor = groundColor;

        // Set the fog settings
        RenderSettings.fog = enableFog;
        if (enableFog)
        {
            RenderSettings.fogColor = fogColor;
            RenderSettings.fogMode = fogMode;
            RenderSettings.fogDensity = fogDensity;
            RenderSettings.fogStartDistance = fogStartDistance;
            RenderSettings.fogEndDistance = fogEndDistance;
        }
    }
}
