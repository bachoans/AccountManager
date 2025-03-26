namespace AccountManager.Shared.DTOs
{
    /// <summary>
    /// Represents the full account details returned to the client.
    /// </summary>
    public class AccountDto
    {
        /// <summary>Unique identifier of the account.</summary>
        public int AccountId { get; set; }

        /// <summary>Unique token for the account, used for authentication or external identification.</summary>
        public string Token { get; set; }

        /// <summary>Indicates whether the account is active.</summary>
        public bool IsActive { get; set; }

        /// <summary>Name of the company that owns the account.</summary>
        public string CompanyName { get; set; }

        /// <summary>Country of the company.</summary>
        public string? Country { get; set; }

        /// <summary>Indicates if 2FA is enabled for the account.</summary>
        public bool Is2FAEnabled { get; set; }

        /// <summary>Indicates if IP filtering is enabled for the account.</summary>
        public bool IsIPFilterEnabled { get; set; }

        /// <summary>Indicates if session timeout is enabled.</summary>
        public bool IsSessionTimeoutEnabled { get; set; }

        /// <summary>Session timeout duration in minutes.</summary>
        public int SessionTimeOut { get; set; }

        /// <summary>Local timezone of the account's company.</summary>
        public string? LocalTimeZone { get; set; }

        /// <summary>ID of the associated subscription.</summary>
        public int SubscriptionId { get; set; }

        /// <summary>Name of the subscription.</summary>
        public string? SubscriptionName { get; set; }

        /// <summary>ID of the subscription status.</summary>
        public int SubscriptionStatusId { get; set; }

        /// <summary>Name/description of the subscription status.</summary>
        public string? SubscriptionStatusName { get; set; }

        /// <summary>Date and time when the account was created.</summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>Full subscription configuration details.</summary>
        public AccountSubscriptionDto? Subscription { get; set; }
    }
}
