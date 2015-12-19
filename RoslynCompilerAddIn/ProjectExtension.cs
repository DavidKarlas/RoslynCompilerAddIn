using System;
using System.Threading.Tasks;
using MonoDevelop.Core;
using MonoDevelop.Projects;

namespace RoslynCompilerAddIn
{
	public class ProjectExtension : MonoDevelop.Projects.ProjectExtension
	{
		protected override Task<TargetEvaluationResult> OnRunTarget(ProgressMonitor monitor, string target, ConfigurationSelector configuration, TargetEvaluationContext context)
		{
			context.GlobalProperties.SetValue("CscToolExe", "csc.exe");
			context.GlobalProperties.SetValue("CscToolPath", "/Users/davidkarlas/GIT/roslyn/Binaries/Debug/");
			context.GlobalProperties.SetValue("DebugType", "portable");
			return base.OnRunTarget(monitor, target, configuration, context);
		}
	}
}

