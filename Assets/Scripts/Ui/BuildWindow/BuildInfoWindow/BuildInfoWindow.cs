using System;
using System.Collections;
using System.Collections.Generic;
//using Assets.Scripts.System.Application;
using Assets.Scripts.System.DataBase.Model.BuildInfo;
//using Assets.Scripts.System.Tools;
using Assets.Scripts.UI.Window;
using TMPro;
using Ui;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace Assets.Scripts.UI.Window.BuildInfoWindow
{
    public class BuildInfoWindow : ObjectWindow
    {
        [SerializeField] private Button m_closeButton = null;
        [SerializeField] private TextMeshProUGUI m_text = null;

        private BuildInfoModel m_buildInfo = null;

        private Action m_onWindowClosed = null;

        public void Initialize(BuildInfoModel buildInfo)
        {
            InitButtons();
            m_buildInfo = buildInfo;
            InitText();
        }


        private void InitText()
        {
            string result = $"Build version: {m_buildInfo.BuildVersion}\n" +
                            $"\n" +
                            $"Scenario version: {m_buildInfo.ScenarioVersion}\n" +
                            $"Is only local scenario: {StringUtils.BoolToYesNo(m_buildInfo.IsOnlyLocalScenario)}\n" +
                            $"\n" +
                            $"Debug build: {StringUtils.BoolToYesNo(m_buildInfo.IsDebugBuild)}\n" +
                            $"Debug purchases: {StringUtils.BoolToYesNo(m_buildInfo.IsDebugPurchases)}\n" +
                            $"\n" +
                            $"Offer settings:\n" +
                            $"\n" +
                            $"Beginner offer time: {m_buildInfo.BeginnerOfferTime} min\n" +
                            $"Delay after Beginner Offer (minnow): {m_buildInfo.PreDelayMinnow} min\n" +
                            $"Delay after Beginner Offer (other): {m_buildInfo.PreDelayOther} min\n" +
                            $"Minnow offer time: {m_buildInfo.MinnowOfferTime} min\n" +
                            $"Minnow offer cooldown: {m_buildInfo.MinnowOfferCooldown} min\n" +
                            $"Dolphin offer time: {m_buildInfo.DolphinOfferTime} min\n" +
                            $"Dolphin offer cooldown: {m_buildInfo.DolphinOfferCooldown} min\n" +
                            $"Whale offer time: {m_buildInfo.WhaleOfferTime} min\n" +
                            $"Whale offer cooldown: {m_buildInfo.WhaleOfferCooldown} min\n" +
                            $"Discount for first offer (dolphin/whale): {m_buildInfo.PersonalOfferStartDiscount}%\n" +
                            $"\n" +
                            $"Remote config (A/B test) settings:\n" +
                            $"\n" +
                            $"Current experiment name: {m_buildInfo.RemoteConfigExperimentName}\n" +
                            $"Current experiment group: {m_buildInfo.RemoteConfigExperimentGroup}\n" +
                            $"Event bags active: {StringUtils.BoolToYesNo(m_buildInfo.IsEventBagsActive)}\n" +
                            $"Event flowers active: {StringUtils.BoolToYesNo(m_buildInfo.IsEventFlowersActive)}\n";


            m_text.text = result;
        }
        
        
        public override void Show(Action onWindowClosed)
        {
            base.Show(onWindowClosed);
            m_onWindowClosed = onWindowClosed;
            ApplicationContainer.Instance.EventHolder.IngamePanelElementsMove(true);
        }

        private void InitButtons()
        {
            m_closeButton.onClick.AddListener(OnCloseButtonClick);
        }
        
        private void OnCloseButtonClick()
        {
        //    ApplicationContainer.Instance.AudioController.PlaySound(ApplicationContainer.Instance.GlobalConst.BUTTON_CLICK);
            ApplicationContainer.Instance.EventHolder.OnWindowClose(this);
            m_onWindowClosed?.Invoke();
        }
    }
}
