// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose Pty Ltd" file="StorageApi.cs">
//   Copyright (c) 2018 Aspose.Storage for Cloud
// </copyright>
// <summary>
//   Permission is hereby granted, free of charge, to any person obtaining a copy
//  of this software and associated documentation files (the "Software"), to deal
//  in the Software without restriction, including without limitation the rights
//  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//  copies of the Software, and to permit persons to whom the Software is
//  furnished to do so, subject to the following conditions:
// 
//  The above copyright notice and this permission notice shall be included in all
//  copies or substantial portions of the Software.
// 
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
//  SOFTWARE.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Aspose.Storage.Cloud.Sdk.Api
{
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using Aspose.Storage.Cloud.Sdk.Model;
    using Aspose.Storage.Cloud.Sdk.Model.Requests;
	using Aspose.Storage.Cloud.Sdk.Internal;
    using Aspose.Storage.Cloud.Sdk.Internal.RequestHandlers;
    
    /// <summary>
    /// Aspose.Storage for Cloud API.
    /// </summary>
    public class StorageApi
    {        
        private readonly ApiInvoker apiInvoker;
        private readonly Configuration configuration;     

        /// <summary>
        /// Initializes a new instance of the <see cref="StorageApi"/> class.
        /// </summary>
        /// <param name="apiKey">
        /// The api Key.
        /// </param>
        /// <param name="appSid">
        /// The app Sid.
        /// </param>
        public StorageApi(string apiKey, string appSid)
            : this(new Configuration { AppKey = apiKey, AppSid = appSid })
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StorageApi"/> class.
        /// </summary>    
        /// <param name="configuration">Configuration settings</param>
        public StorageApi(Configuration configuration)
        {
            this.configuration = configuration;
            
            var requestHandlers = new List<IRequestHandler>();
            requestHandlers.Add(new OAuthRequestHandler(this.configuration));
            requestHandlers.Add(new DebugLogRequestHandler(this.configuration));
            requestHandlers.Add(new ApiExceptionRequestHandler());
            requestHandlers.Add(new AuthWithSignatureRequestHandler(this.configuration));
            this.apiInvoker = new ApiInvoker(requestHandlers);
        }                            

        /// <summary>
        /// Check the disk usage of the current account  
        /// </summary>
        /// <param name="request">Request. <see cref="GetDiscUsageRequest" /></param> 
        /// <returns><see cref="DiscUsageResponse"/></returns>            
        public DiscUsageResponse GetDiscUsage(GetDiscUsageRequest request)
        {
            // create path and map variables
            var resourcePath = this.configuration.GetApiRootUrl() + "/storage/disc";
            resourcePath = Regex
                        .Replace(resourcePath, "\\*", string.Empty)
                        .Replace("&amp;", "&")
                        .Replace("/?", "?");
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "storage", request.storage);
            
            try 
            {                               
                var response = this.apiInvoker.InvokeApi(
                    resourcePath, 
                    "GET", 
                    null, 
                    null, 
                    null);
                if (response != null)
                {
					return (DiscUsageResponse)SerializationHelper.Deserialize(response, typeof(DiscUsageResponse));
                }
                    
                return null;
            } 
            catch (ApiException ex) 
            {
                if (ex.ErrorCode == 404) 
                {
                    return null;
                }
                
                throw;                
            }
        }

        /// <summary>
        /// Check if a specific file or folder exists 
        /// </summary>
        /// <param name="request">Request. <see cref="GetIsExistRequest" /></param> 
        /// <returns><see cref="FileExistResponse"/></returns>            
        public FileExistResponse GetIsExist(GetIsExistRequest request)
        {
            // verify the required parameter 'path' is set
            if (request.path == null) 
            {
                throw new ApiException(400, "Missing required parameter 'path' when calling GetIsExist");
            }

            // create path and map variables
            var resourcePath = this.configuration.GetApiRootUrl() + "/storage/exist";
            resourcePath = Regex
                        .Replace(resourcePath, "\\*", string.Empty)
                        .Replace("&amp;", "&")
                        .Replace("/?", "?");
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "path", request.path);
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "versionId", request.versionId);
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "storage", request.storage);
            
            try 
            {                               
                var response = this.apiInvoker.InvokeApi(
                    resourcePath, 
                    "GET", 
                    null, 
                    null, 
                    null);
                if (response != null)
                {
					return (FileExistResponse)SerializationHelper.Deserialize(response, typeof(FileExistResponse));
                }
                    
                return null;
            } 
            catch (ApiException ex) 
            {
                if (ex.ErrorCode == 404) 
                {
                    return null;
                }
                
                throw;                
            }
        }

        /// <summary>
        /// Check if storage exists  
        /// </summary>
        /// <param name="request">Request. <see cref="GetIsStorageExistRequest" /></param> 
        /// <returns><see cref="StorageExistResponse"/></returns>            
        public StorageExistResponse GetIsStorageExist(GetIsStorageExistRequest request)
        {
            // verify the required parameter 'name' is set
            if (request.name == null) 
            {
                throw new ApiException(400, "Missing required parameter 'name' when calling GetIsStorageExist");
            }

            // create path and map variables
            var resourcePath = this.configuration.GetApiRootUrl() + "/storage/{name}/exist";
            resourcePath = Regex
                        .Replace(resourcePath, "\\*", string.Empty)
                        .Replace("&amp;", "&")
                        .Replace("/?", "?");
            resourcePath = UrlHelper.AddPathParameter(resourcePath, "name", request.name);
            
            try 
            {                               
                var response = this.apiInvoker.InvokeApi(
                    resourcePath, 
                    "GET", 
                    null, 
                    null, 
                    null);
                if (response != null)
                {
					return (StorageExistResponse)SerializationHelper.Deserialize(response, typeof(StorageExistResponse));
                }
                    
                return null;
            } 
            catch (ApiException ex) 
            {
                if (ex.ErrorCode == 404) 
                {
                    return null;
                }
                
                throw;                
            }
        }

        /// <summary>
        /// Get the file&#39;s versions list  
        /// </summary>
        /// <param name="request">Request. <see cref="GetListFileVersionsRequest" /></param> 
        /// <returns><see cref="FileVersionsResponse"/></returns>            
        public FileVersionsResponse GetListFileVersions(GetListFileVersionsRequest request)
        {
            // verify the required parameter 'path' is set
            if (request.path == null) 
            {
                throw new ApiException(400, "Missing required parameter 'path' when calling GetListFileVersions");
            }

            // create path and map variables
            var resourcePath = this.configuration.GetApiRootUrl() + "/storage/version";
            resourcePath = Regex
                        .Replace(resourcePath, "\\*", string.Empty)
                        .Replace("&amp;", "&")
                        .Replace("/?", "?");
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "path", request.path);
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "storage", request.storage);
            
            try 
            {                               
                var response = this.apiInvoker.InvokeApi(
                    resourcePath, 
                    "GET", 
                    null, 
                    null, 
                    null);
                if (response != null)
                {
					return (FileVersionsResponse)SerializationHelper.Deserialize(response, typeof(FileVersionsResponse));
                }
                    
                return null;
            } 
            catch (ApiException ex) 
            {
                if (ex.ErrorCode == 404) 
                {
                    return null;
                }
                
                throw;                
            }
        }

        /// <summary>
        /// Remove a specific file  
        /// </summary>
        /// <param name="request">Request. <see cref="DeleteFileRequest" /></param> 
        /// <returns><see cref="RemoveFileResponse"/></returns>            
        public RemoveFileResponse DeleteFile(DeleteFileRequest request)
        {
            // verify the required parameter 'path' is set
            if (request.path == null)
            {
                throw new ApiException(400, "Missing required parameter 'path' when calling DeleteFile");
            }

            // create path and map variables
            var resourcePath = this.configuration.GetApiRootUrl() + "/storage/file";
            resourcePath = Regex
                        .Replace(resourcePath, "\\*", string.Empty)
                        .Replace("&amp;", "&")
                        .Replace("/?", "?");
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "path", request.path);
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "versionId", request.versionId);
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "storage", request.storage);

            try
            {
                var response = this.apiInvoker.InvokeApi(
                    resourcePath,
                    "DELETE",
                    null,
                    null,
                    null);
                if (response != null)
                {
                    return (RemoveFileResponse)SerializationHelper.Deserialize(response, typeof(RemoveFileResponse));
                }

                return null;
            }
            catch (ApiException ex)
            {
                if (ex.ErrorCode == 404)
                {
                    return null;
                }

                throw;
            }
        }

        /// <summary>
        /// Download a specific file  
        /// </summary>
        /// <param name="request">Request. <see cref="GetDownloadRequest" /></param> 
        /// <returns><see cref="System.IO.Stream"/></returns>            
        public System.IO.Stream GetDownload(GetDownloadRequest request)
        {
            // verify the required parameter 'path' is set
            if (request.path == null)
            {
                throw new ApiException(400, "Missing required parameter 'path' when calling GetDownload");
            }

            // create path and map variables
            var resourcePath = this.configuration.GetApiRootUrl() + "/storage/file";
            resourcePath = Regex
                        .Replace(resourcePath, "\\*", string.Empty)
                        .Replace("&amp;", "&")
                        .Replace("/?", "?");
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "path", request.path);
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "versionId", request.versionId);
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "storage", request.storage);

            try
            {
                return this.apiInvoker.InvokeBinaryApi(
                    resourcePath,
                    "GET",
                    null,
                    null,
                    null);
            }
            catch (ApiException ex)
            {
                if (ex.ErrorCode == 404)
                {
                    return null;
                }

                throw;
            }
        }

        /// <summary>
        /// Move a specific file  
        /// </summary>
        /// <param name="request">Request. <see cref="PostMoveFileRequest" /></param> 
        /// <returns><see cref="MoveFileResponse"/></returns>            
        public MoveFileResponse PostMoveFile(PostMoveFileRequest request)
        {
            // verify the required parameter 'src' is set
            if (request.src == null)
            {
                throw new ApiException(400, "Missing required parameter 'src' when calling PostMoveFile");
            }

            // verify the required parameter 'dest' is set
            if (request.dest == null)
            {
                throw new ApiException(400, "Missing required parameter 'dest' when calling PostMoveFile");
            }

            // create path and map variables
            var resourcePath = this.configuration.GetApiRootUrl() + "/storage/file";
            resourcePath = Regex
                        .Replace(resourcePath, "\\*", string.Empty)
                        .Replace("&amp;", "&")
                        .Replace("/?", "?");
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "src", request.src);
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "dest", request.dest);
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "versionId", request.versionId);
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "storage", request.storage);
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "destStorage", request.destStorage);

            try
            {
                var response = this.apiInvoker.InvokeApi(
                    resourcePath,
                    "POST",
                    null,
                    null,
                    null);
                if (response != null)
                {
                    return (MoveFileResponse)SerializationHelper.Deserialize(response, typeof(MoveFileResponse));
                }

                return null;
            }
            catch (ApiException ex)
            {
                if (ex.ErrorCode == 404)
                {
                    return null;
                }

                throw;
            }
        }

        /// <summary>
        /// Upload a specific file  
        /// </summary>
        /// <param name="request">Request. <see cref="PutCreateRequest" /></param> 
        /// <returns><see cref="UploadResponse"/></returns>            
        public UploadResponse PutCreate(PutCreateRequest request)
        {
            // verify the required parameter 'path' is set
            if (request.path == null)
            {
                throw new ApiException(400, "Missing required parameter 'path' when calling PutCreate");
            }

            // verify the required parameter 'file' is set
            if (request.File == null)
            {
                throw new ApiException(400, "Missing required parameter 'file' when calling PutCreate");
            }

            // create path and map variables
            var resourcePath = this.configuration.GetApiRootUrl() + "/storage/file";
            resourcePath = Regex
                        .Replace(resourcePath, "\\*", string.Empty)
                        .Replace("&amp;", "&")
                        .Replace("/?", "?");
            var formParams = new Dictionary<string, object>();
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "path", request.path);
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "versionId", request.versionId);
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "storage", request.storage);

            if (request.File != null)
            {
                formParams.Add("file", this.apiInvoker.ToFileInfo(request.File, "File"));
            }

            try
            {
                var response = this.apiInvoker.InvokeApi(
                    resourcePath,
                    "PUT",
                    null,
                    null,
                    formParams);
                if (response != null)
                {
                    return (UploadResponse)SerializationHelper.Deserialize(response, typeof(UploadResponse));
                }

                return null;
            }
            catch (ApiException ex)
            {
                if (ex.ErrorCode == 404)
                {
                    return null;
                }

                throw;
            }
        }

        /// <summary>
        /// Copy a specific file  
        /// </summary>
        /// <param name="request">Request. <see cref="PutCopyRequest" /></param> 
        /// <returns><see cref="CopyFileResponse"/></returns>            
        public CopyFileResponse PutCopy(PutCopyRequest request)
        {
            // verify the required parameter 'path' is set
            if (request.path == null)
            {
                throw new ApiException(400, "Missing required parameter 'path' when calling PutCopy");
            }

            // verify the required parameter 'newdest' is set
            if (request.newdest == null)
            {
                throw new ApiException(400, "Missing required parameter 'newdest' when calling PutCopy");
            }

            // create path and map variables
            var resourcePath = this.configuration.GetApiRootUrl() + "/storage/file";
            resourcePath = Regex
                        .Replace(resourcePath, "\\*", string.Empty)
                        .Replace("&amp;", "&")
                        .Replace("/?", "?");
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "path", request.path);
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "newdest", request.newdest);
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "versionId", request.versionId);
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "storage", request.storage);
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "destStorage", request.destStorage);

            try
            {
                var response = this.apiInvoker.InvokeApi(
                    resourcePath,
                    "PUT",
                    null,
                    null,
                    null);
                if (response != null)
                {
                    return (CopyFileResponse)SerializationHelper.Deserialize(response, typeof(CopyFileResponse));
                }

                return null;
            }
            catch (ApiException ex)
            {
                if (ex.ErrorCode == 404)
                {
                    return null;
                }

                throw;
            }
        }

        /// <summary>
        /// Remove a specific folder  
        /// </summary>
        /// <param name="request">Request. <see cref="DeleteFolderRequest" /></param> 
        /// <returns><see cref="RemoveFolderResponse"/></returns>            
        public RemoveFolderResponse DeleteFolder(DeleteFolderRequest request)
        {
            // verify the required parameter 'path' is set
            if (request.path == null)
            {
                throw new ApiException(400, "Missing required parameter 'path' when calling DeleteFolder");
            }

            // create path and map variables
            var resourcePath = this.configuration.GetApiRootUrl() + "/storage/folder";
            resourcePath = Regex
                        .Replace(resourcePath, "\\*", string.Empty)
                        .Replace("&amp;", "&")
                        .Replace("/?", "?");
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "path", request.path);
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "storage", request.storage);
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "recursive", request.recursive);

            try
            {
                var response = this.apiInvoker.InvokeApi(
                    resourcePath,
                    "DELETE",
                    null,
                    null,
                    null);
                if (response != null)
                {
                    return (RemoveFolderResponse)SerializationHelper.Deserialize(response, typeof(RemoveFolderResponse));
                }

                return null;
            }
            catch (ApiException ex)
            {
                if (ex.ErrorCode == 404)
                {
                    return null;
                }

                throw;
            }
        }

        /// <summary>
        /// Get the file listing of a specific folder  
        /// </summary>
        /// <param name="request">Request. <see cref="GetListFilesRequest" /></param> 
        /// <returns><see cref="FilesResponse"/></returns>            
        public FilesResponse GetListFiles(GetListFilesRequest request)
        {
            // create path and map variables
            var resourcePath = this.configuration.GetApiRootUrl() + "/storage/folder";
            resourcePath = Regex
                        .Replace(resourcePath, "\\*", string.Empty)
                        .Replace("&amp;", "&")
                        .Replace("/?", "?");
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "path", request.path);
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "storage", request.storage);

            try
            {
                var response = this.apiInvoker.InvokeApi(
                    resourcePath,
                    "GET",
                    null,
                    null,
                    null);
                if (response != null)
                {
                    return (FilesResponse)SerializationHelper.Deserialize(response, typeof(FilesResponse));
                }

                return null;
            }
            catch (ApiException ex)
            {
                if (ex.ErrorCode == 404)
                {
                    return null;
                }

                throw;
            }
        }

        /// <summary>
        /// Move a specific folder  
        /// </summary>
        /// <param name="request">Request. <see cref="PostMoveFolderRequest" /></param> 
        /// <returns><see cref="MoveFolderResponse"/></returns>            
        public MoveFolderResponse PostMoveFolder(PostMoveFolderRequest request)
        {
            // verify the required parameter 'src' is set
            if (request.src == null)
            {
                throw new ApiException(400, "Missing required parameter 'src' when calling PostMoveFolder");
            }

            // verify the required parameter 'dest' is set
            if (request.dest == null)
            {
                throw new ApiException(400, "Missing required parameter 'dest' when calling PostMoveFolder");
            }

            // create path and map variables
            var resourcePath = this.configuration.GetApiRootUrl() + "/storage/folder";
            resourcePath = Regex
                        .Replace(resourcePath, "\\*", string.Empty)
                        .Replace("&amp;", "&")
                        .Replace("/?", "?");
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "src", request.src);
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "dest", request.dest);
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "storage", request.storage);
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "destStorage", request.destStorage);

            try
            {
                var response = this.apiInvoker.InvokeApi(
                    resourcePath,
                    "POST",
                    null,
                    null,
                    null);
                if (response != null)
                {
                    return (MoveFolderResponse)SerializationHelper.Deserialize(response, typeof(MoveFolderResponse));
                }

                return null;
            }
            catch (ApiException ex)
            {
                if (ex.ErrorCode == 404)
                {
                    return null;
                }

                throw;
            }
        }

        /// <summary>
        /// Create the folder  
        /// </summary>
        /// <param name="request">Request. <see cref="PutCreateFolderRequest" /></param> 
        /// <returns><see cref="CreateFolderResponse"/></returns>            
        public CreateFolderResponse PutCreateFolder(PutCreateFolderRequest request)
        {
            // verify the required parameter 'path' is set
            if (request.path == null)
            {
                throw new ApiException(400, "Missing required parameter 'path' when calling PutCreateFolder");
            }

            // create path and map variables
            var resourcePath = this.configuration.GetApiRootUrl() + "/storage/folder";
            resourcePath = Regex
                        .Replace(resourcePath, "\\*", string.Empty)
                        .Replace("&amp;", "&")
                        .Replace("/?", "?");
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "path", request.path);
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "storage", request.storage);
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "destStorage", request.destStorage);

            try
            {
                var response = this.apiInvoker.InvokeApi(
                    resourcePath,
                    "PUT",
                    null,
                    null,
                    null);
                if (response != null)
                {
                    return (CreateFolderResponse)SerializationHelper.Deserialize(response, typeof(CreateFolderResponse));
                }

                return null;
            }
            catch (ApiException ex)
            {
                if (ex.ErrorCode == 404)
                {
                    return null;
                }

                throw;
            }
        }

        /// <summary>
        /// Copy a folder  
        /// </summary>
        /// <param name="request">Request. <see cref="PutCopyFolderRequest" /></param> 
        /// <returns><see cref="CreateFolderResponse"/></returns>            
        public CreateFolderResponse PutCopyFolder(PutCopyFolderRequest request)
        {
            // verify the required parameter 'path' is set
            if (request.path == null)
            {
                throw new ApiException(400, "Missing required parameter 'path' when calling PutCopyFolder");
            }

            // verify the required parameter 'newdest' is set
            if (request.newdest == null)
            {
                throw new ApiException(400, "Missing required parameter 'newdest' when calling PutCopyFolder");
            }

            // create path and map variables
            var resourcePath = this.configuration.GetApiRootUrl() + "/storage/folder";
            resourcePath = Regex
                        .Replace(resourcePath, "\\*", string.Empty)
                        .Replace("&amp;", "&")
                        .Replace("/?", "?");
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "path", request.path);
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "newdest", request.newdest);
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "storage", request.storage);
            resourcePath = UrlHelper.AddQueryParameterToUrl(resourcePath, "destStorage", request.destStorage);

            try
            {
                var response = this.apiInvoker.InvokeApi(
                    resourcePath,
                    "PUT",
                    null,
                    null,
                    null);
                if (response != null)
                {
                    return (CreateFolderResponse)SerializationHelper.Deserialize(response, typeof(CreateFolderResponse));
                }

                return null;
            }
            catch (ApiException ex)
            {
                if (ex.ErrorCode == 404)
                {
                    return null;
                }

                throw;
            }
        }
    }
}