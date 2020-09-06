using System;

[Flags]
public enum MoveDirections
{
    None = 0,
    
    Left = 1,
    
    Right = 2,
    
    Up = 4,
    
    Down = 8,
    
    All = Left | Right | Up | Down
}