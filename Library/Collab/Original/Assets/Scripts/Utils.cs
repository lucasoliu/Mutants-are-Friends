using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils {

    public static int tileWidth = 1;
    public static string playerLayer = "PlayerLayer";
    public static string tileLayer = "TileLayer";
    public static List<string> itemTags = new List<string>() { "DNA", "Device", "Key" };

    public static Vector3 indexToVector(int x, int y, string layer)
    {
        if (layer == playerLayer) {
            return new Vector3(x * tileWidth, y * tileWidth, -1f);
        } else if (layer == tileLayer) {
            return new Vector3(x * tileWidth, y * tileWidth, 0f);
        } else {
            return new Vector3(x * tileWidth, y * tileWidth, 0f);
        }
    }

    public static Point indexToPosition(int xInd, int yInd) {
        return new Point(xInd * tileWidth, yInd * tileWidth);
    }

    public static bool isItem(string tagName) {
        return itemTags.Contains(tagName);
    }
}
