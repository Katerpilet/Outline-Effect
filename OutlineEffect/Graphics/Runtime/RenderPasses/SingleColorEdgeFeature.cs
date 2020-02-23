using UnityEngine;

public class SingleColorEdgeFeature : UnityEngine.Rendering.Universal.ScriptableRendererFeature
{
    [SerializeField] private SingleColorEdgeData _singleColorEdgeData;

    private SingleColorSRP _singleColorSRP;

    public override void AddRenderPasses(UnityEngine.Rendering.Universal.ScriptableRenderer renderer, ref UnityEngine.Rendering.Universal.RenderingData renderingData)
    {
        renderer.EnqueuePass(_singleColorSRP);
    }

    public override void Create()
    {
        _singleColorSRP = new SingleColorSRP(_singleColorEdgeData);
    }
}
