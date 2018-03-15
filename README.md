# Aspose.Storage Cloud SDK for .NET
This repository contains Aspose.Storage Cloud SDK for .NET source code. This SDK allows you to work with Aspose.Storage Cloud REST APIs in your .NET applications quickly and easily.

See [API Reference](https://apireference.aspose.cloud/storage/) for full API specification.
## How to use the SDK?
The complete source code is available in this repository folder, you can either directly use it in your project via NuGet package manager. For more details, please visit our [documentation website](https://docs.aspose.cloud/display/storagecloud/Available+SDKs#AvailableSDKs-.NET).

### Prerequisites

To use Aspose Storage for Cloud .NET SDK you need to register an account with [Aspose Cloud](https://www.aspose.cloud/) and lookup/create App Key and SID at [Cloud Dashboard](https://dashboard.aspose.cloud/#/apps). There is free quota available. For more details, see [Aspose Cloud Pricing](https://purchase.aspose.cloud/pricing).

### Installation

#### Install Aspose.Storage-Cloud via NuGet

From the command line:

	nuget install Aspose.Storage-Cloud

From Package Manager:

	PM> Install-Package Aspose.Storage-Cloud

From within Visual Studio:

1. Open the Solution Explorer.
2. Right-click on a project within your solution.
3. Click on *Manage NuGet Packages...*
4. Click on the *Browse* tab and search for "Aspose.Storage-Cloud".
5. Click on the Aspose.Storage-Cloud package, select the appropriate version in the right-tab and click *Install*.

### Sample usage

The examples below show how your application have to initiate and download a file using Aspose.Storage-Cloud library:
```csharp
var configuration = new Configuration { AppSid = appSid, AppKey = appKey };
StorageApi file = new StorageApi(configuration);
FileGetDownloadRequest request = new FileGetDownloadRequest();
request.path = "TestFile.pdf";
request.storage = "StorageName";
var response = StorageApi.FileGetDownload(request);

```

[Tests](/aspose-storage-cloud/aspose-storage-cloud-dotnet/tree/master/Aspose.Storage.Cloud.Sdk.Tests) contain various examples of using the SDK.

## Dependencies
- .NET Framework 2.0 or later
- [Json.NET](https://www.nuget.org/packages/Newtonsoft.Json)



## Contact Us
Your feedback is very important to us. Please feel free to contact us using our [Support Forums](https://forum.aspose.cloud/storage).
