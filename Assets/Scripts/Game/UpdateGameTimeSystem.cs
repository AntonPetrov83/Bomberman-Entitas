using System;
using Entitas;
using UnityEngine;

public sealed class UpdateGameTimeSystem : IExecuteSystem
{
    private readonly GameContext _context;

    public UpdateGameTimeSystem(GameContext context)
    {
        _context = context;
    }
    
    public void Execute()
    {
        if (_context.hasGameTime)
        {
            _context.gameTimeEntity.ReplaceGameTime(_context.gameTime.value + TimeSpan.FromSeconds(Time.deltaTime));
        }
    }
}