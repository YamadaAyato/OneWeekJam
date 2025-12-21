using UnityEngine;

/// <summary>
///         プレイヤーの入力管理クラス
/// </summary>
public class PlayerInputController : MonoBehaviour
{
    [SerializeField] PlayerMover _playerMover;

    void Update()
    {
        if (!_playerMover.IsMoving)
        {
            if (Input.GetKeyDown(KeyCode.W))
                _playerMover.Move(DirectionType.Up);

            else if (Input.GetKeyDown(KeyCode.S))
                _playerMover.Move(DirectionType.Down);

            else if (Input.GetKeyDown(KeyCode.A))
                _playerMover.Move(DirectionType.Left);

            else if (Input.GetKeyDown(KeyCode.D))
                _playerMover.Move(DirectionType.Right);
        }
    }
}
