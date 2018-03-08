
// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose Pty Ltd" file="GetDownloadRequest.cs">
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
namespace Aspose.Storage.Cloud.Sdk.Model.Requests 
{
  using Aspose.Storage.Cloud.Sdk.Model; 

  /// <summary>
  /// Request model for <see cref="Aspose.Storage.Cloud.Sdk.GetDownload" /> operation.
  /// </summary>  
  public class GetDownloadRequest  
  {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetDownloadRequest"/> class.
        /// </summary>        
        public GetDownloadRequest()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetDownloadRequest"/> class.
        /// </summary>
        /// <param name="path">Path of the file including the file name and extension e.g. /file.ext</param>
        /// <param name="versionId">File&#39;s version</param>
        /// <param name="storage">User&#39;s storage name</param>
        public GetDownloadRequest(string path, string versionId = null, string storage = null)             
        {
            this.Path = path;
            this.VersionId = versionId;
            this.Storage = storage;
        }

        /// <summary>
        /// Path of the file including the file name and extension e.g. /file.ext
        /// </summary>  
        public string Path { get; set; }

        /// <summary>
        /// File's version
        /// </summary>  
        public string VersionId { get; set; }

        /// <summary>
        /// User's storage name
        /// </summary>  
        public string Storage { get; set; }
  }
}