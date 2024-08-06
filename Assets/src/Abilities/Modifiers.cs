using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public abstract class OnHitModifier
{
    public static class ModifierType
    {
        public static string ONHIT_CHAIN = "ONHIT_CHAIN";
        public static string ONHIT_EXPLODE = "ONHIT_EXPLODE";
    }
    public abstract string GetModifierType();

}



public abstract class AbilitySummonModifier
{
    public static class ModifierType
    {
        public static string ONSUMMON_DUPLICATE = "ONSUMMON_DUPLICATE";
        public static string ONSUMMON_EXPODE = "ONSUMMON_EXPODE";
    }
    public abstract string GetModifierType();

}