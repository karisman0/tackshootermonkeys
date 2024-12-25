using MelonLoader;
using BTD_Mod_Helper;
using tackshootermonkeys;
using Il2CppAssets.Scripts.Models;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using Il2CppAssets.Scripts.Models.Towers.Weapons;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.Behaviors;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Powers;
using UnityEngine.Playables;
using Harmony;
using HarmonyLib;
using Il2CppAssets.Scripts.Unity;
using UnityEngine.UIElements;

[assembly: MelonInfo(typeof(tackshootermonkeys.tackshootermonkeys), ModHelperData.Name, ModHelperData.Version, ModHelperData.RepoOwner)]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]

namespace tackshootermonkeys;

public class tackshootermonkeys : BloonsTD6Mod
{

    public override void OnApplicationStart()
    {
        ModHelper.Msg<tackshootermonkeys>("tackshootermonkeys loaded");
    }

    public override void OnNewGameModel(GameModel result)
    {

        foreach (var tower in result.towers)
        {

            if (tower.HasBehavior<AttackModel>())
            {
                foreach (var attackModel in tower.GetBehaviors<AttackModel>())
                {
                    attackModel.RemoveBehavior<RotateToTargetModel>();
                }
            }

            foreach (var weapon in tower.GetWeapons())
            {
                weapon.ejectZ = 0;
                weapon.ejectY = 0;
                weapon.ejectX = 0;
                weapon.emission = new ArcEmissionModel("ArcEmissionModel_", 8, 0, 360, null, false, false);
            }
        }
    }
}