﻿using Architecture.Presentation.Models;
using Architecture.Presentation.ViewModels;
using System;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using System.Threading;
using System.Globalization;
using Architecture.Data;
using Architecture.Data.Repositories.Implementations;
using Architecture.Data.Repositories.Interfaces;
using Architecture.Managers;
using Architecture.Managers.Implementations;
using Architecture.Managers.Interfaces;
using Architecture.Presentation.Helpers;
using Architecture.Presentation.ViewModels.Architect;
using Architecture.Presentation.ViewModels.Architecture;
using Architecture.Presentation.ViewModels.Source;
using Architecture.Presentation.ViewModels.Style;
using Architecture.Presentation.Helpers.Implementations;
using Architecture.Presentation.Helpers.Interfaces;
using Architecture.Presentation.ViewModels.Restoration;
using Architecture.Presentation.Views;
using Microsoft.EntityFrameworkCore;

namespace Architecture
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    sealed partial class App : Application
    {
        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            RegisterDependencies();
            this.InitializeComponent();
            this.Suspending += OnSuspending;

            // Applying migrations
            using (var db = new AppDbContext())
            {
                if (!db.Database.EnsureCreated())
                {
                    db.Database.EnsureDeleted();
                }

                db.Database.Migrate();
            }
        }



        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used such as when the application is launched to open a specific file.
        /// </summary>
        /// <param name="e">Details about the launch request and process.</param>
        protected override async void OnLaunched(LaunchActivatedEventArgs e)
        {
            await DbInitializer.Seed();

            Frame rootFrame = Window.Current.Content as Frame;

            // Do not repeat app initialization when the Window already has content,
            // just ensure that the window is active
            if (rootFrame == null)
            {
                // Create a Frame to act as the navigation context and navigate to the first page
                rootFrame = new Frame();

                rootFrame.NavigationFailed += OnNavigationFailed;

                if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    //TODO: Load state from previously suspended application
                }

                // Place the frame in the current Window
                Window.Current.Content = rootFrame;
            }

            if (e.PrelaunchActivated == false)
            {
                if (rootFrame.Content == null)
                {
                    // When the navigation stack isn't restored navigate to the first page,
                    // configuring the new page by passing required information as a navigation
                    // parameter
                    rootFrame.Navigate(typeof(ShellPage), e.Arguments);
                }
                // Ensure the current window is active
                Window.Current.Activate();
            }
        }

        /// <summary>
        /// Invoked when Navigation to a certain page fails
        /// </summary>
        /// <param name="sender">The Frame which failed navigation</param>
        /// <param name="e">Details about the navigation failure</param>
        void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        /// <summary>
        /// Invoked when application execution is being suspended.  Application state is saved
        /// without knowing whether the application will be terminated or resumed with the contents
        /// of memory still intact.
        /// </summary>
        /// <param name="sender">The source of the suspend request.</param>
        /// <param name="e">Details about the suspend request.</param>
        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            //TODO: Save application state and stop any background activity
            deferral.Complete();
        }

        private void RegisterDependencies()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<AppDbContext>();

            #region Services

            SimpleIoc.Default.Register(() => NavigationServiceHepler.GetService);

            SimpleIoc.Default.Register<ICustomNavigationService, CustomNavigationService>();

            #endregion

            #region ViewModels
            
            SimpleIoc.Default.Register<ShellViewModel>();

            SimpleIoc.Default.Register<ArchitectureMainViewModel>();
            SimpleIoc.Default.Register<ArchitectureSearchViewModel>();
            SimpleIoc.Default.Register<ArchitectureFilterViewModel>();
            SimpleIoc.Default.Register<ArchitectureAddViewModel>();
            SimpleIoc.Default.Register<ArchitectureReportsViewModel>();
            SimpleIoc.Default.Register<ArchitectureStatisticsViewModel>();

            SimpleIoc.Default.Register<ArchitectMainViewModel>();
            SimpleIoc.Default.Register<ArchitectSearchViewModel>();
            SimpleIoc.Default.Register<ArchitectFilterViewModel>();
            SimpleIoc.Default.Register<ArchitectAddViewModel>();

            SimpleIoc.Default.Register<StyleMainViewModel>();

            SimpleIoc.Default.Register<SourceMainViewModel>();

            SimpleIoc.Default.Register<RestorationMainViewModel>();

            #endregion

            #region Repositories

            SimpleIoc.Default.Register<IArchitectsRepository, ArchitectsRepository>();
            SimpleIoc.Default.Register<IArchitecturesRepository, ArchitecturesRepository>();
            SimpleIoc.Default.Register<IRestorationsRepository, RestorationsRepository>();
            SimpleIoc.Default.Register<ISourcesRepository, SourcesRepository>();
            SimpleIoc.Default.Register<IStylesRepository, StylesRepository>();
            SimpleIoc.Default.Register<IRepairsRepository, RepairsRepository>();

            #endregion

            #region Managers

            SimpleIoc.Default.Register<IArchitectsManager, ArchitectsManager>();
            SimpleIoc.Default.Register<IArchitecturesManager, ArchitecturesManager>();
            SimpleIoc.Default.Register<IRestorationsManager, RestorationsManager>();
            SimpleIoc.Default.Register<ISourcesManager, SourcesManager>();
            SimpleIoc.Default.Register<IStylesManager, StylesManager>();
            SimpleIoc.Default.Register<IRepairsManager, RepairsManager>();

            #endregion
        }
    }
}
