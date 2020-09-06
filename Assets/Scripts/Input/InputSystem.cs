using System.Collections.Generic;
using Entitas;
using UnityEngine;

public sealed class InputSystem : IExecuteSystem
{
    private readonly Contexts _contexts;

    public InputSystem(Contexts contexts)
    {
        _contexts = contexts;
    }
    
    public void Execute()
    {
        if (!_contexts.game.isPlayer)
            return;

        _contexts.game.playerEntity.isBombCommand = Input.GetButtonDown("Fire1");
        _contexts.game.playerEntity.isDetonateCommand = Input.GetButtonDown("Fire2");
        _contexts.game.playerEntity.ReplaceMoveCommand(GetMoveDirections());
    }

    private MoveDirections GetMoveDirections()
    {
        var result = MoveDirections.None;

        var left = Input.GetAxisRaw("Horizontal") < -0.1f;
        var right = Input.GetAxisRaw("Horizontal") > 0.1f;
        var up = Input.GetAxisRaw("Vertical") > 0.1f;
        var down = Input.GetAxisRaw("Vertical") < -0.1f;
        
        if (!left || !right)
        {
            if (left)
                result |= MoveDirections.Left;
            else if (right)
                result |= MoveDirections.Right;
        }

        if (!up || !down)
        {
            if (up)
                result |= MoveDirections.Up;
            else if (down)
                result |= MoveDirections.Down;
        }
        
        return result;
    }
}