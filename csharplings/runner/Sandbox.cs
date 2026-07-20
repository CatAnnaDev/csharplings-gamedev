using System.Diagnostics;
using System.Text;

namespace Csharplings.Runner;

public sealed record RunResult(bool Ok, string Output);

public static class Paths
{
    public static string Root { get; } = FindRoot();

    public static string Exercises => Path.Combine(Root, "exercises");
    public static string Solutions => Path.Combine(Root, "solutions");
    public static string Support => Path.Combine(Root, "support");
    public static string SandboxDir => Path.Combine(Root, ".sandbox");

    public static string ExerciseFile(Exercise exercise) =>
        Path.Combine(Exercises, exercise.Section, exercise.ClassName + ".cs");

    public static string SolutionFile(Exercise exercise) =>
        Path.Combine(Solutions, exercise.Section, exercise.ClassName + ".cs");

    public static string Display(string absolutePath) =>
        Path.GetRelativePath(Root, absolutePath);

    private static string FindRoot()
    {
        var directory = new DirectoryInfo(AppContext.BaseDirectory);

        while (directory is not null)
        {
            if (Directory.Exists(Path.Combine(directory.FullName, "exercises"))
                && Directory.Exists(Path.Combine(directory.FullName, "support")))
                return directory.FullName;

            directory = directory.Parent;
        }

        throw new InvalidOperationException("dossier csharplings introuvable");
    }
}

public static class Sandbox
{
    private const string ProjectFile = """
        <Project Sdk="Microsoft.NET.Sdk">
          <PropertyGroup>
            <OutputType>Exe</OutputType>
            <TargetFramework>net8.0</TargetFramework>
            <ImplicitUsings>enable</ImplicitUsings>
            <Nullable>disable</Nullable>
            <AssemblyName>sandbox</AssemblyName>
            <RootNamespace>Csharplings</RootNamespace>
            <EnableDefaultCompileItems>false</EnableDefaultCompileItems>
            <GenerateAssemblyInfo>false</GenerateAssemblyInfo>
            <InvariantGlobalization>true</InvariantGlobalization>
            <NoWarn>CS0219;CS0414;CS0162;CS0168;CS1998</NoWarn>
          </PropertyGroup>
          <ItemGroup>
            <Compile Include="*.cs" />
          </ItemGroup>
        </Project>
        """;

    public static RunResult Run(Exercise exercise, string sourceFile)
    {
        Directory.CreateDirectory(Paths.SandboxDir);
        File.WriteAllText(Path.Combine(Paths.SandboxDir, "sandbox.csproj"), ProjectFile);

        foreach (string existing in Directory.GetFiles(Paths.SandboxDir, "*.cs"))
            File.Delete(existing);

        foreach (string support in Directory.GetFiles(Paths.Support, "*.cs"))
            File.Copy(support, Path.Combine(Paths.SandboxDir, Path.GetFileName(support)), overwrite: true);

        File.Copy(sourceFile, Path.Combine(Paths.SandboxDir, "Exercise.cs"), overwrite: true);
        File.WriteAllText(Path.Combine(Paths.SandboxDir, "Entry.cs"), BuildEntry(exercise.ClassName));

        (int exitCode, string output) = Execute();
        string cleaned = CleanOutput(output, sourceFile);

        return new RunResult(exitCode == 0, cleaned);
    }

    private static string BuildEntry(string className) => $$"""
        using Csharplings;

        public static class SandboxEntry
        {
            public static int Main()
            {
                try
                {
                    {{className}}.Run();
                }
                catch (CheckFailedException failure)
                {
                    Console.WriteLine("      RATE  " + failure.Message);
                    return 1;
                }
                catch (Exception crash)
                {
                    Console.WriteLine("      CRASH " + crash.GetType().Name + " : " + crash.Message);
                    return 1;
                }

                return 0;
            }
        }
        """;

    private static (int, string) Execute()
    {
        var info = new ProcessStartInfo("dotnet")
        {
            WorkingDirectory = Paths.SandboxDir,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
        };

        info.ArgumentList.Add("run");
        info.ArgumentList.Add("--project");
        info.ArgumentList.Add(Paths.SandboxDir);
        info.ArgumentList.Add("-v");
        info.ArgumentList.Add("quiet");
        info.ArgumentList.Add("--nologo");

        using Process process = Process.Start(info);
        string stdout = process.StandardOutput.ReadToEnd();
        string stderr = process.StandardError.ReadToEnd();
        process.WaitForExit();

        return (process.ExitCode, stdout + stderr);
    }

    private static string CleanOutput(string output, string sourceFile)
    {
        string sandboxExercise = Path.Combine(Paths.SandboxDir, "Exercise.cs");
        var builder = new StringBuilder();

        foreach (string line in output.Split('\n'))
        {
            string trimmed = line.TrimEnd('\r');

            if (trimmed.Length == 0)
                continue;

            if (trimmed.Contains("Determining projects") || trimmed.Contains("Restored "))
                continue;

            builder.AppendLine(trimmed
                .Replace(sandboxExercise, Paths.Display(sourceFile))
                .Replace(Paths.SandboxDir + Path.DirectorySeparatorChar, string.Empty));
        }

        return builder.ToString().TrimEnd();
    }
}
