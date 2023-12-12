using System.Collections;
using System.Collections.Generic;
using com.adjust.sdk;
using UnityEngine;

namespace Assets.Scripts.System.DataBase.Model.BuildInfo
{
    public class BuildInfoModel
    {
        public string BuildVersion;
        
        public string ScenarioVersion;
        public bool IsOnlyLocalScenario;
        
        public bool IsDebugBuild;
        public bool IsDebugPurchases;
        
        public int BeginnerOfferTime;
        public int PreDelayMinnow;
        public int PreDelayOther;
        public int MinnowOfferTime;
        public int MinnowOfferCooldown;
        public int DolphinOfferTime;
        public int DolphinOfferCooldown;
        public int WhaleOfferTime;
        public int WhaleOfferCooldown;
        public int PersonalOfferStartDiscount;

        public string RemoteConfigExperimentName;
        public string RemoteConfigExperimentGroup;

        public bool IsEventBagsActive;
        public bool IsEventFlowersActive;
        
    }
}