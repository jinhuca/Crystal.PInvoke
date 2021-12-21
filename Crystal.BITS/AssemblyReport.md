## Assembly report for Crystal.BITS.dll
Complete .NET coverage of Windows BITS (Background Intelligent Transfer Service) functionality. Provides access to all library functions through Windows 11 and gracefully fails when new features are not available on older OS versions.
### Enumerations
Enum | Description | Values
---- | ---- | ----
[Crystal.IO.BackgroundCopyACLFlags](https://github.com/dahall/Crystal/search?l=C%23&q=BackgroundCopyACLFlags) | Flags for ACL information to maintain when using SMB to download or upload a file. | None, Owner, Group, Dacl, Sacl, All
[Crystal.IO.BackgroundCopyCost](https://github.com/dahall/Crystal/search?l=C%23&q=BackgroundCopyCost) | Defines the constant values that specify the BITS cost state. | Unrestricted, CappedUsageUnknown, BelowCap, NearCap, OvercapCharged, OvercapThrottled, UsageBased, Roaming, Reserved, IgnoreCongestion, TransferUnrestricted, TransferStandard, TransferNoSurcharge, TransferNotRoaming, TransferAlways
[Crystal.IO.BackgroundCopyErrorContext](https://github.com/dahall/Crystal/search?l=C%23&q=BackgroundCopyErrorContext) | Defines the constant values that specify the context in which the error occurred. | None, Unknown, GeneralQueueManager, QueueManagerNotification, LocalFile, RemoteFile, GeneralTransport, RemoteApplication
[Crystal.IO.BackgroundCopyJobCredentialScheme](https://github.com/dahall/Crystal/search?l=C%23&q=BackgroundCopyJobCredentialScheme) | Defines the constant values that specify the authentication scheme to use when a proxy or server requests user authentication. | Basic, Digest, NTLM, Negotiate, Passport
[Crystal.IO.BackgroundCopyJobCredentialTarget](https://github.com/dahall/Crystal/search?l=C%23&q=BackgroundCopyJobCredentialTarget) | Defines the constant values that specify whether the credentials are used for proxy or server user authentication requests. | Undefined, Server, Proxy
[Crystal.IO.BackgroundCopyJobPriority](https://github.com/dahall/Crystal/search?l=C%23&q=BackgroundCopyJobPriority) | Defines the constant values that specify the priority level of a job. | Foreground, High, Normal, Low
[Crystal.IO.BackgroundCopyJobSecurity](https://github.com/dahall/Crystal/search?l=C%23&q=BackgroundCopyJobSecurity) | HTTP security flags that indicate which errors to ignore when connecting to the server. | AllowSilentRedirect, CheckCRL, IgnoreInvalidCerts, IgnoreExpiredCerts, IgnoreUnknownCA, IgnoreWrongCertUsage, AllowReportedRedirect, DisallowRedirect, AllowHttpsToHttpRedirect
[Crystal.IO.BackgroundCopyJobState](https://github.com/dahall/Crystal/search?l=C%23&q=BackgroundCopyJobState) | Defines constant values for the different states of a job. | Queued, Connecting, Transferring, Suspended, Error, TransientError, Transferred, Acknowledged, Cancelled
[Crystal.IO.BackgroundCopyJobType](https://github.com/dahall/Crystal/search?l=C%23&q=BackgroundCopyJobType) | Defines constant values that specify the type of transfer job, such as download. | Download, Upload, UploadReply
### Structures
Struct | Description
---- | ----
[Crystal.IO.BackgroundCopyFileRange](https://github.com/dahall/Crystal/search?l=C%23&q=BackgroundCopyFileRange) | Identifies a range of bytes to download from a file.
[Crystal.IO.BackgroundCopyJobProgress](https://github.com/dahall/Crystal/search?l=C%23&q=BackgroundCopyJobProgress) | Provides job-related progress information, such as the number of bytes and files transferred. For upload jobs, the progress applies to the upload file, not the reply file.
[Crystal.IO.BackgroundCopyJobReplyProgress](https://github.com/dahall/Crystal/search?l=C%23&q=BackgroundCopyJobReplyProgress) | Provides progress information related to the reply portion of an upload-reply job.
### Classes
Class | Description
---- | ----
[Crystal.IO.BackgroundCopyException](https://github.com/dahall/Crystal/search?l=C%23&q=BackgroundCopyException) | Exceptions specific to BITS
[Crystal.IO.BackgroundCopyFileCollection](https://github.com/dahall/Crystal/search?l=C%23&q=BackgroundCopyFileCollection) | Manages the set of files for a background copy job.
[Crystal.IO.BackgroundCopyFileInfo](https://github.com/dahall/Crystal/search?l=C%23&q=BackgroundCopyFileInfo) | Information about a file in a background copy job.
[Crystal.IO.BackgroundCopyFileRange](https://github.com/dahall/Crystal/search?l=C%23&q=BackgroundCopyFileRange) | Identifies a range of bytes to download from a file.
[Crystal.IO.BackgroundCopyFileRangesTransferredEventArgs](https://github.com/dahall/Crystal/search?l=C%23&q=BackgroundCopyFileRangesTransferredEventArgs) | Used by `Crystal.IO.BackgroundCopyJob.FileRangesTransferred` events.
[Crystal.IO.BackgroundCopyFileTransferredEventArgs](https://github.com/dahall/Crystal/search?l=C%23&q=BackgroundCopyFileTransferredEventArgs) | Used by `Crystal.IO.BackgroundCopyJob.FileTransferred` events.
[Crystal.IO.BackgroundCopyJob](https://github.com/dahall/Crystal/search?l=C%23&q=BackgroundCopyJob) | A job in the Background Copy Service (BITS)
[Crystal.IO.BackgroundCopyJobCollection](https://github.com/dahall/Crystal/search?l=C%23&q=BackgroundCopyJobCollection) | Manages the set of jobs for the background copy service (BITS).
[Crystal.IO.BackgroundCopyJobCredential](https://github.com/dahall/Crystal/search?l=C%23&q=BackgroundCopyJobCredential) | Represents a single BITS job credential.
[Crystal.IO.BackgroundCopyJobCredentials](https://github.com/dahall/Crystal/search?l=C%23&q=BackgroundCopyJobCredentials) | The list of credentials for a job.
[Crystal.IO.BackgroundCopyJobEventArgs](https://github.com/dahall/Crystal/search?l=C%23&q=BackgroundCopyJobEventArgs) | Event argument for background copy job.
[Crystal.IO.BackgroundCopyManager](https://github.com/dahall/Crystal/search?l=C%23&q=BackgroundCopyManager) | Use the BackgroundCopyManager to create transfer jobs, retrieve an enumerator object that contains the jobs in the queue, and to retrieve individual jobs from the queue.
