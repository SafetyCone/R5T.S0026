using System;

using R5T.T0064;


namespace R5T.S0026.Library
{
    [ServiceImplementationMarker]
    public class FileSystemContextProviderAggregation : IFileSystemContextProviderAggregation, IServiceImplementation
    {
        public IDirectoryContextProvider DirectoryContextProvider { get; }
        public IFileContextProvider FileContextProvider { get; }


        public FileSystemContextProviderAggregation(
            IDirectoryContextProvider directoryContextProvider,
            IFileContextProvider fileContextProvider)
        {
            this.DirectoryContextProvider = directoryContextProvider;
            this.FileContextProvider = fileContextProvider;
        }
    }
}
