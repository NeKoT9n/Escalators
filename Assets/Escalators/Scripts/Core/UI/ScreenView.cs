using Assets.CodeCore.Scripts.Game.UI.Base;
using System;
using UnityEngine;

namespace Assets.Escalators.Scripts.Core.UI
{
    public class ScreenView : UIBase
    {
        [SerializeField] private WinPanel _winPanel;
        [SerializeField] private LosePanel _losePanel;

        public void ShowWinPanel()
        {
            _winPanel.Show();
        }

        public void ShowLosePanel() 
        {
            _losePanel.Show();
        }
    }
}
