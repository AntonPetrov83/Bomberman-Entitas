using System;
using Entitas;
using UnityEngine;
using UnityEngine.U2D;

public sealed class CameraSystem : IExecuteSystem
{
    private readonly Contexts _contexts;
    private readonly Camera _camera;
    private readonly PixelPerfectCamera _pixelPerfectCamera;

    public CameraSystem(Contexts contexts)
    {
        _contexts = contexts;
        _camera = Camera.main;
        _pixelPerfectCamera = _camera.GetComponent<PixelPerfectCamera>();
    }

    public void Execute()
    {
        if (!_contexts.game.isPlayer)
            return;

        // NOTE: _camera.aspect is broken on the first frame.
        var aspect = _pixelPerfectCamera.refResolutionX / (float)_pixelPerfectCamera.refResolutionY;
        var tilesY = 15f;
        var tilesX = aspect * tilesY;

        var playerX = GetPlayerX();

        var xMin = tilesX / 2;
        var xMax = 31 - xMin;

        var x = Mathf.Clamp(playerX, xMin, xMax);
        var y = -tilesY / 2 + 2;
        
        _camera.transform.position = new Vector3(x, y, -10);
    }

    private float GetPlayerX()
    {
        if (!_contexts.game.isPlayer)
            return 0;

        var player = _contexts.game.playerEntity;
        if (!player.hasTilemapPosition)
            return 0;

        if (!player.hasPixelOffset)
            return 0;

        // NOTE: Mathf.Floor() here to be in sync with View.UpdatePosition() to avoid jittering.
        return player.tilemapPosition.value.x + Mathf.Floor(player.pixelOffset.value.x) / 16f;
    }
}