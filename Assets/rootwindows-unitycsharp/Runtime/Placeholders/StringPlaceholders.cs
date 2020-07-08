public static class StringPlaceholders {
    private static string _loremIpsum = "Lorem ipsum dolor sit amet, consectetur " +
        "adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna " +
        "aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris " +
        "nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in " + 
        "reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla " +
        "pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui " +
        "officia deserunt mollit anim id est laborum.";

    public static string LoremIpsum {
        get {
            return _loremIpsum;
        }
    }

    public static string GetLoremIpsumByASCIIByte(int bytes) {
        string result = "";
        int loremIpsumBytes = System.Text.ASCIIEncoding.ASCII.GetByteCount(_loremIpsum);

        for (int i = 0; i < bytes; i++) {
            if (i > loremIpsumBytes) {
                i = 0;
                result += _loremIpsum + "\n";
            }
            if (i == bytes - 1) {
                result += _loremIpsum.Substring(0, bytes);
            }
        }

        return result;
    }

    public static string GetLoremIpsumByWord(int words) {
        string result = "";
        return result;
    }

    public static string GetLoremIpsumByLetter(int letters) {
        string result = GetLoremIpsumByASCIIByte(letters);
        return result;
    }

    public static string GetLoremIpsumAsParagraphs(int paragraphs) {
        string result = "";

        for (int i = 0; i < paragraphs; i++) {
            result += _loremIpsum + "\n";
        }

        return result;
    }
}