using System.Runtime.CompilerServices;

#if UNITY_EDITOR
[assembly: InternalsVisibleTo("MyUnityScripts.Editor")]
#endif
[assembly: InternalsVisibleTo("MyUnityScripts.Runtime")]