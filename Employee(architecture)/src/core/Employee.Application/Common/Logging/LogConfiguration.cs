using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Sinks.MSSqlServer;

namespace EmployeeAPI.Application.Common.Logging
{
    public static class LogConfiguration
    {
        
        public static void ConfigurateLogger(WebApplicationBuilder builder)
        {

            string connection = builder.Configuration.GetConnectionString("EmployeeAPICon");

            var sinkOpts = new MSSqlServerSinkOptions() { TableName = "Logs" };

            Log.Logger = new LoggerConfiguration()
            .MinimumLevel
            .Error()
            .WriteTo.Console()
            .WriteTo.File($"logs/log.txt",
            //outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}",
            rollingInterval: RollingInterval.Day)
            .WriteTo.MSSqlServer(
                connectionString: connection,
                sinkOptions: sinkOpts        
            )
            .CreateLogger();

            builder.Host.UseSerilog();
        }
    }
}
