using System.Text.RegularExpressions;
using UnityEditor.PackageManager;
using UnityEngine;

namespace Mewlist.MassiveClouds
{
    public class PackageVersionInfo
    {
        public enum VersionSupported
        {
            Supported,
            Unsupported,
            Unverified,
            Unknown
        }

        private const string VersionExp = "^([0-9]+)\\.([0-9]+)\\.([0-9]+)$";
        public int Maintenance;
        public int Major;
        public int Minor;
        public string VersionString;

        public PackageVersionInfo(PackageInfo packageInfo)
        {
            VersionString = packageInfo.version;
            var regex = new Regex(VersionExp);
            var match = regex.Match(VersionString);
            Major = int.Parse(match.Groups[1].Value);
            Minor = int.Parse(match.Groups[2].Value);
            Maintenance = int.Parse(match.Groups[3].Value);
        }

        public bool MinorVersionGreaterThan(int major, int minor)
        {
            return major == Major && minor <= Minor;
        }
        

        public VersionSupported Supported
        {
            get
            {
                if (Major <= 2017) return VersionSupported.Unsupported;
                switch (Major)
                {
                    case 2018: return Minor == 4 ? VersionSupported.Supported : VersionSupported.Unsupported;
                    case 2019: return Minor >= 3 ? VersionSupported.Supported : VersionSupported.Unsupported;
                    case 2020: return VersionSupported.Unverified;
                    default:   return VersionSupported.Unknown;
                }
            }
        }
    }
}