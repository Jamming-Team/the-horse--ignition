using Reflex.Core;
using UnityEngine;
using XTools;

namespace Horse {
    public class ProjectInstaller : ProjectInstallerBase {
        public override void InstallBindings(ContainerBuilder builder)
        { 
            base.InstallBindings(builder);
            
            builder.AddSingleton(new DataManager(), typeof(DataManagerBase), typeof(DataManager));

        }
    }
}