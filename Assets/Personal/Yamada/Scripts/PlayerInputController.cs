using UnityEngine;

/// <summary>
///         プレイヤーの入力管理クラス
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerInputController : MonoBehaviour
{
    [SerializeField] private PlayerMover _playerMover;
    [SerializeField] private PlayerCollider _playerCollider;

    private void Update()
    {
        if (_playerMover.IsMoving) return;


        if (Input.GetKeyDown(KeyCode.A))
            _playerMover.Move(DirectionType.Left,1);

        else if (Input.GetKeyDown(KeyCode.D))
            _playerMover.Move(DirectionType.Right,1);

        else if (_playerCollider.IsLadder)
        {
            Ladder ladder = _playerCollider.CurrentLadder;

            if (Input.GetKeyDown(KeyCode.W) && CanMoveUp(ladder))
                _playerMover.Move(DirectionType.Up,ladder.Step);

            else if (Input.GetKeyDown(KeyCode.S) && CanMoveDown(ladder))
                _playerMover.Move(DirectionType.Down,ladder.Step);
        }
    }

    /// <summary>
    ///         梯子を登れるかの判定
    /// </summary>
    /// <param name="ladder"></param>
    /// <returns></returns>
    private bool CanMoveUp(Ladder ladder)
    {
        return transform.position.y < ladder.transform.position.y;
    }

    /// <summary>
    ///         梯子を下れるかの判定
    /// </summary>
    /// <param name="ladder"></param>
    /// <returns></returns>
    private bool CanMoveDown(Ladder ladder)
    {
        return transform.position.y > ladder.transform.position.y;
    }
}
