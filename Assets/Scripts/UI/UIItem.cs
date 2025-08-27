using UnityEngine;
using UnityEngine.UI;

public class UIItem : MonoBehaviour
{
    [SerializeField] Image ItemIcon;

    public void SetSprite(string atlasName , string spriteName)
    {
        ItemIcon.SetImageFromAtlas(atlasName, spriteName);
    }
}
