using UnityEngine;

public class GlowEffect : MonoBehaviour
{
    public Renderer objRenderer;
    public Color glowColor = Color.yellow;
    public float glowSpeed = 2f;
    private Material mat;
    private float emissionStrength = 0;

    void Start()
    {
        mat = objRenderer.material;
    }

    void Update()
    {
        emissionStrength = Mathf.PingPong(Time.time * glowSpeed, 1);
        mat.SetColor("_EmissionColor", glowColor * emissionStrength);
    }
}