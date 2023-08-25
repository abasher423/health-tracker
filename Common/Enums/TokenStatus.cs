namespace Common.Enums;

public enum TokenStatus
{
    Unused, // The token has been generated but has not been used for email verification. This is the initial status when a token is created.
    Used, // The token has been successfully used for email verification. It indicates that the associated email address has been verified.
    Expired, // The token has reached its expiration date and is no longer valid for email verification
    Invalid, // The token is in an invalid state for some reason other than expiration or being used. This status might be set if there are issues with the token's format, it has been revoked, or there are other integrity concerns
    Revoked, // The token has been intentionally invalidated by a user or an administrator. This status can be useful if you want to allow users to manually revoke their email verification, or if there are security concerns.
    Pending, // The token has been sent to the user's email address, but email verification is pending. This status might be used in cases where email verification is a multi-step process.
    ResendRequested, // The user has requested a new email verification token to be sent. This status can help track when a user has requested a token resend
    Blocked, // In certain scenarios, you might want to block a token temporarily. For example, if there are suspicious activities related to a token, you can set its status to "blocked" until the issue is resolved.
    ExpiredAndResent, // This status can indicate that the original token expired, but the user requested and received a new token for email verification.
    VerifiedAndLinked // In some applications, you might want to link email verification to other actions, such as account activation. This status can represent that email verification is complete, and the user's account is activated
}