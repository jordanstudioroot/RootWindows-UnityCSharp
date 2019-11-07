using UnityEngine;

public static class UnityBuiltin {
    public static Font Font (string fontName) {
        return Resources.GetBuiltinResource(typeof(Font), fontName + ".ttf") as Font;
    }
}