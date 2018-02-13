// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose Pty Ltd" file="FolderApi.cs">
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
    public class FolderApi
    {        
        private readonly ApiInvoker apiInvoker;
        private readonly Configuration configuration;     

        /// <summary>
        /// Initializes a new instance of the <see cref="FolderApi"/> class.
        /// </summary>
        /// <param name="apiKey">
        /// The api Key.
        /// </param>
        /// <param name="appSid">
        /// The app Sid.
        /// </param>
        public FolderApi(string apiKey, string appSid)
            : this(new Configuration { AppKey = apiKey, AppSid = appSid })
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FolderApi"/> class.
        /// </summary>    
        /// <param name="configuration">Configuration settings</param>
        public FolderApi(Configuration configuration)
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