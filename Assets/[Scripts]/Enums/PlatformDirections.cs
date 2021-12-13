// PlatformDirections.cs
// Lucas Dunster 101230948
// DLM: 12/12/21
// Enumeration of moving platform directions

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum PlatformDirections
{
    VERTICAL,
    HORIZONTAL,
    DIAGONAL_UPRIGHT,
    DIAGONAL_DOWNRIGHT,
    DIAGONAL_UPLEFT,
    DIAGONAL_DOWNLEFT,
    NUM_OF_DIRECTIONS
}
