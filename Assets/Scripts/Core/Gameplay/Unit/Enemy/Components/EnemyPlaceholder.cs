using ScriptableObjects.Data.Unit.Enemy;
using ScriptableObjects.SO;
using UnityEngine;
using Utils;
using Zenject;

namespace Core.Gameplay.Unit.Enemy.Components
{
    public class EnemyPlaceholder : EnemyMonoBehaviour
    {
        private EnemyPlaceholderData _data;

        [Inject]
        private void Construct(EnemyDataSO data)
        {
            _data = data.Placeholder;
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
