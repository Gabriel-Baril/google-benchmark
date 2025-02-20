using System.IO; // For Path.Combine
using Sharpmake; // Contains the entire Sharpmake object library.

[Generate]
public class GoogleBenchmarkProject : BaseCppProject
{
    public GoogleBenchmarkProject()
    {
        Name = "google-benchmark";
        SourceRootPath = @"[project.SharpmakeCsPath]\src";
        AddTargets(TargetUtil.DefaultTarget);
    }

    [Configure]
    public new void ConfigureAll(Project.Configuration conf, Target target)
    {
        base.ConfigureAll(conf, target);

        conf.SolutionFolder = Constants.EXTERNAL_VS_CATEGORY;

        conf.Defines.Add("BENCHMARK_ENABLE_TESTING");
        conf.Defines.Add("BENCHMARK_ENABLE_EXCEPTIONS");
        // conf.Defines.Add("BENCHMARK_ENABLE_LTO");
        // conf.Defines.Add("BENCHMARK_USE_LIBCXX");
        conf.Defines.Add("BENCHMARK_ENABLE_WERROR");
        // conf.Defines.Add("BENCHMARK_FORCE_WERROR");

        conf.Output = Project.Configuration.OutputType.Lib;
        conf.TargetPath = @"[project.SharpmakeCsPath]\out\bin\[target.Platform]-[target.Optimization]";
        conf.IntermediatePath = @"[project.SharpmakeCsPath]\out\intermediate\[target.Platform]-[target.Optimization]";
        conf.IncludePaths.Add(@"[project.SharpmakeCsPath]\include");
        conf.IncludePaths.Add(@"[project.SharpmakeCsPath]\src");
    }
}