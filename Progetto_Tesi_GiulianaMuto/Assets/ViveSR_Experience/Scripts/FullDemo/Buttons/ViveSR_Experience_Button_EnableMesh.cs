﻿namespace Vive.Plugin.SR.Experience
{
    public class ViveSR_Experience_Button_EnableMesh : ViveSR_Experience_IButton
    {
        public ViveSR_Experience_DartGeneratorMgr dartGeneratorMgr_static;

        protected override void AwakeToDo()
        {
            ButtonType = MenuButton.EnableMesh;
        }

        public override void ActionToDo()
        {
            if(!isOn)
            {
                ViveSR_Experience_Demo.instance.SubButtonScripts[SubMenuButton.EnableMesh_Dynamic].ForceExcute(false);
                ViveSR_Experience_Demo.instance.SubButtonScripts[SubMenuButton.EnableMesh_StaticMR].ForceExcute(false);
                ViveSR_Experience_Demo.instance.SubButtonScripts[SubMenuButton.EnableMesh_StaticVR].ForceExcute(false);
            }
        }
    }
}