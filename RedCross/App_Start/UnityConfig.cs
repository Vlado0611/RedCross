using RedCross.Services.Implementations;
using RedCross.Services.Interfaces;
using System;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace RedCross
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below.
            // Make sure to add a Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your type's mappings here.
            // container.RegisterType<IProductRepository, ProductRepository>();
            container.RegisterType<IMemberService, MemberService>();
            container.RegisterType<IEmployeeService, EmployeeService>();
            container.RegisterType<IVolunteerService, VolunteerService>();
            container.RegisterType<IBeneficiaryService, BeneficiaryService>();
            container.RegisterType<IActionService, ActionService>();
            container.RegisterType<IPositionService, PositionService>();
            container.RegisterType<IQualificationService, QualificationService>();
            container.RegisterType<IStatusService, StatusService>();
            container.RegisterType<ICityService, CityService>();
            container.RegisterType<IHomeService, HomeService>();
            //container.RegisterType<IUserService, UserService>();

        }

        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            container.RegisterType<IUserService, UserService>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}