using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
    [SerializeField] PlayerMover _playerMover;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && !_playerMover.IsMoving)
            _playerMover.Move(DirectionType.Up);
        else if (Input.GetKeyDown(KeyCode.S) && !_playerMover.IsMoving)
            _playerMover.Move(DirectionType.Down);
        else if (Input.GetKeyDown(KeyCode.A) && !_playerMover.IsMoving)
            _playerMover.Move(DirectionType.Left);
        else if (Input.GetKeyDown(KeyCode.D) && !_playerMover.IsMoving)
            _playerMover.Move(DirectionType.Right);

    }
}
