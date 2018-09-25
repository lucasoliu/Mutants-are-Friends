using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils {

    public static int tileWidth = 1;
    public static string playerLayer = "PlayerLayer";
    public static string tileLayer = "TileLayer";

    // Tag Names
    public static string DNA = "DNA";
    public static string Key = "Key";
    public static string Device = "Device";

    public static string Player = "Player";
    public static string Bird = "Bird";

    public static string Door = "Door";

    // Scene Names
    public static string Level0 = "Level0";
    public static string Level1 = "Level1";
    public static string Level2 = "Level2";
    public static string Level3 = "Level3";

    // List of tags in groupings
    public static List<string> itemTags = new List<string>() { DNA, Device, Key };
    public static List<string> cloneTags = new List<string>() { Bird };

    public static Vector3 indexToVector(int x, int y, string layer)
    {
        // players and items are on level -1
        if (layer == playerLayer) {
            return new Vector3(x * tileWidth, y * tileWidth, -1f);
        } else if (layer == tileLayer) {
            // Tiles are on level 0
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

    public static bool isClone(string tagName)
    {
        return cloneTags.Contains(tagName);
    }

    public static bool isPlayer(string tagName)
    {
        return Player == tagName;
    }

    public static Point positionToPoint(Vector3 position) {
        return new Point(Convert.ToInt32(position.x / tileWidth),
                         Convert.ToInt32(position.y / tileWidth));
    }

    // Returns index of the item, or -1 if not present
    public static int containsItem(List<GameObject> inventory, string tagName)
    {
        for (int i = 0; i < inventory.Count; i++)
        {
            GameObject item = inventory[i];
            // Expand this section for more items
            if (item.CompareTag(tagName))
            {
                return i;
            }
        }
        return -1;
    }
}
