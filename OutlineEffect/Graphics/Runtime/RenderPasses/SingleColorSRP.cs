using UnityEngine;
using UnityEngine.Rendering;

using static SingleColorEdgeData;

public class SingleColorSRP : UnityEngine.Rendering.Universal.ScriptableRenderPass
{
    private SingleColorEdgeData _data;
    private string _tag = "red";
    private RenderTexture _renderTexture;

    public SingleColorSRP(SingleColorEdgeData data)
    {
        _data = data;
        _renderTexture = new RenderTexture(Screen.width, Screen.height, 16, UnityEngine.Experimental.Rendering.DefaultFormat.LDR);
        _data.OverrideRT = _renderTexture;
    }

    public override void Execute(ScriptableRenderContext context, ref UnityEngine.Rendering.Universal.RenderingData renderingData)
    {
        if (_data.RenderObjectMap.Count > 0)
        {
            renderingData.cameraData.camera.targetTexture = _renderTexture;
            renderingData.cameraData.camera.projectionMatrix = Camera.main.projectionMatrix;
            var cmd = CommandBufferPool.Get(_tag);
            foreach (RenderData renderData in _data.RenderObjectMap.Values)
            {
                for (int i = 0; i < renderData.renderer.materials.Length; ++i)
                {
                    renderData.overrideMat.SetColor("_BaseColor", renderData.color);
                    cmd.DrawRenderer(renderData.renderer, renderData.overrideMat, i);
                }
            }
            cmd.SetRenderTarget(_data.OverrideRT);
            context.ExecuteCommandBuffer(cmd);
            CommandBufferPool.Release(cmd);
        }
    }
}
