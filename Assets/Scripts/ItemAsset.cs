using UnityEngine;

public class ItemAsset : MonoBehaviour
{
    public static ItemAsset Instance {  get; private set; }

    public Sprite circleSprite;
    public Sprite squareSprite;
    public Sprite rectangleSprite;
    public Sprite triangleSprite;


    private void Awake()
    {
        Instance = this;
    }
}
