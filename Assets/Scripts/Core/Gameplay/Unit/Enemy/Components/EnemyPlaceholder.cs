using ScriptableObjects.Data.Unit.Enemy;
using UnityEngine;
using Utils;

namespace Core.Gameplay.Unit.Enemy.Components
{
    public class EnemyPlaceholder : EnemyMonoBehaviour
    {
        private EnemyPlaceholderData _data;

        private void Awake()
        {
            _data = Identity.GetData().PlaceholderData;
        }

        private void OnEnable()
        {
            TranslateToPosition();
        }

        private void TranslateToPosition()
        {
            Vector2 randomPosition = Geometry.GetRandomCircleSurfacePosition(_data.Center, _data.Radius);
            transform.position = randomPosition;
        }
    }
}
