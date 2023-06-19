using UnityEngine;
using Visyde;
using Zenject;

namespace Shooter2D.Scripts.Core.Installers
{
    public class ConnectorInstaller : MonoInstaller
    {
        [SerializeField]
        private Connector connector;
        
        public override void InstallBindings()
        {
            BindConnectorService();
        }

        private void BindConnectorService()
        {
            Container.Bind<Connector>().FromInstance(connector).AsSingle();
        }
    }
}