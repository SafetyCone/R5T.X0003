using System;

using R5T.T0040;

using Instances = R5T.X0003.X003.Instances;


namespace System
{
    public static class IProjectPathsOperatorExtensions
    {
        public static string GetInstancesCodeFileRelativePath(this IProjectPathsOperator _)
        {
            var output = Instances.PathOperator.Combine(
                _.GetCodeDirectoryRelativePath(),
                Instances.CodeFileName.Instances());

            return output;
        }

        public static string GetInstancesCodeFilePathFromProjectDirectoryPath(this IProjectPathsOperator _,
            string projectDirectoryPath)
        {
            var output = Instances.PathOperator.GetDirectoryPath(
                projectDirectoryPath,
                _.GetInstancesCodeFileRelativePath());

            return output;
        }

        /// <summary>
        /// Chooses <see cref="GetInstancesCodeFilePathFromProjectDirectoryPath(IProjectPathsOperator, string)"/> as the default.
        /// </summary>
        public static string GetInstancesCodeFilePath(this IProjectPathsOperator _,
            string projectDirectoryPath)
        {
            var output = _.GetInstancesCodeFilePathFromProjectDirectoryPath(projectDirectoryPath);
            return output;
        }

        public static string GetInstancesCodeFilePathFromProjectPath(this IProjectPathsOperator _,
            string projectFilePath)
        {
            var projectDirectoryPath = _.GetProjectDirectoryPath(projectFilePath);

            var output = _.GetInstancesCodeFilePathFromProjectDirectoryPath(projectDirectoryPath);
            return output;
        }
    }
}
