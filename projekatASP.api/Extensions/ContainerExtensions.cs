using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using projekatASP.api.Core;
using projekatASP.application.UseCases.Commands.Categories;
using projekatASP.application.UseCases.Commands.Comments;
using projekatASP.application.UseCases.Commands.Images;
using projekatASP.application.UseCases.Commands.Likes;
using projekatASP.application.UseCases.Commands.Posts;
using projekatASP.application.UseCases.Commands.Roles;
using projekatASP.application.UseCases.Commands.Tags;
using projekatASP.application.UseCases.Commands.Users;
using projekatASP.application.UseCases.Queries.Categories;
using projekatASP.application.UseCases.Queries.Logs;
using projekatASP.application.UseCases.Queries.Posts;
using projekatASP.application.UseCases.Queries.Roles;
using projekatASP.application.UseCases.Queries.Tags;
using projekatASP.application.UseCases.Queries.Users;
using projekatASP.dataAccess;
using projekatASP.domain;
using projekatASP.implementation.UseCases.Commands.Comments;
using projekatASP.implementation.UseCases.Commands.Images;
using projekatASP.implementation.UseCases.Commands.Likes;
using projekatASP.implementation.UseCases.Commands.Logs;
using projekatASP.implementation.UseCases.Commands.Posts;
using projekatASP.implementation.UseCases.Commands.Roles;
using projekatASP.implementation.UseCases.Commands.Tags;
using projekatASP.implementation.UseCases.Commands.Users;
using projekatASP.implementation.UseCases.Queries.Categories;
using projekatASP.implementation.UseCases.Queries.Posts;
using projekatASP.implementation.UseCases.Queries.Roles;
using projekatASP.implementation.UseCases.Queries.Tags;
using projekatASP.implementation.UseCases.Queries.Users;
using projekatASP.implementation.Validators;
using projekatASP.implementation.Validators.Categories;
using projekatASP.implementation.Validators.Comments;
using projekatASP.implementation.Validators.Likes;
using projekatASP.implementation.Validators.Posts;
using projekatASP.implementation.Validators.Tags;
using projekatASP.implementation.Validators.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekatASP.api.Extensions
{
    public static class ContainerExtensions
    {
        public static void AddUseCases(this IServiceCollection services)
        {
            services.AddTransient<IGetCategory, EfGetCategoryQuery>();
            services.AddTransient<IGetCategories, EfGetCategories>();
            services.AddTransient<IGetRole, EfGetRole>();
            services.AddTransient<IGetRoles, EfGetRoles>();
            services.AddTransient<IGetTag, EfGetTag>();
            services.AddTransient<IGetTags, EfGetTags>();
            services.AddTransient<IGetPost, EfGetPost>();
            services.AddTransient<IGetPosts, EfGetPosts>();
            services.AddTransient<IGetUser, EfGetUser>();
            services.AddTransient<IGetUsers, EfGetUsers>();
            services.AddTransient<IDeleteCategory, EfDeleteCategory>();
            services.AddTransient<IDeleteRole, EfDeleteRole>();
            services.AddTransient<IDeleteComment, EfDeleteComment>();
            services.AddTransient<IEditComment, EfEditComment>();
            services.AddTransient<IDeleteTag, EfDeleteTag>();
            services.AddTransient<ICreateCategory, EfCreateCategory>();
            services.AddTransient<IEditCategory, EfEditCategory>();
            services.AddTransient<ICreateRole, EfCreateRole>();
            services.AddTransient<IEditRole, EfEditRole>();
            services.AddTransient<ICreateTag, EfCreateTag>();
            services.AddTransient<IEditTag, EfEditTag>();
            services.AddTransient<IDeleteLike, EfDeleteLike>();
            services.AddTransient<ICreateUser, EfCreateUser>();
            services.AddTransient<IEditUser, EfEditUser>();
            services.AddTransient<ICreatePost, EfCreatePost>();
            services.AddTransient<IEditPost, EfEditPost>();
            services.AddTransient<IGetLogs, EfGetLogs>();
            services.AddTransient<IDeletePost, EfDeletePost>();
            services.AddTransient<ICreateComment, EfCreateComment>();
            services.AddTransient < ICreateLike, EfCreateLike>();
            services.AddTransient < IDeleteImages, EfDeleteImages>();
            services.AddTransient < IDeleteUser, EfDeleteUser>();







            #region Validators

            services.AddTransient<CreateCategoryValidator>();
            services.AddTransient<CreateRoleValidator>();
            services.AddTransient<CreateTagValidator>();
            services.AddTransient<EditCommentValidator>();
            services.AddTransient<CreateUserValidator>();
            services.AddTransient<EditUserValidator>();
            services.AddTransient<CreateLoginValidator>();
            services.AddTransient<CreatePostValidator>();
            services.AddTransient<EditPostValidator>();
            services.AddTransient<CreateCommentValidator>();
            services.AddTransient<CreateLikeValidator>();



            #endregion
        }




        public static void AddJwt(this IServiceCollection services, AppSettings settings)
        {
            services.AddTransient(x =>
            {
                var context = x.GetService<projekatDbContext>();
                var settings = x.GetService<AppSettings>();

                return new JWTManager(context, settings.JwtSettings);
            });


            services.AddAuthentication(options =>
            {
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(cfg =>
            {
                cfg.RequireHttpsMetadata = false;
                cfg.SaveToken = true;
                cfg.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = settings.JwtSettings.Issuer,
                    ValidateIssuer = true,
                    ValidAudience = "Any",
                    ValidateAudience = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings.JwtSettings.SecretKey)),
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });
        }



        public static void AddApplicationUser(this IServiceCollection services)
        {
            services.AddTransient<IApplicationUser>(x =>
            {
                var accessor = x.GetService<IHttpContextAccessor>();
                var header = accessor.HttpContext.Request.Headers["Authorization"];


                var claims = accessor.HttpContext.User;

                if (claims == null || claims.FindFirst("UserId") == null)
                {
                    return new AnonimousUser();
                }

                var actor = new JWTUser
                {
                    Email = claims.FindFirst("Email").Value,
                    Id = Int32.Parse(claims.FindFirst("UserId").Value),
                    Identity = claims.FindFirst("Email").Value,
                    UseCaseIds = JsonConvert.DeserializeObject<List<int>>(claims.FindFirst("UseCases").Value)
                };

                return actor;
            });
        }
    }
}
