using UnityEngine;

public class SingleColorEdgeViewLogic : MonoBehaviour
{
    [SerializeField] private SingleColorEdgeData _renderData;
    [SerializeField] private Renderer _renderer;
    [SerializeField] private Color _color;
    [SerializeField] private Material _overrideMat;

    private Material _matInstance;
    private void OnEnable()
    {
        _matInstance = Instantiate(_overrideMat);
        ChangeColor(_color, this.gameObject.GetInstanceID().ToString());
    }

    private void OnDestroy()
    {
        Destroy(_matInstance);
    }

    public void ChangeColor(Color color, string uniqueId)
    {
        _color = color;
        _renderData.RenderObjectMap[uniqueId] = new SingleColorEdgeData.RenderData
        {
            renderer = _renderer,
            color = _color,
            overrideMat = _matInstance
        };
    }
}
