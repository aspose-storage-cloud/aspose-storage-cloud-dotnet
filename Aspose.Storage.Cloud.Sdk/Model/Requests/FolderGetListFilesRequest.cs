
// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose" file="FolderGetListFilesRequest.cs">
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
  /// Request model for <see cref="Aspose.Storage.Cloud.Sdk.FolderGetListFiles" /> operation.
  /// </summary>  
  public class FolderGetListFilesRequest  
  {
        /// <summary>
        /// Initializes a new instance of the <see cref="FolderGetListFilesRequest"/> class.
        /// </summary>        
        public FolderGetListFilesRequest()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FolderGetListFilesRequest"/> class.
        /// </summary>
        /// <param name="path">Start with name of storage e.g. root folder &#39;/&#39;or some folder &#39;/folder1/..&#39;</param>
        /// <param name="storage">User&#39;s storage name</param>
        public FolderGetListFilesRequest(string path = null, string storage = null)             
        {
            this.path = path;
            this.storage = storage;
        }

        /// <summary>
        /// Start with name of storage e.g. root folder '/'or some folder '/folder1/..'
        /// </summary>  
        public string path { get; set; }

        /// <summary>
        /// User's storage name
        /// </summary>  
        public string storage { get; set; }
  }
}