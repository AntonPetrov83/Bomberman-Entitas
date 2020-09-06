﻿using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Event(EventTarget.Self)]
public sealed class PixelOffsetComponent : IComponent
{
    public Vector2 value;
}