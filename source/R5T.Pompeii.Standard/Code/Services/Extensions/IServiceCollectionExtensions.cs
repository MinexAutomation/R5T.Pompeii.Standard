﻿using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Angleterria.Standard;
using R5T.Dacia;
using R5T.Lombardy.Standard;
using R5T.Macommania.Standard;

using R5T.Pompeii.Default;


namespace R5T.Pompeii.Standard
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="ISolutionAndProjectFileSystemConventions"/> service.
        /// </summary>
        public static IServiceCollection AddSolutionAndProjectFileSystemConventions(this IServiceCollection services)
        {
            services.AddStandardSolutionAndProjectFileSystemConventions(
                services.AddStringlyTypedPathOperatorAction());

            return services;
        }

        /// <summary>
        /// Adds the <see cref="ISolutionAndProjectFileSystemConventions"/> service.
        /// </summary>
        public static ServiceAction<ISolutionAndProjectFileSystemConventions> AddSolutionAndProjectFileSystemConventionsAction(this IServiceCollection services)
        {
            var serviceAction = new ServiceAction<ISolutionAndProjectFileSystemConventions>(() => services.AddSolutionAndProjectFileSystemConventions());
            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="IEntryPointProjectFrameworkNameProvider"/> service.
        /// </summary>
        public static IServiceCollection AddEntryPointProjectFrameworkNameProvider(this IServiceCollection services)
        {
            services.AddNetCoreAppV2_2EntryPointProjectFrameworkNameProvider();

            return services;
        }

        /// <summary>
        /// Adds the <see cref="IEntryPointProjectFrameworkNameProvider"/> service.
        /// </summary>
        public static ServiceAction<IEntryPointProjectFrameworkNameProvider> AddEntryPointProjectFrameworkNameProviderAction(this IServiceCollection services)
        {
            var serviceAction = new ServiceAction<IEntryPointProjectFrameworkNameProvider>(() => services.AddEntryPointProjectFrameworkNameProvider());
            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="ISolutionDirectoryPathProvider"/> service.
        /// </summary>
        public static IServiceCollection AddSolutionDirectoryPathProvider(this IServiceCollection services)
        {
            services.AddStandardSolutionDirectoryPathProvider(
                services.AddExecutableFileDirectoryPathProviderAction(),
                services.AddSolutionAndProjectFileSystemConventionsAction());
            return services;
        }

        /// <summary>
        /// Adds the <see cref="ISolutionDirectoryPathProvider"/> service.
        /// </summary>
        public static ServiceAction<ISolutionDirectoryPathProvider> AddSolutionDirectoryPathProviderAction(this IServiceCollection services)
        {
            var serviceAction = new ServiceAction<ISolutionDirectoryPathProvider>(() => services.AddSolutionDirectoryPathProvider());
            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="IEntryPointProjectDirectoryPathProvider"/> service.
        /// </summary>
        public static IServiceCollection AddEntryPointProjectDirectoryPathProvider(this IServiceCollection services,
            ServiceAction<IEntryPointProjectNameProvider> addEntryPointProjectNameProvider)
        {
            services.AddStandardEntryPointProjectDirectoryPathProvider(
                services.AddSolutionDirectoryPathProviderAction(),
                addEntryPointProjectNameProvider,
                services.AddSolutionAndProjectFileSystemConventionsAction());
            return services;
        }

        /// <summary>
        /// Adds the <see cref="IEntryPointProjectDirectoryPathProvider"/> service.
        /// </summary>
        public static ServiceAction<IEntryPointProjectDirectoryPathProvider> AddEntryPointProjectDirectoryPathProviderAction(this IServiceCollection services,
            ServiceAction<IEntryPointProjectNameProvider> addEntryPointProjectNameProvider)
        {
            var serviceAction = new ServiceAction<IEntryPointProjectDirectoryPathProvider>(() => services.AddEntryPointProjectDirectoryPathProvider(addEntryPointProjectNameProvider));
            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="IEntryPointProjectBuildOutputBinariesDirectoryPathProvider"/> service.
        /// </summary>
        public static IServiceCollection AddEntryPointProjectBuildOutputBinariesDirectoryPathProvider(this IServiceCollection services,
            ServiceAction<IEntryPointProjectNameProvider> addEntryPointProjectNameProvider)
        {
            services.AddStandardEntryPointProjectBuildOutputBinariesDirectoryPathProvider(
                services.AddEntryPointProjectDirectoryPathProviderAction(addEntryPointProjectNameProvider),
                services.AddSolutionAndProjectFileSystemConventionsAction());
            return services;
        }

        /// <summary>
        /// Adds the <see cref="IEntryPointProjectBuildOutputBinariesDirectoryPathProvider"/> service.
        /// </summary>
        public static ServiceAction<IEntryPointProjectBuildOutputBinariesDirectoryPathProvider> AddEntryPointProjectBuildOutputBinariesDirectoryPathProviderAction(this IServiceCollection services,
            ServiceAction<IEntryPointProjectNameProvider> addEntryPointProjectNameProvider)
        {
            var serviceAction = new ServiceAction<IEntryPointProjectBuildOutputBinariesDirectoryPathProvider>(() => services.AddEntryPointProjectBuildOutputBinariesDirectoryPathProvider(
                addEntryPointProjectNameProvider));
            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="IEntryPointProjectBuildOutputConfigurationDirectoryPathProvider"/> service.
        /// </summary>
        public static IServiceCollection AddEntryPointProjectBuildOutputConfigurationDirectoryPathProvider(this IServiceCollection services,
            ServiceAction<IEntryPointProjectNameProvider> addEntryPointProjectNameProvider,
            ServiceAction<IEntryPointProjectBuildConfigurationNameProvider> addEntryPointProjectBuildConfigurationNameProvider)
        {
            services.AddStandardEntryPointProjectBuildOutputConfigurationDirectoryPathProvider(
                services.AddEntryPointProjectBuildOutputBinariesDirectoryPathProviderAction(addEntryPointProjectNameProvider),
                addEntryPointProjectBuildConfigurationNameProvider,
                services.AddSolutionAndProjectFileSystemConventionsAction());
            return services;
        }

        /// <summary>
        /// Adds the <see cref="IEntryPointProjectBuildOutputConfigurationDirectoryPathProvider"/> service.
        /// </summary>
        public static ServiceAction<IEntryPointProjectBuildOutputConfigurationDirectoryPathProvider> AddEntryPointProjectBuildOutputConfigurationDirectoryPathProviderAction(this IServiceCollection services,
            ServiceAction<IEntryPointProjectNameProvider> addEntryPointProjectNameProvider,
            ServiceAction<IEntryPointProjectBuildConfigurationNameProvider> addEntryPointProjectBuildConfigurationNameProvider)
        {
            var serviceAction = new ServiceAction<IEntryPointProjectBuildOutputConfigurationDirectoryPathProvider>(() => services.AddEntryPointProjectBuildOutputConfigurationDirectoryPathProvider(
                addEntryPointProjectNameProvider,
                addEntryPointProjectBuildConfigurationNameProvider));
            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="IEntryPointProjectBuildOutputFrameworkDirectoryPathProvider"/> service.
        /// </summary>
        public static IServiceCollection AddEntryPointProjectBuildOutputFrameworkDirectoryPathProvider(this IServiceCollection services,
            ServiceAction<IEntryPointProjectNameProvider> addEntryPointProjectNameProvider,
            ServiceAction<IEntryPointProjectBuildConfigurationNameProvider> addEntryPointProjectBuildConfigurationNameProvider)
        {
            services.AddStandardEntryPointProjectBuildOutputFrameworkDirectoryPathProvider(
                services.AddEntryPointProjectBuildOutputConfigurationDirectoryPathProviderAction(
                    addEntryPointProjectNameProvider,
                    addEntryPointProjectBuildConfigurationNameProvider),
                services.AddEntryPointProjectFrameworkNameProviderAction(),
                services.AddSolutionAndProjectFileSystemConventionsAction());
            return services;
        }

        /// <summary>
        /// Adds the <see cref="IEntryPointProjectBuildOutputFrameworkDirectoryPathProvider"/> service.
        /// </summary>
        public static ServiceAction<IEntryPointProjectBuildOutputFrameworkDirectoryPathProvider> AddEntryPointProjectBuildOutputFrameworkDirectoryPathProviderAction(this IServiceCollection services,
            ServiceAction<IEntryPointProjectNameProvider> addEntryPointProjectNameProvider,
            ServiceAction<IEntryPointProjectBuildConfigurationNameProvider> addEntryPointProjectBuildConfigurationNameProvider)
        {
            var serviceAction = new ServiceAction<IEntryPointProjectBuildOutputFrameworkDirectoryPathProvider>(() => services.AddEntryPointProjectBuildOutputFrameworkDirectoryPathProvider(
                    addEntryPointProjectNameProvider,
                    addEntryPointProjectBuildConfigurationNameProvider));
            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="IEntryPointProjectBuildOutputPublishDirectoryPathProvider"/> service.
        /// </summary>
        public static IServiceCollection AddEntryPointProjectBuildOutputPublishDirectoryPathProvider(this IServiceCollection services,
            ServiceAction<IEntryPointProjectNameProvider> addEntryPointProjectNameProvider,
            ServiceAction<IEntryPointProjectBuildConfigurationNameProvider> addEntryPointProjectBuildConfigurationNameProvider)
        {
            services.AddStandardEntryPointProjectBuildOutputPublishDirectoryPathProvider(
                services.AddEntryPointProjectBuildOutputFrameworkDirectoryPathProviderAction(
                    addEntryPointProjectNameProvider,
                    addEntryPointProjectBuildConfigurationNameProvider),
                services.AddSolutionAndProjectFileSystemConventionsAction());
            return services;
        }

        /// <summary>
        /// Adds the <see cref="IEntryPointProjectBuildOutputPublishDirectoryPathProvider"/> service.
        /// </summary>
        public static ServiceAction<IEntryPointProjectBuildOutputPublishDirectoryPathProvider> AddEntryPointProjectBuildOutputPublishDirectoryPathProviderAction(this IServiceCollection services,
            ServiceAction<IEntryPointProjectNameProvider> addEntryPointProjectNameProvider,
            ServiceAction<IEntryPointProjectBuildConfigurationNameProvider> addEntryPointProjectBuildConfigurationNameProvider)
        {
            var serviceAction = new ServiceAction<IEntryPointProjectBuildOutputPublishDirectoryPathProvider>(() => services.AddEntryPointProjectBuildOutputPublishDirectoryPathProvider(
                    addEntryPointProjectNameProvider,
                    addEntryPointProjectBuildConfigurationNameProvider));
            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="IEntryPointProjectFilePathProvider"/> service.
        /// </summary>
        public static IServiceCollection AddEntryPointProjectFilePathProvider(this IServiceCollection services,
            ServiceAction<IEntryPointProjectNameProvider> addEntryPointProjectNameProvider)
        {
            services.AddSingleProjectInDirectoryEntryPointProjectFilePathProvider(
                services.AddEntryPointProjectDirectoryPathProviderAction(addEntryPointProjectNameProvider),
                services.AddStringlyTypedPathOperatorAction());
            return services;
        }

        /// <summary>
        /// Adds the <see cref="IEntryPointProjectFilePathProvider"/> service.
        /// </summary>
        public static ServiceAction<IEntryPointProjectFilePathProvider> AddEntryPointProjectFilePathProviderAction(this IServiceCollection services,
            ServiceAction<IEntryPointProjectNameProvider> addEntryPointProjectNameProvider)
        {
            var serviceAction = new ServiceAction<IEntryPointProjectFilePathProvider>(() => services.AddEntryPointProjectFilePathProvider(addEntryPointProjectNameProvider));
            return serviceAction;
        }

        /// <summary>
        /// Adds all standard entry point project services.
        /// Including <see cref="IEntryPointProjectBuildOutputPublishDirectoryPathProvider"/> and <see cref="IEntryPointProjectFilePathProvider"/>.
        /// </summary>
        public static IServiceCollection AddStandardEntryPointProjectConventions(this IServiceCollection services,
            ServiceAction<IEntryPointProjectNameProvider> addEntryPointProjectNameProvider,
            ServiceAction<IEntryPointProjectBuildConfigurationNameProvider> addEntryPointProjectBuildConfigurationNameProvider)
        {
            services
                .AddEntryPointProjectBuildOutputPublishDirectoryPathProvider(
                    addEntryPointProjectNameProvider,
                    addEntryPointProjectBuildConfigurationNameProvider)
                .AddEntryPointProjectFilePathProvider(addEntryPointProjectNameProvider)
                ;

            return services;
        }

        /// <summary>
        /// Adds the <see cref="ISolutionFileNameProvider"/> service.
        /// </summary>
        public static IServiceCollection AddSingleSolutionFileNameProvider(this IServiceCollection services)
        {
            services.AddSingleSolutionFileNameProvider(
                services.AddStringlyTypedPathOperatorAction());

            return services;
        }

        /// <summary>
        /// Adds the <see cref="ISolutionFileNameProvider"/> service.
        /// </summary>
        public static ServiceAction<ISolutionFileNameProvider> AddSingleSolutionFileNameProviderAction(this IServiceCollection services)
        {
            var serviceAction = new ServiceAction<ISolutionFileNameProvider>(() => services.AddSingleSolutionFileNameProvider());
            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="ISolutionFilePathProvider"/> service.
        /// </summary>
        public static IServiceCollection AddStandardSolutionFilePathProvider(this IServiceCollection services,
            ServiceAction<ISolutionFileNameProvider> addSolutionFileNameProvider)
        {
            services.AddStandardSolutionFilePathProvider(
                services.AddSolutionDirectoryPathProviderAction(),
                addSolutionFileNameProvider,
                services.AddStringlyTypedPathOperatorAction());

            return services;
        }

        /// <summary>
        /// Adds the <see cref="ISolutionFilePathProvider"/> service.
        /// </summary>
        public static ServiceAction<ISolutionFilePathProvider> AddStandardSolutionFilePathProviderAction(this IServiceCollection services,
            ServiceAction<ISolutionFileNameProvider> addSolutionFileNameProvider)
        {
            var serviceAction = new ServiceAction<ISolutionFilePathProvider>(() => services.AddStandardSolutionFilePathProvider(
                addSolutionFileNameProvider));
            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="ISolutionFilePathProvider"/> service.
        /// </summary>
        public static IServiceCollection AddSolutionFilePathProvider(this IServiceCollection services,
            ServiceAction<ISolutionFileNameProvider> addSolutionFileNameProvider)
        {
            services.AddStandardSolutionFilePathProvider(addSolutionFileNameProvider);

            return services;
        }

        /// <summary>
        /// Adds the <see cref="ISolutionFilePathProvider"/> service.
        /// </summary>
        public static ServiceAction<ISolutionFilePathProvider> AddSolutionFilePathProviderAction(this IServiceCollection services,
            ServiceAction<ISolutionFileNameProvider> addSolutionFileNameProvider)
        {
            var serviceAction = new ServiceAction<ISolutionFilePathProvider>(() => services.AddSolutionFilePathProvider(
                addSolutionFileNameProvider));
            return serviceAction;
        }

        ///// <summary>
        ///// Adds the <see cref="ISolutionFilePathProvider"/> service.
        ///// </summary>
        //public static IServiceCollection AddSolutionFilePathProvider(this IServiceCollection services)
        //{
        //    services.AddSolutionFilePathProvider(
        //        services.AddSingleSolutionFileNameProviderAction());

        //    return services;
        //}

        ///// <summary>
        ///// Adds the <see cref="ISolutionFilePathProvider"/> service.
        ///// </summary>
        //public static ServiceAction<ISolutionFilePathProvider> AddSolutionFilePathProviderAction(this IServiceCollection services)
        //{
        //    var serviceAction = new ServiceAction<ISolutionFilePathProvider>(() => services.AddSolutionFilePathProvider());
        //    return serviceAction;
        //}

        /// <summary>
        /// Adds the <see cref="IProjectBuildOutputBinariesDirectoryPathProvider"/> service.
        /// </summary>
        public static IServiceCollection AddStandardProjectBinariesOutputDirectoryPathProvider(this IServiceCollection services,
            ServiceAction<ISolutionFileNameProvider> addSolutionFileNameProvider,
            ServiceAction<IEntryPointProjectNameProvider> addEntryPointProjectNameProvider
            )
        {
            services.AddStandardProjectBinariesOutputDirectoryPathProvider(
                services.AddSolutionFilePathProviderAction(addSolutionFileNameProvider),
                addEntryPointProjectNameProvider,
                services.AddVisualStudioStringlyTypedPathPartsOperatorAction(),
                services.AddSolutionAndProjectFileSystemConventionsAction(),
                services.AddStringlyTypedPathOperatorAction());

            return services;
        }

        /// <summary>
        /// Adds the <see cref="IProjectBuildOutputBinariesDirectoryPathProvider"/> service.
        /// </summary>
        public static ServiceAction<IProjectBuildOutputBinariesDirectoryPathProvider> AddStandardProjectBinariesOutputDirectoryPathProviderAction(this IServiceCollection services,
            ServiceAction<ISolutionFileNameProvider> addSolutionFileNameProvider,
            ServiceAction<IEntryPointProjectNameProvider> addEntryPointProjectNameProvider)
        {
            var serviceAction = new ServiceAction<IProjectBuildOutputBinariesDirectoryPathProvider>(() => services.AddStandardProjectBinariesOutputDirectoryPathProvider(
                addSolutionFileNameProvider,
                addEntryPointProjectNameProvider));
            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="IProjectBuildOutputBinariesDirectoryPathProvider"/> service.
        /// </summary>
        public static IServiceCollection AddPublishProjectBuildOutputBinariesDirectoryPathProvider(this IServiceCollection services,
            ServiceAction<IEntryPointProjectNameProvider> addEntryPointProjectNameProvider,
            ServiceAction<IEntryPointProjectBuildConfigurationNameProvider> addEntryPointProjectBuildConfigurationNameProvider)
        {
            services.AddPublishDirectoryProjectBuildOutputBinariesDirectoryPathProvider(
                services.AddEntryPointProjectBuildOutputPublishDirectoryPathProviderAction(
                    addEntryPointProjectNameProvider,
                    addEntryPointProjectBuildConfigurationNameProvider));

            return services;
        }

        /// <summary>
        /// Adds the <see cref="IProjectBuildOutputBinariesDirectoryPathProvider"/> service.
        /// </summary>
        public static ServiceAction<IProjectBuildOutputBinariesDirectoryPathProvider> AddPublishProjectBuildOutputBinariesDirectoryPathProviderAction(this IServiceCollection services,
            ServiceAction<IEntryPointProjectNameProvider> addEntryPointProjectNameProvider,
            ServiceAction<IEntryPointProjectBuildConfigurationNameProvider> addEntryPointProjectBuildConfigurationNameProvider)
        {
            var serviceAction = new ServiceAction<IProjectBuildOutputBinariesDirectoryPathProvider>(() => services.AddPublishProjectBuildOutputBinariesDirectoryPathProvider(
                addEntryPointProjectNameProvider,
                addEntryPointProjectBuildConfigurationNameProvider));
            return serviceAction;
        }
    }
}
