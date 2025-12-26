using UnityEngine;

public class ItemAsset : MonoBehaviour
{
    public static ItemAsset Instance {  get; private set; }
    [SerializeField] private Sprite circleSprite;
    [SerializeField] private Sprite rectangleSprite;
    [SerializeField] private Sprite squareSprite;
    [SerializeField] private Sprite triangleSprite;

    [SerializeField] private Transform ItemWorldPrefab;

    private void Awake()
    {
        Instance = this;
    }

    public Sprite GetCircleSprite()
    {
        return circleSprite;
    }
    public Sprite GetSquareSprite()
    {
        return squareSprite;
    }
    public Sprite GetRectangleSprite()
    {
        return rectangleSprite;
    }
    public Sprite GetTriangleSprite()
    {
        return triangleSprite;
    }
    public Transform GetItemWorldPrefab()
    {
        return ItemWorldPrefab;
    }
}
