
// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose" file="FilePutCreateRequest.cs">
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
  /// Request model for <see cref="Aspose.Storage.Cloud.Sdk.FilePutCreate" /> operation.
  /// </summary>  
  public class FilePutCreateRequest  
  {
        /// <summary>
        /// Initializes a new instance of the <see cref="FilePutCreateRequest"/> class.
        /// </summary>        
        public FilePutCreateRequest()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FilePutCreateRequest"/> class.
        /// </summary>
        /// <param name="path">Path where to upload including filename and extension e.g. /file.ext or /Folder 1/file.ext</param>
        /// <param name="file">File to upload</param>
        /// <param name="versionId">Source file&#39;s version</param>
        /// <param name="storage">User&#39;s storage name</param>
        public FilePutCreateRequest(string path, System.IO.Stream file, string versionId = null, string storage = null)             
        {
            this.path = path;
            this.File = file;
            this.versionId = versionId;
            this.storage = storage;
        }

        /// <summary>
        /// Path where to upload including filename and extension e.g. /file.ext or /Folder 1/file.ext
        /// </summary>  
        public string path { get; set; }

        /// <summary>
        /// File to upload
        /// </summary>  
        public System.IO.Stream File { get; set; }

        /// <summary>
        /// Source file's version
        /// </summary>  
        public string versionId { get; set; }

        /// <summary>
        /// User's storage name
        /// </summary>  
        public string storage { get; set; }
  }
}
