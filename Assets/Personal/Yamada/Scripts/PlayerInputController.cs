using UnityEngine;

/// <summary>
///         プレイヤーに入力管理クラス
/// </summary>
public class PlayerInputController : MonoBehaviour
{
    [SerializeField] PlayerMover _playerMover;

    void Update()
    {
        if (!_playerMover.IsMoving)
        {
            switch (_playerMover)
            {
                case
                Input.GetKeyDown(KeyCode.W) => _playerMover.Move(DirectionType.Up);
                    break;
                case
                Input.GetKeyDown(KeyCode.S) => _playerMover.Move(DirectionType.Down);
                    break;
                case
                Input.GetKeyDown(KeyCode.A) => _playerMover.Move(DirectionType.Left);
                    break;
                case
                Input.GetKeyDown(KeyCode.D) => _playerMover.Move(DirectionType.Right);
                    break;
            }
        }
    }
}
