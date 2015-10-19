using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class NameGenerator
{
    public static List<string> FirstNames = new List<string>() { "Name", "otherName", "Steve" };
    public static List<string> LastNames = new List<string>() { "Murph", "Cane", "Douglas", "Person" };

    public static string GrabRandomName()
    {
        int firstIndex = Random.Range(0, FirstNames.Count);
        int lastIndex = Random.Range(0, LastNames.Count);

        return FirstNames[firstIndex] + " " + LastNames[lastIndex];
    }

}
