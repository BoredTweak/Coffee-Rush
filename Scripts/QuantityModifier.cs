using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class QuantityModifier
{
    private static int[] quantities = {1,5,25,100 };
    private static int index = 0;

    public static int QuantityMod{ get; set; }

    public static void Instantiate()
    {
        QuantityMod = quantities[index];
    }

    public static void NextMod()
    {
        if (index == quantities.Length - 1)
        {
            index = 0;
        }
        else
        {
            index++;
        }
        QuantityMod = quantities[index];
    }
}

