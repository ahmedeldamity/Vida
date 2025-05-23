﻿using Microsoft.AspNetCore.Identity;
using Vida.Domain.Entities.IdentityEntities;
using Vida.Persistence.Store;

namespace Vida.Server.ServicesExtension;
public static class IdentityConfigurationsExtension
{
	public static IServiceCollection AddIdentityConfigurations(this IServiceCollection services)
	{
		// We need to register three services of identity (UserManager - RoleManager - SignInManager)
		// but we don't need to register all them one by one
		// because we have method (AddIdentity) that will register the three services
		// --- this method has another overload take action to if you need to configure any option of identity
		services.AddIdentity<AppUser, IdentityRole>(option =>
		{
			option.Password.RequireLowercase = true;
			option.Password.RequireUppercase = false;
			option.Password.RequireDigit = false;
			option.Password.RequireNonAlphanumeric = true;
			option.Password.RequiredUniqueChars = 3;
			option.Password.RequiredLength = 6;
		}).AddEntityFrameworkStores<StoreContext>()
		.AddDefaultTokenProviders();
		// ? this because the three services talking to another Store Services
		// such as (UserManager talk to IUserStore to take all services like createAsync)
		// so we allowed dependency injection to these services too

		return services;
	}
}