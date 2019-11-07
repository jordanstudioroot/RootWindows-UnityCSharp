using UnityEngine;
using System.Collections.Generic;

public static class AppWindowMetrics {
    // FIELDS ~~~~~~~~~~
    
    // ~ Static
    
    // ~~ public
    
    /// <summary>
    /// A Dictionary of Vector2 values representing different reference points for
    /// the screen.
    /// </summary>
    /// <typeparam name="CardinalPositions">An enum type representing a reference 
    ///     points on the screen.</typeparam>
    /// <typeparam name="Vector2">A Vector2 value representing a reference point on 
    ///     the screen.</typeparam>
    /// <returns></returns>
    public static readonly Dictionary<CardinalDirections, Vector2> CardinalPoints = 
        new Dictionary<CardinalDirections, Vector2>() {
            {CardinalDirections.North, NorthAppWindowCenter},
            {CardinalDirections.Northeast, NortheastAppWindowCorner},
            {CardinalDirections.East, EastAppWindowCenter},
            {CardinalDirections.Southeast, SoutheastAppWindowCorner},
            {CardinalDirections.South, SouthAppWindowCenter},
            {CardinalDirections.Southwest, SouthwestAppWindowCorner},
            {CardinalDirections.West, WestAppWindowCenter},
            {CardinalDirections.Northwest, NorthwestAppWindowCorner},
            {CardinalDirections.Center, AppWindowCenter}
        };

    /// <summary>
    /// An Array of Vector2 values representing different view sizes with respect to 
    ///     the current screen size.
    /// </summary>
    public static readonly Vector2[] ViewDimensions = {
        EighthAppWindowSquare,
        EightAppWindowPortrait,
        EighthAppWindowLandscape,
        FourthAppWindowSquare,
        ForuthAppWindowPortrait,
        FourthAppWindowLandscape,
        HalfAppWindowSquare,
        HalfAppWindowPortrait,
        HalfAppWindowLandscape,
        FullAppWindow
    };

    // ~~ private
    
    // ~ Non-Static
    
    // ~~ public
    
    // ~~ private
    
    // CONSTRUCTORS ~~~~~~~~~~
    
    // ~ Static
    
    // ~~ public
    
    // ~~ private
    
    // ~ Non-Static
    
    // ~~ public
    
    // ~~ private
    
    // DESTRUCTORS ~~~~~~~~~~
    
    // ~ Static
    
    // ~~ public
    
    // ~~ private
    
    // ~ Non-Static
    
    // ~~ public
    
    // ~~ private
    
    // DELEGATES ~~~~~~~~~~
    
    // ~ Static
    
    // ~~ public
    
    // ~~ private
    
    // ~ Non-Static
    
    // ~~ public
    
    // ~~ private
    
    // EVENTS ~~~~~~~~~~~~~
    
    // ~ Static
    
    // ~~ public
    
    // ~~ private
    
    // ~ Non-Static
    
    // ~~ public
    
    // ~~ private
    
    // ENUMS ~~~~~~~~~~~~~~~
    
    // ~ Static
    
    // ~~ public
    
    // ~~ private
    
    // ~ Non-Static
    
    // ~~ public
    
    // ~~ private
    
    // INTERFACES ~~~~~~~~~~
    
    // ~ Static
    
    // ~~ public
    
    // ~~ private
    
    // ~ Non-Static
    
    // ~~ public
    
    // ~~ private
    
    // PROPERTIES ~~~~~~~~~~
    
    // ~ Static
    
    // ~~ public

    /// <summary>
    /// A Vector2 reperesenting a point at the very center of the screen.
    /// </summary>
    /// <value></value>
    public static Vector2 AppWindowCenter {
        get {
            return new Vector2(Screen.width * .5f, Screen.height * .5f);
        }
    }

    /// <summary>
    /// A Vector2 representing a point at the center of the north side
    /// of the screen.
    /// </summary>
    public static Vector2 NorthAppWindowCenter {
       get {
        return new Vector2(Screen.width * .5f, Screen.height);
       }
    }

    /// <summary>
    /// A Vector2 representing a point at the northeast corner of the
    /// screen.
    /// </summary>
    /// <value></value>
    public static Vector2 NortheastAppWindowCorner {
        get {
            return new Vector2(Screen.width, Screen.height);
        }
    }

