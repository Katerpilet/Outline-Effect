using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Settings/" + nameof(SingleColorEdgeData))]
public class SingleColorEdgeData : ScriptableObject
{
    [System.Serializable]
    public struct RenderData
    {
        public Renderer renderer;
        public Color color;
        public Material overrideMat;
    }

    [NonSerialized] public Dictionary<string, RenderData> RenderObjectMap = new Dictionary<string, RenderData>();

    public Material OverrideMat;
    [NonSerialized] public RenderTexture OverrideRT;

    public void OnDisable()
    {
        RenderObjectMap.Clear();
    }
}
