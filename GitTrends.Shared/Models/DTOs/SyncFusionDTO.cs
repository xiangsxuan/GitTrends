﻿namespace GitTrends.Shared
{
    public class SyncfusionDTO
    {
        public SyncfusionDTO(string licenseKey, string licenseVersion) =>
            (LicenseKey, LicenseVersion) = (licenseKey, licenseVersion);

        public string LicenseKey { get; }
        public string LicenseVersion { get; }
    }
}