    /// <summary>
    /// A Vector2 representing a point at the center of the east side
    /// of the screen.
    /// </summary>
    public static Vector2 EastAppWindowCenter {
       get {
           return new Vector2(Screen.width, Screen.height * .5f);
       }
    }

    /// <summary>
    /// A Vector2 representing a point at the southwest corner of the screen.
    /// </summary>
    /// <value></value>
    public static Vector2 SoutheastAppWindowCorner {
        get {
            return new Vector2(Screen.width, 0f);
        }
    }

    /// <summary>
    /// A Vector2 representing a point at the center of the south side of
    /// the screen.
    /// </summary>
    /// <value></value>
    public static Vector2 SouthAppWindowCenter {
       get {
           return new Vector2(Screen.width * .5f, 0f);
       }
    }

    /// <summary>
    /// A Vector2 representing a point at the southwest corner of the screen.
    /// </summary>
    public static Vector2 SouthwestAppWindowCorner {
        get {
            return new Vector2(0f, 0f);
        }
    }

    /// <summary>
    /// A Vector2 representing a point at the center of the west side of the
    /// screen.
    /// </summary>
    public static Vector2 WestAppWindowCenter {
        get {
            return new Vector2(0f, Screen.height * .5f);
        }
    }

    /// <summary>
    /// A Vector2 representing a point at the northwest corner of the screen.
    /// </summary>
    public static Vector2 NorthwestAppWindowCorner {
        get {
            return new Vector2(0f, Screen.height);
        }
    }

    /// <summary>
    /// A Vector2 representing the full dimensions of the application window.
    /// </summary>
    public static Vector2 FullAppWindow {
        get {
            return new Vector2(Screen.width, Screen.height);
        }
    }

    /// <summary>
    /// A Vector2 representing a square-shaped area of the screen with an area
    /// equalling one half of the screen.
    /// </summary>
    public static Vector2 HalfAppWindowSquare {
        get {
            return GetMaxScreenPercentageSquare(.5f);
        }
    }

    /// <summary>
    /// A Vector2 representing a portrait-shaped area of the screen with an area
    /// equaling one half of the screen.
    /// </summary>
    public static Vector2 HalfAppWindowPortrait {
        get {
            return new Vector2(Screen.width * .5f, Screen.height);
        }
    }

    /// <summary>
    /// A Vector2 representing a landscape-shaped area of the screen with an area
    /// equaling one half of the screen.
    /// </summary>
    public static Vector2 HalfAppWindowLandscape {
        get {
            return new Vector2(Screen.width, Screen.height * .5f);
        }
    }

    /// <summary>
    /// A Vector2 representing a square-shaped area of the screen with an area
    /// equaling one fourth of the screen.
    /// </summary>
    public static Vector2 FourthAppWindowSquare {
        get {            
            return GetMaxScreenPercentageSquare(.25f);
        }
    }

    /// <summary>
    /// A Vector2 representing a portait-shaped area of the screen with an area
    /// equaling one fourth of the screen.
    /// </summary>
    public static Vector2 ForuthAppWindowPortrait {
        get {
            return new Vector2(Screen.width * .125f, Screen.height * .25f);
        }
    }

    /// <summary>
    /// A Vector2 representing a landscape-shaped area of the screen with an area
    /// equaling one fourth of the screen.
    /// </summary>.
    public static Vector2 FourthAppWindowLandscape {
        get {
            return new Vector2(Screen.width * .25f, Screen.height * .125f);
        }
    }

    /// <summary>
    /// A Vector2 representing a square-shaped area of the screen with an area
    /// equaling one eighth of the screen.
    /// </summary>
    public static Vector2 EighthAppWindowSquare {
        get {
            return GetMaxScreenPercentageSquare(.125f);
        }
    }

    /// <summary>
    /// A Vector2 representing a portrait-shaped area of the screen with an area
    /// equaling one eighth of the screen.
    /// </summary>
    public static Vector2 EightAppWindowPortrait {
        get {
            return new Vector2(Screen.width * .03125f, Screen.height * .0625f);
        }
    }

    /// <summary>
    /// A Vector2 representing a landscape-shaped area of the screen with an area
    /// equaling one eighth of the screen.
    /// </summary>
    public static Vector2 EighthAppWindowLandscape {
        get {
            return new Vector2(Screen.width * .0625f, Screen.height * .03125f);
        }
    }

