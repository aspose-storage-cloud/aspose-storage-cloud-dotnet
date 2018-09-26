import jenkins.model.*

parameters {
    string(name: 'StartFromStage', defaultValue: '0', description: '0 based index of stage which will be started')
    string(name: 'Branch', defaultValue: 'origin/master', description: 'The branch to build.')
    string(name: 'Configuration', defaultValue: 'QA', description: 'The configuration to be released')
    string(name: 'StorageName', defaultValue: 'First Storage', description: 'The name of the source storage.')
    string(name: 'DestStorageName', defaultValue: 'First Storage', description: 'The name of the destination storage.')
    string(name: 'AppKey', defaultValue: 'de0580a17d82ce2c7e1e677be221b4c8', description: 'Application key.')
    string(name: 'AppSid', defaultValue: 'b35329d2-26af-44b3-8f07-91c702b84b26', description: 'Application string id.')
    string(name: 'ApiBaseUrl', defaultValue: 'https://api-qa.aspose.cloud', description: 'Api base url.')
    string(name: 'TestCategory', defaultValue: 'Storage%7cFiles%7cFolders', description: 'Specify the tests category to run.')
}

env.Branch = params.Branch
env.Configuration = params.Configuration
env.StorageName = params.StorageName
env.DestStorageName = params.DestStorageName
env.AppKey = params.AppKey
env.AppSid = params.AppSid
env.ApiBaseUrl = params.ApiBaseUrl
env.TestCategory = params.TestCategory
env.ImageName='afc-storage-sdk-tests-image'
env.ContainerName='afc-storage-sdk-tests-container'

node('billing-qa-tyler') {
    stage("0: Print environment variables:") {
        powershell '''
            Write-Host Branch: $env:Branch
            Write-Host Configuration: $env:Configuration
            Write-Host StorageName: $env:StorageName
            Write-Host DestStorageName: $env:DestStorageName
            Write-Host AppKey: $env:AppKey
            Write-Host AppSid: $env:AppSid
            Write-Host ApiBaseUrl: $env:ApiBaseUrl
            Write-Host TestCategory: $env:TestCategory
            Write-Host ImageName: $env:ImageName
            Write-Host ContainerName: $env:ContainerName
        '''
    }

    dir('C:/Builds/Storage/AFC-Tests') {
        try {
                stage('1: Checkout Aspose.Storage.Cloud.Sdk') {
                    if (params.StartFromStage.toInteger() <= 1) {
                        checkout([
                                $class: 'GitSCM',
                                branches: [[name: '${Branch}']],
                                doGenerateSubmoduleConfigurations: false,
                                extensions: [],
                                submoduleCfg: [],
                                userRemoteConfigs: [[credentialsId: 'ba4d3a22-46a7-413e-b839-5f5b6f5e3303',
                                                    url: 'https://github.com/aspose-storage-cloud/aspose-storage-cloud-dotnet.git']]
                            ])
                            
                        powershell "git config user.email \"jenkins.aspose@gmail.com\""
                        powershell "git config user.name \"jenkins\""
                    }
                }
                stage('2: Create Image for Aspose.Storage.Cloud.Sdk.Tests ') {
                    if (params.StartFromStage.toInteger() <= 2) {
                        powershell '''
                            Write-Host [Step 1] Set image and container names
                            $imageName=$env:ImageName
                            $containerName=$env:ContainerName

                            Write-Host [Step 2] Delete the old container
                            docker rm -f $containerName

                            Write-Host [Step 3] Build the new image
                            docker build --target testrunner -t $imageName .
                        '''
                    }
                }
                stage('3: Run Parameterized Tests into Docker Container ') {
                    if (params.StartFromStage.toInteger() <= 3) {
                        powershell '''
                            Write-Host [Step 1] Set image and container names
                            $imageName=$env:ImageName
                            $containerName=$env:ContainerName

                            Write-Host [Step 2] Delete the old container
                            docker rm -f $containerName

                            Write-Host [Step 3] Run the new container
                            $category=$env:TestCategory.replace("%7c", "%7cTestCategory=")
                            docker run -d -p 8282:80 `
                                -e StorageName=$env:StorageName `
                                -e DestStorageName=$env:DestStorageName `
                                -e AppKey=$env:AppKey `
                                -e AppSid=$env:AppSid `
                                -e ApiBaseUrl=$env:ApiBaseUrl `
                                --name $containerName $imageName `
                                --filter TestCategory=$category

                            Write-Host [Step 4] Wait for the tests to run
                            docker wait $containerName

                            Write-Host [Step 5] Copy test results
                            docker cp ${containerName}:/app/publish C:/Builds/Storage/AFC-Tests
                        '''

                        step([
                            $class: 'MSTestPublisher',
                            testResultsFile:"publish/TestResults/*.trx",
                            failOnError: true,
                            keepLongStdio: true
                        ])
                    }
                }
        }
        catch (error) {
           stage "Cleanup after fail"
           emailext attachLog: true, body: "Build failed (see ${env.BUILD_URL}): ${error}", subject: "[JENKINS] ${env.JOB_NAME} failed", to: 'madalina.marloi@aspose.com'
           throw error
        }
        finally {
        }
    }
}