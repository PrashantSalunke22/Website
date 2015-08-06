using Daniel15.BusinessLayer;
using Daniel15.BusinessLayer.Services;
using Daniel15.BusinessLayer.Services.CodeRepositories;
using Daniel15.BusinessLayer.Services.Social;
using Daniel15.Data;
using Daniel15.Data.Repositories;
using Daniel15.Data.Repositories.EntityFramework;
using Microsoft.Framework.DependencyInjection;

namespace Daniel15.Infrastructure
{
	/// <summary>
	/// Handles initialisation of the IoC container.
	/// </summary>
	public static class Ioc
	{
		public static void AddDaniel15(this IServiceCollection services)
		{
			// Services
			services.AddSingleton<IUrlShortener, UrlShortener>();
			services.AddSingleton<ISocialManager, SocialManager>();
			services.AddSingleton<IDisqusComments, DisqusComments>();
			services.AddSingleton<IMarkdownProcessor, MarkdownProcessor>();
			services.AddSingleton<IProjectCacheUpdater, ProjectCacheUpdater>();
			services.AddSingleton<ICodeRepositoryManager, CodeRepositoryManager>();
			services.AddSingleton<ICodeRepository, GithubCodeRepository>();
			services.AddSingleton<Facebook>();
			services.AddSingleton<Reddit>();
			services.AddSingleton<Twitter>();
			services.AddSingleton<Linkedin>();

			// TODO
			// _siteConfig.ApiKeys = (ApiKeysConfiguration)ConfigurationManager.GetSection("ApiKeys");
			// Container.Register<IGalleryConfiguration>(() => (GalleryConfiguration)ConfigurationManager.GetSection("Gallery"));

			InitializeDatabase(services);
		}

		/// <summary>
		/// Initialises the database stuff in the IoC container
		/// </summary>
		private static void InitializeDatabase(IServiceCollection services)
		{
			services.AddScoped<DatabaseContext>();
			services.AddScoped<IBlogRepository, BlogRepository>();
			services.AddScoped<IDisqusCommentRepository, DisqusCommentRepository>();
			services.AddScoped<IProjectRepository, ProjectRepository>();
			services.AddScoped<IMicroblogRepository, MicroblogRepository>();
		}
	}
}