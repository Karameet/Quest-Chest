using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public static class SpriteSetter 
{
   public static void SetImageFromAtlas(this Image image, string atlasName, string spriteName)
   {
        if(string.IsNullOrEmpty(atlasName) || string.IsNullOrEmpty(spriteName)) return;

        SpriteAtlas atlas = Resources.Load<SpriteAtlas>(atlasName);

        if(atlas == null)
        {
            Debug.LogError($"Atlas '{atlasName}' not found in Resources.");
            return;
        }

        Sprite sprite = atlas.GetSprite(spriteName);

        if (sprite == null)
        {
            Debug.LogError($"Sprite '{spriteName}' not found in atlas '{atlasName}'.");
            return;
        }

        image.sprite = sprite;
   }
}
