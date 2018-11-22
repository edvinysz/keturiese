using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Server.Models;

namespace Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ServerContext>(opt => opt.UseInMemoryDatabase("TodoList"));
            services.AddDbContext<PlayerContext>(opt => opt.UseInMemoryDatabase("Players"));
            services.AddDbContext<PositionContext>(opt => opt.UseInMemoryDatabase("Positions"));
            services.AddDbContext<BlockInGameContext>(opt => opt.UseInMemoryDatabase("BlocksInGame"));
            services.AddDbContext<GameInfoContext>(opt => opt.UseInMemoryDatabase("GameInfos"));
            services.AddDbContext<ImageContext>(opt => opt.UseInMemoryDatabase("Images"));
            services.AddDbContext<MapContext>(opt => opt.UseInMemoryDatabase("Maps"));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseMvc();
        }
    }
}
