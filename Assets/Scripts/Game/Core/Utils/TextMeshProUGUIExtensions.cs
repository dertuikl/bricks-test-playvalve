using TMPro;
using UnityEngine;

namespace Game.Core.Utils
{
    public static class TextMeshProUGUIExtensions
    {
        public static void SetInvisible(this TextMeshProUGUI text)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, 0);
        }
        
        public static void SetVisible(this TextMeshProUGUI text)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, 1);
        }
    }
}