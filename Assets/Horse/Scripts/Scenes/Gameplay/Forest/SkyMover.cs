using System;
using UnityEngine;
using XTools;

namespace Horse {
    public class SkyMover : MonoBehaviour {
        [SerializeField] SpriteRenderer _spriteRenderer;
        [SerializeField] float _speed;
        
        
        Vector2 _size;

        void Awake() {
            _size = _spriteRenderer.size;
        }

        void Update() {
            _size += new Vector2(Time.deltaTime * _speed, 0f);
            _spriteRenderer.size = _size;

        }
    }
}