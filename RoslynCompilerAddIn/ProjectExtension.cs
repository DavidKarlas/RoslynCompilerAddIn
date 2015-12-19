using System;
using System.IO;
using System.Threading.Tasks;
using MonoDevelop.Core;
using MonoDevelop.Projects;

namespace RoslynCompilerAddIn
{
	public class ProjectExtension : MonoDevelop.Projects.ProjectExtension
	{
		protected override Task<TargetEvaluationResult> OnRunTarget(ProgressMonitor monitor, string target, ConfigurationSelector configuration, TargetEvaluationContext context)
		{
			if (Commands.SelectActiveCompilerHandler.IsRoslynCompilerSet) {
				context.GlobalProperties.SetValue("CscToolExe", "csc.exe");
				context.GlobalProperties.SetValue("CscToolPath", Path.Combine(Path.GetDirectoryName(typeof(ProjectExtension).Assembly.Location), "RoslynCompilerFiles"));
				context.GlobalProperties.SetValue("DebugType", "portable");
			}
			return base.OnRunTarget(monitor, target, configuration, context);
		}
	}
}

