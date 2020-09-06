using UnityEngine;

namespace Animation
{
    [CreateAssetMenu]
    public class AnimationDefinition : ScriptableObject
    {
        [SerializeField] private Sprite[] _sprites;
        [SerializeField] private int _speed;
        [SerializeField] private bool _looped;

        public int frameCount => _sprites.Length;
        
        public int speed => _speed;
        
        public bool looped => _looped;

        public float length => frameCount / (float) speed;

        public Sprite GetSprite(float time)
        {
            var index = GetSpriteIndex(time);
            return index >= 0
                ? _sprites[index]
                : null;
        }

        public int GetSpriteIndex(float time)
        {
            if (_sprites == null || _sprites.Length == 0)
                return -1;

            // TODO: Use integer as frame time counter.
            var frame = (int)(time * _speed);

            if (_looped)
                return frame % _sprites.Length;

            return frame > _sprites.Length - 1 ? _sprites.Length - 1 : frame;
        }
    }
}