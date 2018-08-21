// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose Pty Ltd" file="BaseTestContext.cs">
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

namespace Aspose.Storage.Cloud.Sdk.Tests.Base
{
    using Aspose.Storage.Cloud.Sdk.Api;
    using Aspose.Storage.Cloud.Sdk.Model.Requests;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.IO;

    /// <summary>
    /// Base class for all tests
    /// </summary>
    [TestClass]
    public abstract class BaseTestContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseTestContext"/> class.
        /// </summary>
        protected BaseTestContext()
        {
            var configuration = new Configuration { AuthType = AuthType.OAuth2, ApiBaseUrl = ApiBaseUrl, AppSid = AppSid, AppKey = AppKey };
            this.StorageApi = new StorageApi(configuration);
        }

        #region Properties

        /// <summary>
        /// Storage API
        /// </summary>
        protected StorageApi StorageApi { get; set; }

        /// <summary>
        /// Base path for .NET aspose-storage-cloud sdk tests
        /// </summary>
        protected static string BaseTestPath { get { return @"testsdata\aspose.storage\sdktests\dotnet"; } }

        /// <summary>
        /// Base path for Data sdk - to permanently keep the files used by unit tests
        /// </summary>
        protected static string BaseTestDataPath = Path.Combine(BaseTestPath, "Data").Replace("\\", "/");

        /// <summary>
        /// Base path for test the sdk
        /// </summary>
        protected static string BaseTestFolderPath { get { return @"sdktests\dotnet"; } }

        /// <summary>
        /// Temp folder name
        /// </summary>
        protected static string TempFolderName = Guid.NewGuid().ToString();

        /// <summary>
        /// Temp folder path
        /// </summary>
        protected static string TempFolderPath = Path.Combine(BaseTestFolderPath, TempFolderName).Replace("\\", "/");

        /// <summary>
        /// Source storage name
        /// </summary>
        protected static string StorageName
        {
            get
            {
                var _storageName = Environment.GetEnvironmentVariable("StorageName");
                if (String.IsNullOrEmpty(_storageName))
                {
                    _storageName = "First Storage";
                }
                return _storageName;
            }
        }

        /// <summary>
        /// Destination storage name
        /// </summary>
        protected static string DestStorageName
        {
            get
            {
                var _destStorageName = Environment.GetEnvironmentVariable("DestStorageName");
                if (String.IsNullOrEmpty(_destStorageName))
                {
                    _destStorageName = StorageName;
                }
                return _destStorageName;
            }
        }

        /// <summary>
        /// AppKey
        /// </summary>
        protected string AppKey
        {
            get
            {
                return Environment.GetEnvironmentVariable("AppKey");
            }
        }

        /// <summary>
        /// AppSid
        /// </summary>
        protected string AppSid
        {
            get
            {
                return Environment.GetEnvironmentVariable("AppSid");
            }
        }

        /// <summary>
        /// ApiBaseUrl
        /// </summary>
        protected string ApiBaseUrl
        {
            get
            {
                return Environment.GetEnvironmentVariable("ApiBaseUrl");
            }
        }

        #endregion

        #region SetUp-Clean methods

        /// <summary>
        /// Initialization.
        /// </summary>
        [TestInitialize]
        public void SetUp()
        {
            #region Add folders

            try
            {
                for (var i = 1; i <= 2; i++)
                {
                    var request = new PutCreateFolderRequest();
                    request.Path = string.Format("{0}/TestFolder{1}", TempFolderPath, i);
                    request.Storage = StorageName;
                    request.DestStorage = DestStorageName;

                    var response = StorageApi.PutCreateFolder(request);
                    Assert.AreEqual(200, response.Code);
                }
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.Message.Contains("not supported"), ex.Message);
            }

            #endregion

            #region Add files
            {
                var request = new PutCreateRequest() { Storage = StorageName, VersionId = null };

                for (var i = 1; i <= 2; i++)
                {
                    //Add TestFile.data
                    request.File = new MemoryStream(new byte[] { 1, 2, 3, 4, 5, 6 });
                    request.Path = string.Format("{0}/TestFolder{1}/TestFile{1}.data", TempFolderPath, i);
                    var response = StorageApi.PutCreate(request);
                    Assert.AreEqual(200, response.Code);
                }

                //Add FileVersion.data - first version
                request.Path = string.Format("{0}/FileVersion.data", TempFolderPath);
                request.File = new MemoryStream(new byte[] { 1, 2, 3, 4, 5, 6 });
                var responseVersion = StorageApi.PutCreate(request);
                Assert.AreEqual(200, responseVersion.Code);

                //Add FileVersion.data - second version
                request.File = new MemoryStream(new byte[] { 1, 2, 3, 4, 5, 6, 7 });
                responseVersion = StorageApi.PutCreate(request);
                Assert.AreEqual(200, responseVersion.Code);

                #endregion
            }
        }

        /// <summary>
        /// Cleaning.
        /// </summary>
        [TestCleanup]
        public void Clean()
        {
            var request = new DeleteFolderRequest()
            {
                Path = TempFolderPath,
                Storage = StorageName,
                Recursive = true
            };
            var response = StorageApi.DeleteFolder(request);
            Assert.AreEqual(200, response.Code);
        }

        #endregion // End of  SetUp-Clean methods
    }
}