    public static CardinalDirections ClosestCardinalPoint(Vector2 point) {
        float leastDist = 0f;
        CardinalDirections result = CardinalDirections.Center;

        foreach (KeyValuePair<CardinalDirections, Vector2> pair in CardinalPoints) {

            float currDist = Vector2.Distance(point, pair.Value);

            if (currDist < leastDist) {
                leastDist = currDist;
                result = pair.Key; 
            }
        }        

        return result;
    }

    public static Vector2 BarSmall =
        new Vector2(FullAppWindow.x / 4f, FullAppWindow.y / 8f);

    public static Vector2 BarMedium =
        new Vector2(FullAppWindow.x / 3f, FullAppWindow.y / 8f);

    public static Vector2 BarLarge =
        new Vector2(FullAppWindow.x / 2f, FullAppWindow.y / 8f);

    public static Vector2 BarMax = 
        new Vector2(FullAppWindow.x, FullAppWindow.y / 8f);
    public static Dictionary<ViewSizes, Vector2> BarSizes =
        new Dictionary<ViewSizes, Vector2> {
            {ViewSizes.Small, BarSmall},
            {ViewSizes.Medium, BarMedium},
            {ViewSizes.Large, BarLarge},
            {ViewSizes.Maximum, BarMax}
        };

    // ~~ private
    
    // ~ Non-Static
    
    // ~~ public
    
    // ~~ private
    
    // INDEXERS ~~~~~~~~~~
    
    // ~ Static
    
    // ~~ public
    
    // ~~ private
    
    // ~ Non-Static
    
    // ~~ public
    
    // ~~ private
    
    // METHODS ~~~~~~~~~
    
    // ~ Static
    
    // ~~ public

    // ~~ private

    /// <summary>
    /// Returns a Vector2 representing the maximum allowable squared area
    /// given the requested percentage of the screen.
    /// </summary>
    /// <param name="percentageOfScreen">
    /// The percentage of the screen that the Vector2 should fill. This
    /// percentage will be taken from the width or the height, depending
    /// on which is larger.
    /// </param>
    /// <returns>
    /// A Vector2 representing a filled square percentage of the screen.
    /// May be a percentage of the width or height, depending on which
    /// is larger, and whether or not the percentage of the larger dimension
    /// results in a Vector2 which is larger than one of the dimensions.
    /// If the percentage results in dimensions which are larger than either
    /// of the screen dimensions, then this method returns a Vector2 which
    /// has width and height equal to whichever screen dimension is smaller.
    /// </returns>
    private static Vector2 GetMaxScreenPercentageSquare(float percentageOfScreen) {
            
            percentageOfScreen = Mathf.Clamp(percentageOfScreen, 0f, 1f);

            float adjustedHeight = Screen.height * percentageOfScreen;
            float adjustedWidth = Screen.width * percentageOfScreen;

//          If the adjusted width is larger than the adjusted height.
            if (adjustedWidth > adjustedHeight) {
//              If the adjusted width fits the height of the screen.
                if (adjustedWidth < Screen.height) {
                    return new Vector2(adjustedWidth, adjustedWidth);
                }
//              Else use the height of the screen, since this is the maximum square
//              size that will fit.
                else {
                    return new Vector2(Screen.height, Screen.height);
                }
            }
//          If the adjusted height is larger than the adjusted width.
            else {
//              If the adjusted height fits the width of the screen.
                if (adjustedHeight < Screen.width) {
                    return new Vector2(adjustedHeight, adjustedHeight);
                }
//              Else use the width of the screen, since this is the maximum square 
//              size that will fit.
                else {
                    return new Vector2(Screen.width, Screen.width);
                }
            }
    }

    private static Vector2 GetMaxScreenPercentagePortrait(float percentageOfScreen) {
//      Stub
        return Vector2.negativeInfinity;
    }

    private static Vector2 GetMaxScreenPercentageLandscape(float percentageOfScreen) {
//      Stub
        return Vector2.negativeInfinity;
    }
 
    // ~ Non-Static
    
    // ~~ public
    
    // ~~ private

    // STRUCTS ~~~~~~~~~~
    
    // ~ Static
    
    // ~~ public
    
    // ~~ private
    
    // ~ Non-Static
    
    // ~~ public
    
    // ~~ private
    
    // CLASSES ~~~~~~~~~~
    
    // ~ Static
    
    // ~~ public
    
    // ~~ private
    
    // ~ Non-Static
    
    // ~~ public
    
    // ~~ private
}