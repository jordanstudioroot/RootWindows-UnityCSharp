using System.Diagnostics;

public static class DebugUtils {
    public static StackTrace StackTrace {
        get {
            return new StackTrace();
        }
    }

    public static string StackTraceString {
        get {
            return StackTrace.ToString();
        }
    }

    public static void LogStackTrace() {
        UnityEngine.Debug.Log(StackTraceString);
    }
}