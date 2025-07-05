/*
 * This file is subject to the terms and conditions defined in
 * file 'license.txt', which is part of this source code package.
 */

using System;
using SteamKit2.Internal;

namespace SteamKit2.Authentication
{
    /// <summary>
    /// Represents the details required to authenticate on Steam.
    /// </summary>
    public sealed class AuthSessionDetails
    {
        // 安卓设备名称列表
        private static readonly string[] AndroidDeviceNames = new string[]
        {
            "Samsung Galaxy S21 (Android 12)",
            "Google Pixel 6 (Android 12)",
            "OnePlus 9 Pro (Android 12)",
            "Xiaomi Mi 11 Ultra (Android 12)",
            "Huawei P50 Pro (Android 12)",
            "Vivo X70 Pro+ (Android 12)",
            "Oppo Find X3 Pro (Android 12)",
            "Realme GT 2 Pro (Android 12)",
            "Motorola Edge 30 Pro (Android 12)",
            "LG Velvet 2 Pro (Android 12)",
            "Sony Xperia 1 IV (Android 12)",
            "Nokia X20 (Android 12)",
            "Asus ROG Phone 6 (Android 12)",
            "Lenovo Legion Duel 2 (Android 12)",
            "Black Shark 5 Pro (Android 12)",
            "ZTE Axon 40 Ultra (Android 12)",
            "Meizu 18s Pro (Android 12)",
            "Honor Magic 4 Pro (Android 12)",
            "TCL 20S 5G (Android 12)",
            "Alcatel 1S (Android 12)"
            // 你可以根据需要添加更多设备名称
        };

        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        /// <value>The username.</value>
        public string? Username { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>The password.</value>
        public string? Password { get; set; }

        /// <summary>
        /// Gets or sets the device name (or user agent).
        /// </summary>
        /// <value>The device name.</value>
        public string? DeviceFriendlyName { get; set; } = GetRandomAndroidDeviceName();

        /// <summary>
        /// Gets or sets the platform type that the login will be performed for.
        /// </summary>
        public EAuthTokenPlatformType PlatformType { get; set; } = EAuthTokenPlatformType.k_EAuthTokenPlatformType_SteamClient;

        /// <summary>
        /// Gets or sets the client operating system type.
        /// </summary>
        /// <value>The client operating system type.</value>
        public EOSType ClientOSType { get; set; } = Utils.GetOSType();

        /// <summary>
        /// Gets or sets the session persistence.
        /// </summary>
        /// <value>The persistence.</value>
        public bool IsPersistentSession { get; set; } = false;

        /// <summary>
        /// Gets or sets the website id that the login will be performed for.
        /// Known values are "Unknown", "Client", "Mobile", "Website", "Store", "Community", "Partner", "SteamStats".
        /// </summary>
        /// <value>The website id.</value>
        public string? WebsiteID { get; set; } = "Client";

        /// <summary>
        /// Steam guard data for client login. Provide <see cref="AuthPollResult.NewGuardData"/> if available.
        /// </summary>
        /// <value>The guard data.</value>
        public string? GuardData { get; set; }

        /// <summary>
        /// Authenticator object which will be used to handle 2-factor authentication if necessary.
        /// Use <see cref="UserConsoleAuthenticator"/> for a default implementation.
        /// </summary>
        /// <value>The authenticator object.</value>
        public IAuthenticator? Authenticator { get; set; }

        // 获取随机安卓设备名称的方法
        private static string GetRandomAndroidDeviceName()
        {
            Random random = new Random();
            int index = random.Next(0, AndroidDeviceNames.Length);
            return AndroidDeviceNames[index];
        }
    }
}
