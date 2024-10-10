using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    private Light directionalLight;
    public float intensity = 5.0f;
    public Color lightColor = Color.white;
    public bool enableShadows = true;

    // Start is called before the first frame update
    void Start()
    {
        directionalLight = GetComponent<Light>();

        if (directionalLight.type != LightType.Directional) ;

        { 
            Debug.LogError("Script For Directional Light");
            return;
        }
        UpdateLightProperties();
    }
    void UpdateLightProperties ()

    {
        directionalLight.intensity = intensity;
        directionalLight.color = lightColor;

        if (enableShadows)

        {
            directionalLight.shadows = LightShadows.None; 
        }

    }


    // Update is called once per frame
    void Update()
    {
        UpdateLightProperties(); 
    }

}
