namespace QuarterDefense.InGame.Character
{
    // Scripted by Raycast
    // 2023. 05. 30
    // Enemy의 이동을 담당하는 클래스.
    
    public class EnemyMovement : Movement
    {
        protected override void Move()
        {
            if (!CheckMovable()) 
            {
                OnMoveFinished.Invoke();
                return;
            }

            OnDirectionChanged.Invoke(_targetPos);
            MovePosition();
        }
    }
}