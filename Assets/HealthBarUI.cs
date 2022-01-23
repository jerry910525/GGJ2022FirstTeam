﻿using UnityEngine;
using UnityEngine.UI;

namespace Feng.Battle
{
    [RequireComponent(typeof(Image))]
    public class HealthBarUI : MonoBehaviour
    {
        [SerializeField] Image image;
        public void UpdateHealthBarUI(float percentage)
        {
            if (percentage < 0 || percentage > 1)
            {
                throw new PercentageOutOfRangeException();
            }
            image.fillAmount = percentage;
            image.color = new Color(1 - percentage, percentage, 0);
        }
    }
}