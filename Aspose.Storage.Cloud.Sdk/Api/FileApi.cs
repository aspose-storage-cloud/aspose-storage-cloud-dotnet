// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose Pty Ltd" file="FileApi.cs">
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
    public class FileApi
    {        
        private readonly ApiInvoker apiInvoker;
        private readonly Configuration configuration;     

        /// <summary>
        /// Initializes a new instance of the <see cref="FileApi"/> class.
        /// </summary>
        /// <param name="apiKey">
        /// The api Key.
        /// </param>
        /// <param name="appSid">
        /// The app Sid.
        /// </param>
        public FileApi(string apiKey, string appSid)
            : this(new Configuration { AppKey = apiKey, AppSid = appSid })
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FileApi"/> class.
        /// </summary>    
        /// <param name="configuration">Configuration settings</param>
        public FileApi(Configuration configuration)
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
    }
}