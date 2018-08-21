// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose Pty Ltd" file="OAuthTests.cs">
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

namespace Aspose.Storage.Cloud.Sdk.Tests
{
    // NMock has no implementation for .Net Core 
#if !NETCOREAPP2_0

    using Aspose.Storage.Cloud.Sdk;
    using Aspose.Storage.Cloud.Sdk.Api;
    using Aspose.Storage.Cloud.Sdk.Model.Requests;
    using Aspose.Storage.Cloud.Sdk.Tests.Base;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using NMock;
    using System.Diagnostics;
    using System.IO;
    using System.Threading;


    /// <summary>
    /// Tests of OAuth2 authentification
    /// </summary>
    [TestClass]
    public class OAuthTests : BaseTestContext
    {
        /// <summary>
        /// If token is not valid, refresh token should be successfully.
        /// Ignored because we use local server to test this feature (access token is expired in 1s)
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("OAuth")]
        public void IfTokenIsNotValidRefreshTokenShouldBeSuccessfully()
        {
            // Arrange
            var api =
                new StorageApi(
                    new Configuration
                    {
                        AppKey = AppKey,
                        AppSid = AppSid,
                        ApiBaseUrl = "http://localhost:8081",
                        AuthType = AuthType.OAuth2,
                        DebugMode = true
                    });

            using (var stream = this.ToStream("content"))
            {
                var request = new GetDownloadRequest();
                request.Path = Path.Combine(TempFolderPath, "TestFile.pdf");
                request.Storage = StorageName;
                api.GetDownload(request);

                Thread.Sleep(2000);
                stream.Flush();
                stream.Position = 0;

                var mockFactory = new MockFactory();
                var traceListenerMock = mockFactory.CreateMock<TraceListener>();
                Trace.Listeners.Add(traceListenerMock.MockObject);

                traceListenerMock.Expects.One.Method(p => p.WriteLine(string.Empty)).With(Is.StringContaining("grant_type=refresh_token"));
                traceListenerMock.Expects.AtLeastOne.Method(p => p.WriteLine(string.Empty)).With(Is.Anything);

                // Act
                api.GetDownload(request);

                // Assert
                mockFactory.VerifyAllExpectationsHaveBeenMet();
            }
        }

        private Stream ToStream(string str)
        {
            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(str);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }
    }

#endif
}