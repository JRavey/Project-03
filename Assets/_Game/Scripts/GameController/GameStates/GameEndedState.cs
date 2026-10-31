using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameEndedState : State
{
    private GameFSM _stateMachine;
    private GameController _controller;

    public GameEndedState(GameFSM stateMachine, GameController controller)
    {
        _stateMachine = stateMachine;
        _controller = controller;
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("STATE: Ended Game");
        Debug.Log("Listen for Player Inputs");
        Debug.Log("Display Game End Screen");
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

        // get player input to go to main manu
        if (_controller.Input.IsSpacePressed == true)
        {
            Debug.Log("To Main Menu");
            SceneManager.LoadScene("MainMenu");
            //reload level, change back to SetupState, etc.
        }
    }
}
