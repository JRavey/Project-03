using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayState : State
{
    private GameFSM _stateMachine;
    private GameController _controller;

    public GamePlayState(GameFSM stateMachine, GameController controller)
    {
        _stateMachine = stateMachine;
        _controller = controller;
    }

    public override void Enter()
    {
        base.Enter();

        Debug.Log("STATE: Game Play");
        Debug.Log("Listen for Player Inputs");
        Debug.Log("Display Player HUD");
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void FixedTick()
    {
        base.FixedTick();
    }

    public override void Tick()
    {
        base.Tick();

        // check for win condition
        if (_controller.Input.IsTapPressed == true)
        {
            Debug.Log("You Win!");
            _stateMachine.ChangeState(_stateMachine.EndedState);
            //reload level, change back to SetupState, etc.
        }

        // check for lose condition
        else if (StateDuration >= _controller.TapLimitDuration)
        {
            Debug.Log("You Lose");
            _stateMachine.ChangeState(_stateMachine.EndedState);
            // Lose State, reload level, change back to SetupState, etc.
        }
    }
}
