using Core.Input;
using UnityEngine;
using Utils;
using Zenject;

namespace Core.Gameplay.Character.Components
{
    [RequireComponent(typeof(CharacterIdentity))]
    public class CharacterLook : CharacterMonoBehaviour
    {
        private IInputService _inputService;

        private Vector2 Position => transform.position;

        [Inject]
        private void Construct(IInputService inputService)
        {
            _inputService = inputService;
        }

        protected override void OnEnable()
        {
            base.OnEnable();

            _inputService.OnLook += Look;
        }

        protected override void OnDisable()
        {
            base.OnDisable();

            _inputService.OnLook -= Look;
        }

        private void Look(Vector2 vector)
        {
            if (_inputService.IsMobile() == false)
            {
                vector -= Position;
            }

            vector.Normalize();

            transform.rotation = Quaternion.AngleAxis(Geometry.GetRotationByDirection(vector), Vector3.forward);
        }
    }
}