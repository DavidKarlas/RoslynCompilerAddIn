using System;
using MonoDevelop.Components.Commands;
using MonoDevelop.Ide;

namespace RoslynCompilerAddIn.Commands
{
	class SelectActiveCompilerHandler : CommandHandler
	{
		public static bool IsRoslynCompilerSet = false;

		protected override void Update(CommandArrayInfo info)
		{
			if (IdeApp.Workspace.IsOpen) {
				info.Add("Default", "Default").Checked = !IsRoslynCompilerSet;
				info.Add("Roslyn", "Roslyn").Checked = IsRoslynCompilerSet;
			}
		}

		protected override void Run(object dataItem)
		{
			IsRoslynCompilerSet = (dataItem as string) == "Roslyn";
		}
	}
}

