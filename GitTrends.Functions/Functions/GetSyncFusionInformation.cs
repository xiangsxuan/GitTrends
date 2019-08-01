﻿using System;
using GitTrends.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace GitTrends.Functions
{
    public static class GetSyncfusionInformation
    {
        [FunctionName(nameof(GetSyncfusionInformation))]
        public static IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get", Route = "api/{licenseVersion:alpha}")] HttpRequest request, string licenseVersion, ILogger log)
        {
            log.LogInformation("Received request for SyncFusion Information");

            var licenseKey = Environment.GetEnvironmentVariable($"SyncFusionLicense_{licenseVersion}");

            if (string.IsNullOrWhiteSpace(licenseKey))
                return new BadRequestObjectResult($"Key for {nameof(licenseVersion)} {licenseVersion} not found");

            return new OkObjectResult(new SyncfusionDTO(licenseVersion, licenseKey));
        }
    }
}
