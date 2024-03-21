﻿using FontStashSharp;
using TrippyGL;

namespace CJsGameLib;

internal static class Utility
{

    public static Color4b ToTrippy(this FSColor c)
    {
        return new Color4b(c.R, c.G, c.B, c.A);
    }
}
