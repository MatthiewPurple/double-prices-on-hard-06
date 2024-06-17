using MelonLoader;
using HarmonyLib;
using Il2Cpp;
using one_point_five_prices_on_hard_06;

[assembly: MelonInfo(typeof(OnePointFivePricesOnHard06), "x1.5 prices on Hard (ver. 0.6)", "1.0.0", "Matthiew Purple")]
[assembly: MelonGame("アトラス", "smt3hd")]

namespace one_point_five_prices_on_hard_06;
public class OnePointFivePricesOnHard06 : MelonMod
{
    [HarmonyPatch(typeof(fclShopCalc), nameof(fclShopCalc.shpCalcItemPrice))]
    private class Patch
    {
        public static void Postfix(ref sbyte Mode, ref int __result)
        {
            // If buying on Hard then multiply prices by 1/2
            if (Mode == 0 && dds3ConfigMain.cfgGetBit(9u) == 2) __result = __result / 2;
        }
    }
}
