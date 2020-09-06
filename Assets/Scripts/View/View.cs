using System;
using Entitas;
using Entitas.Unity;
using UnityEngine;

public class View : MonoBehaviour, IView, ITilemapPositionListener, IPixelOffsetListener, IDestroyedListener
{
    private SpriteRenderer _spriteRenderer;
    private Vector2Int _tilemapPosition;
    private Vector2 _pixelOffset;
        
    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Link(IEntity entity)
    {
        gameObject.Link(entity);
        var e = (GameEntity)entity;
        e.AddTilemapPositionListener(this);
        e.AddPixelOffsetListener(this);
        e.AddDestroyedListener(this);

        if (e.hasTilemapPosition)
            _tilemapPosition = e.tilemapPosition.value;

        if (e.hasPixelOffset)
            _pixelOffset = e.pixelOffset.value;

        UpdateTransform();
    }

    public void SetSprite(Sprite sprite)
    {
        _spriteRenderer.sprite = sprite;
    }

    void ITilemapPositionListener.OnTilemapPosition(GameEntity entity, Vector2Int value)
    {
        _tilemapPosition = value;
        UpdateTransform();
    }

    void IPixelOffsetListener.OnPixelOffset(GameEntity entity, Vector2 value)
    {
        _pixelOffset = value;
        UpdateTransform();
    }

    private void UpdateTransform()
    {
        transform.position = new Vector3(
            _tilemapPosition.x + Mathf.FloorToInt(_pixelOffset.x) / 16f + 0.5f,
            -(_tilemapPosition.y + Mathf.FloorToInt(_pixelOffset.y) / 16f + 0.5f),
            0);
    }

    public void OnDestroyed(GameEntity entity)
    {
        gameObject.Unlink();
        Destroy(gameObject);
    }
}
