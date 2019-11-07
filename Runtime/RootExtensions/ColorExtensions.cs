using UnityEngine;
public static class ColorExtensions {
    public static void Invert(this Color color) {
        color.r = 1f - color.r;
        color.g = 1f - color.g;
        color.b = 1f - color.b;
    }

    public static Color GetInvertedColor(this Color color) {
        return new Color(1f - color.r, 1f - color.g, 1f - color.b);
    }

    /// <summary>
    /// Lerps the color [intensity] percent toward Color.white.
    /// </summary>
    /// <param name="color">Extension method subject.</param>
    /// <param name="intensity">Percentage to lerp toward Color.white.</param>
    public static void Highlight(this Color color, float intensity) {
        color = Color.Lerp(color, Color.white, intensity);
        Debug.Log(color);
    }

    public static Color GetHighlightedColor(this Color color, float intensity) {
        return Color.Lerp(color, Color.white, intensity);
    }
}