## Pipeline Walkthroughs

### 1. [Framework Windows App pipeline](.github/workflows/deploy-winforms.yaml).

1. `on`: Describes the github event for which the pipeline needs to be triggered. Here, there are two conditions which need to be satisfied:
   a. A push event to the main branch.
   b. Code changes only in the WindowsFormsApp/ directory.

2. `jobs`: Describes the steps involved in the pipeline. There are a number of jobs in this pipeline, which are run on an ubuntu machine.
   This is specified by the `deploy` and `runs-on` directives.

   - Checkout repository: Takes the latest code from the main branch.

   - Install `Mono`: A package used to support building of dotnet framework projects on ubuntu systems.

   - Restore `NuGet` packages: Restore all the dependencies required for the project.

   - Build the project: Run the `msbuild` command to build the project.

   - Install `expect`: this is a library that is required to SSH into the Windows Server machine.

   - Create SSH directory and known_hosts file: We are creating a `known_hosts` file and adding the SSH key of our Windows server into the known hosts of the runner provisioned by Github.

   - Take Backup: After SSHing into the Windows server system, use xcopy to copy the existing built files from `inetpub\wwwroot\WinFormsApp` to the Backup folder.

   - Deploy: A custom scripts used to `scp` our built files into our host machine.

### 2. [Core Web Api pipeline](.github/workflows/deploy-webapi.yaml).

### 3. [Self Deploy Framework Console App pipeline](.github/workflows/self-deploy-webapi.yaml).

### 4. [Self Deploy Core Api pipeline](.github/workflows/self-deploy-consoleapp.yaml).

### 5. [Deploy Cpp App pipeline](.github/workflows/deploy-cpp.yaml).


