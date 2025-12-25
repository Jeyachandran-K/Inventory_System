using UnityEngine;

public class ItemAsset : MonoBehaviour
{
    public static ItemAsset Instance {  get; private set; }
    [SerializeField] private Sprite circleSprite;
    [SerializeField] private Sprite rectangleSprite;
    [SerializeField] private Sprite squareSprite;

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
}
