using System;
using System.Threading.Tasks;

using R5T.D0037;

using R5T.S0026.Library;


namespace System
{
    public static class IRemoteRepositoryContextExtensions
    {
        public static async Task CloneToLocalDirectoryPath(this IRemoteRepositoryContext remoteRepositoryContext,
            string localDirectoryPath,
            IGitOperator sourceControlOperator)
        {
            var url = await remoteRepositoryContext.GetUrl();

            await sourceControlOperator.Clone(
                url,
                localDirectoryPath);
        }

        public static async Task CloneToLocalDirectoryPath(this IRemoteRepositoryContext remoteRepositoryContext,
            IBasicLocalRepositoryContext localRepositoryContext)
        {
            await remoteRepositoryContext.CloneToLocalDirectoryPath(
                localRepositoryContext.DirectoryPath,
                localRepositoryContext.SourceControlOperator);
        }

        public static async Task Create(this IRemoteRepositoryContext remoteRepositoryContext,
            string description,
            bool isPrivate)
        {
            var repositorySpecification = Instances.GitHubRepositorySpecificationGenerator.GetSafetyConeDefault(
                remoteRepositoryContext.Name,
                description,
                isPrivate);

            await remoteRepositoryContext.RemoteRepositoryOperator.CreateRepository(
                repositorySpecification);
        }

        public static async Task Delete(this IRemoteRepositoryContext remoteRepositoryContext)
        {
            await remoteRepositoryContext.RemoteRepositoryOperator.DeleteRepository_SafetyCone(
                remoteRepositoryContext.Name);
        }

        public static async Task<bool> Exists(this IRemoteRepositoryContext remoteRepositoryContext)
        {
            var output = await remoteRepositoryContext.RemoteRepositoryOperator.RepositoryExists(
                remoteRepositoryContext.Name);

            return output;
        }

        public static async Task<string> GetUrl(this IRemoteRepositoryContext remoteRepositoryContext)
        {
            var url = await remoteRepositoryContext.RemoteRepositoryOperator.GetRepositoryCloneUrl_SafetyCone(
                remoteRepositoryContext.Name);

            return url;
        }
    }
}
