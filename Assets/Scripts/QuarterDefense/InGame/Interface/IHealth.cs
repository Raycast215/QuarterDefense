namespace QuarterDefense.InGame.Interface
{
    public interface IHealth
    {
        public void Init();
        public void SetMaxHealth(float healthValue);
        public void DecreaseHealth(float delta);
    }
}