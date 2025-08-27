using UnityEngine;

public class StateMachineBase : MonoBehaviour
{
    public IState CurrentState { get; private set; }

    public IState previousState;

    private bool isTransition = false;
    public void ChangState(IState newState)
    {
        if(CurrentState == newState || isTransition)
            return;

        ChangeStateRoutine(newState);
    }

    private void RevertState()
    {
        if (previousState != null)
            ChangState(previousState);
    }

    private void ChangeStateRoutine(IState newState)
    {
        isTransition = true;

        if (CurrentState != null)
        {
            CurrentState.Exit();
            previousState = CurrentState;
        }

        CurrentState = newState;

        if(CurrentState != null)
            CurrentState.Enter();

        Debug.Log($"Enter {newState}");

        isTransition = false;
    }

    private void Update()
    {
        if(CurrentState != null && !isTransition)
            CurrentState.Run();
    }

    private void FixedUpdate()
    {
        if (CurrentState != null && !isTransition)
            CurrentState.FixedRun();
    }
}
