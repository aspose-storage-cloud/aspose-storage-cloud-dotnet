
// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose Pty Ltd" file="PutCopyRequest.cs">
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
  /// Request model for <see cref="Aspose.Storage.Cloud.Sdk.PutCopy" /> operation.
  /// </summary>  
  public class PutCopyRequest  
  {
        /// <summary>
        /// Initializes a new instance of the <see cref="PutCopyRequest"/> class.
        /// </summary>        
        public PutCopyRequest()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PutCopyRequest"/> class.
        /// </summary>
        /// <param name="path">Source file&#39;s path. Sample: &#39;/Folder 1/file.ext&#39; or &#39;/Bucket/Folder 1/file.ext&#39;</param>
        /// <param name="newdest">Destination file path</param>
        /// <param name="versionId">Source file&#39;s version</param>
        /// <param name="storage">User&#39;s source storage name</param>
        /// <param name="destStorage">User&#39;s destination storage name</param>
        public PutCopyRequest(string path, string newdest, string versionId = null, string storage = null, string destStorage = null)             
        {
            this.Path = path;
            this.Newdest = newdest;
            this.VersionId = versionId;
            this.Storage = storage;
            this.DestStorage = destStorage;
        }

        /// <summary>
        /// Source file's path. Sample: '/Folder 1/file.ext' or '/Bucket/Folder 1/file.ext'
        /// </summary>  
        public string Path { get; set; }

        /// <summary>
        /// Destination file path
        /// </summary>  
        public string Newdest { get; set; }

        /// <summary>
        /// Source file's version
        /// </summary>  
        public string VersionId { get; set; }

        /// <summary>
        /// User's source storage name
        /// </summary>  
        public string Storage { get; set; }

        /// <summary>
        /// User's destination storage name
        /// </summary>  
        public string DestStorage { get; set; }
  }
}
