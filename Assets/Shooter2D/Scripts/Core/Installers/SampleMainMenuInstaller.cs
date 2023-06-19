using UnityEngine;
using Visyde;
using Zenject;

namespace Shooter2D.Scripts.Core.Installers
{
    public class SampleMainMenuInstaller : MonoInstaller
    {
        [SerializeField]
        private SampleMainMenu sampleMainMenu;
        
        public override void InstallBindings()
        {
            BindSampleMainMenuService();
        }

        private void BindSampleMainMenuService()
        {
            Container.Bind<SampleMainMenu>().FromInstance(sampleMainMenu).AsSingle();
        }
    }
}