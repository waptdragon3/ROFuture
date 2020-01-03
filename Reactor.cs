using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KSP;
using UnityEngine;

namespace ROFuture
{
    public class Reactor:PartModule
    {
        private static List<PartVariant> Variants;
        public enum ReactorType
        {
            Fission, Fusion
        }
        [UI_VariantSelector(scene = UI_Scene.Editor)]
        [KSPField(guiActive =true, guiName ="Reactor Type", isPersistant =true, guiActiveEditor =true)]
        public ReactorType Type;
        [UI_FloatRange(minValue =100, maxValue =1e6f, scene = UI_Scene.Editor)]
        [KSPAxisField(axisMode =KSPAxisMode.Incremental, guiActive =true, guiActiveEditor =true, guiName ="Power Output", minValue =100, maxValue =1e6f, isPersistant =true)]
        public float PowerOutput;
        [UI_FloatRange(minValue = 0, maxValue = 100, scene = UI_Scene.Editor)]
        [KSPAxisField(axisMode = KSPAxisMode.Incremental, guiActive = true, guiActiveEditor = true, guiName = "Radiation Shielding", minValue = 0, maxValue = 100, isPersistant = true)]
        public float Shielding;

        [KSPField]
        public float MaxShielding;
        [KSPField]
        public float FissionMinPower = 12; //as seen https://www.power-technology.com/features/featurethe-worlds-smallest-nuclear-reactors-4144463/
        [KSPField]
        public float FissionMaxPower = 7965; //as seen https://www.power-technology.com/features/feature-largest-nuclear-power-plants-world/



        private ModuleCoreHeat heat;

        private void FixedUpdate()
        {

        }
        private void Start()
        {
            heat = (ModuleCoreHeat)((Component)this).GetComponent<ModuleCoreHeat>();
            Variants = new List<PartVariant>();
            Variants.Add(new PartVariant("Fission", "Fission", part.attachNodes));
            Variants.Add(new PartVariant("Fusion", "Fusion", part.attachNodes));
            ((UI_VariantSelector)Fields[nameof(Type)].uiControlEditor).variants = Variants;
        }
        public string GetModuleName()
        {
            return "Reactor";
        }

        private void RecalculateMass()
        {

        }
    }
}
