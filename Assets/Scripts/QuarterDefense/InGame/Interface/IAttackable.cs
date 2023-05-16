namespace QuarterDefense.InGame.Interface
{
    public interface IAttackable
    {
        /// <summary>
        /// 공격 가능한 상태인지 체크하는 함수입니다.
        /// </summary>
        /// <returns></returns>
        public bool CheckAttackableState();
        
        /// <summary>
        /// 공격을 실행하는 함수입니다.
        /// </summary>
        public void Attack();
    }
}