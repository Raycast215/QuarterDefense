namespace QuarterDefense.Common
{
    public static class Util
    {
        /// <summary>
        /// value의 값을 delta만큼 더한 값의 최소, 최대에 따라 clamp 해주는 함수.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="delta"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static int ClampCount(ref int value, int delta, int min, int max)
        {
            value += delta;

            if (value > max) value = min;
            if (value < min) value = max;

            return value;
        }
    }
}
