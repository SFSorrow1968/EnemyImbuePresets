using System;
using EnemyImbuePresets.Configuration;
using ThunderRoad;
using UnityEngine;

namespace EnemyImbuePresets.Core
{
    public class EIPModule : ThunderScript
    {
        public static EIPModule Instance { get; private set; }

        public override void ScriptEnable()
        {
            base.ScriptEnable();
            Instance = this;

            try
            {
                EIPLog.Info("Factioned Imbuement v" + EIPModOptions.VERSION + " enabled.");
                EIPTelemetry.Initialize();
                EnemyImbueManager.Instance.Initialize();
                EIPModOptionSync.Instance.Initialize();
                Hooks.EventHooks.Subscribe();
            }
            catch (Exception ex)
            {
                EIPLog.Error("ScriptEnable failed: " + ex.Message);
            }
        }

        public override void ScriptUpdate()
        {
            base.ScriptUpdate();

            try
            {
                EIPTelemetry.Update(Time.unscaledTime);
                EIPModOptionSync.Instance.Update();
                EnemyImbueManager.Instance.Update();
            }
            catch (Exception ex)
            {
                EIPLog.Error("ScriptUpdate error: " + ex.Message);
            }
        }

        public override void ScriptDisable()
        {
            try
            {
                Hooks.EventHooks.Unsubscribe();
                EIPModOptionSync.Instance.Shutdown();
                EnemyImbueManager.Instance.Shutdown();
                EIPTelemetry.Shutdown();
                EIPLog.Info("Factioned Imbuement disabled.");
            }
            catch (Exception ex)
            {
                EIPLog.Error("ScriptDisable error: " + ex.Message);
            }

            base.ScriptDisable();
        }
    }
}
