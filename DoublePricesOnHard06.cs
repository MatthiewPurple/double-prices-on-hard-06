using MelonLoader;
using HarmonyLib;
using Il2Cpp;
using double_prices_on_hard_06;

[assembly: MelonInfo(typeof(DoublePricesOnHard06), "Double prices on Hard (ver. 0.6)", "1.0.0", "Matthiew Purple")]
[assembly: MelonGame("アトラス", "smt3hd")]

namespace double_prices_on_hard_06;
public class DoublePricesOnHard06 : MelonMod
{
    [HarmonyPatch(typeof(fclShopCalc), nameof(fclShopCalc.shpCalcItemPrice))]
    private class Patch
    {
        public static void Postfix(ref int __result)
        {
            // If on Hard then multiply prices by 2/3
            if (dds3ConfigMain.cfgGetBit(9u) == 2) __result = __result * 2 / 3;
        }
    }
}
