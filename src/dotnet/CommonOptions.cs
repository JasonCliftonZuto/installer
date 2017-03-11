using System.IO;
using System.Linq;
using Microsoft.DotNet.Cli.CommandLine;
using Microsoft.DotNet.Tools.Common;

namespace Microsoft.DotNet.Cli
{
    internal static class CommonOptions
    {
        public static Option HelpOption() =>
            Create.Option(
                "-h|--help",
                "Show help information",
                Accept.NoArguments(),
                materialize: o => o.Option.Command().HelpView());

        public static Option VerbosityOption() =>
            Create.Option(
                "-v|--verbosity",
                "Set the verbosity level of the command. Allowed values are q[uiet], m[inimal], n[ormal], d[etailed], and diag[nostic]",
                Accept.AnyOneOf(
                          "q", "quiet",
                          "m", "minimal",
                          "n", "normal",
                          "d", "detailed",
                          "diag", "diagnostic")
                      .ForwardAs(o => $"/verbosity:{o.Arguments.Single()}"));

        public static ArgumentsRule DefaultToCurrentDirectory(this ArgumentsRule rule) =>
            rule.With(defaultValue: () => PathUtility.EnsureTrailingSlash(Directory.GetCurrentDirectory()));
    }
}