using UnityEngine;

public interface IState 
{
    void Enter();

    void Run();

    void FixedRun();

    void Exit();
}
