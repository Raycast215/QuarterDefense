using UnityEngine;
using UnityEngine.UI;

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

        /// <summary>
        /// 받아온 Text의 text 사이즈만큼 Text의 Rect사이즈를 변경하는 함수.
        /// </summary>
        /// <param name="targetText"></param>
        public static void SetTextRect(Text targetText)
        {
            float textWidth = targetText.preferredWidth;
            float rectHeight = targetText.rectTransform.sizeDelta.y;

            targetText.rectTransform.sizeDelta = new Vector2(textWidth, rectHeight);
        }
    }
}
